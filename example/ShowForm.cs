using Autodesk.Navisworks.Api;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace example
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is Node node)
            {
                PropertiesTabs.TabPages.Clear();
                loadProperties(node);
            }
        }

        void loadProperties(Node node)
        {
            foreach (var properties in node.modelItem.PropertyCategories)
            {
                TabPage propertyTab = new TabPage(properties.DisplayName);

                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.ReadOnly = true;
                foreach (var property in properties.Properties)
                {
                    DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                    newColumn.HeaderText = property.DisplayName; // Set the header text for the new column

                    newColumn.Name = property.Name;
                    dataGridView.Columns.Add(newColumn);
                }

                propertyTab.Controls.Add(dataGridView);
                PropertiesTabs.TabPages.Add(propertyTab);
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
