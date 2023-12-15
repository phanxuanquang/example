using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Autodesk.Navisworks.Api;
using ModelViewer;

namespace Viewer
{
    partial class ModelViewing : Form
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

        private void ExportButton_Click(object sender, System.EventArgs e)
        {
            foreach (var model in models)
            {
                richTextBox.Text += model.DisplayName + "\n";
            }
            DatabaseExporter databaseExporter = new DatabaseExporter(models);
        }  
    }
}
