using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Windows.Forms;

namespace Viewer
{
    [PluginAttribute("Model Viewer", "ADSK", ToolTip = "View all properties of active model", DisplayName = "Model Viewer")]

    public class Handler : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            try
            {
                Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
                DocumentModels models = doc.Models;
                Model model = models.First;
                ModelItem rootItem = doc.Models.First.RootItem;
                //ModelItemEnumerableCollection modelItems = rootItem.DescendantsAndSelf;

                TreeNode root = new TreeNode(rootItem.DisplayName);

                var ModelViewForm = new ModelViewing();

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
        public ModelItem modelItem { get; }
        public ModelNode(string name = "No Name", ModelItem item = null)
        {
            Text = name;
            modelItem = item;
        }
    }
}
