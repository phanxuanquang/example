using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Viewer
{
    [PluginAttribute("Model Viewer", "ADSK", ToolTip = "View all properties of active model", DisplayName = "Model Viewer")]
    internal partial class Handler : AddInPlugin
    {
        //private List<ModelItem> modelNodes = new List<ModelItem>();
        private ModelViewing ModelViewForm;
        public override int Execute(params string[] parameters)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveAssembly;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
            return DoExecute(parameters);
        }

        private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {            
            var assemblyName = args.Name;
            if (assemblyName.IndexOf(",") >= 0)
            {
                assemblyName = assemblyName.Substring(0, assemblyName.IndexOf(","));
            }
            var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(currentFolder, assemblyName + ".dll");
            return Assembly.Load(path);
        }

        private int DoExecute(string[] parameters)
        {
            try
            {
                Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
                DocumentModels models = doc.Models;
                Model model = models.First;
                ModelItem rootItem = doc.Models.First.RootItem;

                TreeNode root = new TreeNode(rootItem.DisplayName);

                ModelViewForm = new ModelViewing();

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
            foreach (var modelItem in model.Children)
            {
                ModelViewForm.models.Add(modelItem);
                TreeNode node = new ModelNode(modelItem.DisplayName, modelItem);
                treeNode.Nodes.Add(node);
                LoadModelsToTreeView(modelItem, node);
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
