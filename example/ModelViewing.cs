using System.Windows.Forms;

namespace Viewer
{
    public partial class ModelViewing : Form
    {
        public ModelViewing()
        {
            InitializeComponent();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
    }
}
