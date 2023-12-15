﻿using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Viewer
{
    [PluginAttribute("Model Viewer", "ADSK", ToolTip = "View all properties of active model", DisplayName = "Model Viewer")]

    public class Handler : AddInPlugin
    {
        List<ModelItem> modelNodes = new List<ModelItem>();
        public override int Execute(params string[] parameters)
        {
            try
            {
                Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
                DocumentModels models = doc.Models;
                Model model = models.First;
                ModelItem rootItem = doc.Models.First.RootItem;

                TreeNode root = new TreeNode(rootItem.DisplayName);

                var ModelViewForm = new ModelViewing();

                ModelViewForm.ModelHiariachyTree.Nodes.Add(root);
                LoadModelsToTreeView(rootItem, root);
                ModelViewForm.models = modelNodes;
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
                TreeNode node = new ModelNode(modelItem.DisplayName, modelItem);
                modelNodes.Add(modelItem);
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
