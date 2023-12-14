using System;
using System.Windows.Forms;

//Add two new namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;

using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;

using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;
using System.Collections.Generic;
using System.IO;

namespace example
{

    [PluginAttribute("BasicPlugIn.ABasicPlugin", "ADSK", ToolTip = "View all properties of active model.", DisplayName = "Model Viewer")]

    public class Handler : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            try
            {
                Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
                DocumentModels models = doc.Models;
                Model model = models.First;
                ModelItem rootItem = model.RootItem;
                ModelItemEnumerableCollection modelItems = rootItem.DescendantsAndSelf;

                TreeNode root = new TreeNode(rootItem.DisplayName);

                var ModelViewForm = new ShowForm();

                ModelViewForm.ModelHiariachyTree.Nodes.Add(root);
                LoadModelsToTreeView(rootItem, root);
                ModelViewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }
        private void LoadModelsToTreeView(ModelItem model, TreeNode treeNode)
        {
            foreach (var modelItems in model.Children)
            {
                TreeNode node = new ModelNode(modelItems.DisplayName, modelItems);
                treeNode.Nodes.Add(node);
                LoadModelsToTreeView(modelItems, node);
            }
        }
    }
    public class ModelNode : TreeNode
    {
        public ModelItem modelItem { get; set; }
        public ModelNode(string name = "No Name", ModelItem item = null)
        {
            this.Text = name;
            this.modelItem = item;
        }
    }
}
