using Autodesk.Navisworks.Api;
using ModelViewer;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer
{
    internal partial class ModelViewing : Form
    {
        public List<ModelItem> models;
        public ModelViewing()
        {
            InitializeComponent();
            models = new List<ModelItem>();
        }

        private void TreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ModelNode node)
            {
                PropertyCategoryTabs.TabPages.Clear();
                LoadPropertiesOf(node);
            }
        }

        private void LoadPropertiesOf(ModelNode node)
        {
            foreach (var propertyCategory in node.modelItem.PropertyCategories)
            {
                TabPage propertyCategoryTab = new TabPage(propertyCategory.DisplayName);

                DataGridView propertiesTable = new DataGridView();
                propertiesTable.Dock = DockStyle.Fill;
                propertiesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                propertiesTable.ReadOnly = true;
                foreach (var category in propertyCategory.Properties)
                {
                    DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                    newColumn.HeaderText = category.DisplayName; // Set the header text for the new column

                    newColumn.Name = category.Name;
                    propertiesTable.Columns.Add(newColumn);
                }

                propertyCategoryTab.Controls.Add(propertiesTable);
                PropertyCategoryTabs.TabPages.Add(propertyCategoryTab);
            }
        }

        private int getParentID(int currentID, List<ModelItem> models)
        {
            if (models.Contains(models[currentID].Parent))
            {
                return models.IndexOf(models[currentID].Parent);
            }
            return 0;
        }

        private void ExportButton_Click(object sender, System.EventArgs e)
        {
            SQLiteDatabaseManager databaseExporter = new SQLiteDatabaseManager();
            databaseExporter.connection.Open();

            using (var transaction = databaseExporter.connection.BeginTransaction())
            {
                int propertyCategoryID = 0;
                int propertyID = 0;

                for (int i = 0; i < models.Count; i++)
                {
                    var model = models[i];
                    MGeometry mGeometry = null;

                    if (model.Geometry != null)
                    {
                        MColor mColor = new MColor(i, model.Geometry.ActiveColor.R, model.Geometry.ActiveColor.G, model.Geometry.ActiveColor.B);
                        databaseExporter.Insert(mColor);

                        mGeometry = new MGeometry(i, mColor, model.Geometry.ActiveTransparency, model);
                        databaseExporter.Insert(mGeometry);
                    }

                    MModel mModel = new MModel(i, getParentID(i, models), model.DisplayName, mGeometry);
                    databaseExporter.Insert(mModel);

                    foreach (var category in model.PropertyCategories)
                    {
                        propertyCategoryID++;
                        MPropertyCategory mPropertyCategory = new MPropertyCategory(propertyCategoryID, category.DisplayName);
                        databaseExporter.Insert(mPropertyCategory);

                        foreach (var property in category.Properties)
                        {
                            propertyID++;
                            MProperty mProperty = new MProperty(propertyID, property.DisplayName, property.Value.ToString());
                            databaseExporter.Insert(mProperty);

                            databaseExporter.Insert(mModel, mPropertyCategory, mProperty);
                        }
                    }
                }

                transaction.Commit();
            }

            databaseExporter.connection.Close();
        }
    }
}
