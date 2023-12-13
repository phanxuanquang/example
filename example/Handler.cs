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

    [PluginAttribute("BasicPlugIn.ABasicPlugin", "ADSK", ToolTip = "BasicPlugIn.ABasicPlugin tool tip", DisplayName = "Hello World Plugin")]

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

                var showForm = new ShowForm();

                showForm.treeView.Nodes.Add(root);
                loadNodes(rootItem, root);
                showForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }
        private void loadNodes(ModelItem xmlNode, TreeNode treeNode)
        {
            foreach (var modelItems in xmlNode.Children)
            {
                TreeNode node = new Node(modelItems.DisplayName, modelItems);
                treeNode.Nodes.Add(node);
                loadNodes(modelItems, node);
            }
        }
    }
    public class Node : TreeNode
    {
        public ModelItem modelItem { get; set; }
        public Node(string name = "No Name", ModelItem item = null)
        {
            this.Text = name;
            this.modelItem = item;
        }
    }

    #region InwSimplePrimitivesCB Class
    class Mesh
    {
        List<Point3D> points;
        List<int> faces;
        public Mesh()
        {
            points = new List<Point3D>();
            faces = new List<int>();
        }
        public void AddTriangleWithVertexes(Point3D x, Point3D y, Point3D z)
        {
            points.Add(x);
            points.Add(y);
            points.Add(z);
            faces.Add(points.Count - 3);
            faces.Add(points.Count - 2);
            faces.Add(points.Count - 1);
        }
        void ExportTo(string filePath = "output.obj")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var point in  points)
                    {
                        writer.WriteLine(String.Format("v {0} {1} {2}", point.X, point.Y, point.Z));
                    }

                    for(int i = 0; i < faces.Count; i = i + 3) 
                    {
                        writer.WriteLine(String.Format("f {0} {1} {2}", faces[i], faces[i + 1], faces[i + 2]));
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    class CallbackGeomListener : COMApi.InwSimplePrimitivesCB
    {
        Mesh mesh;
        public void Line(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2) { }
        public void Point(COMApi.InwSimpleVertex v1) { }
        public void SnapPoint(COMApi.InwSimpleVertex v1) { }
        public void Triangle(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2, COMApi.InwSimpleVertex v3)
        {
            Point3D getCoordinatesFrom(Array triangle)
            {
                return new Point3D((double)(triangle.GetValue(1)), (double)(triangle.GetValue(2)), (double)(triangle.GetValue(3)));
            }

            Point3D X = getCoordinatesFrom((Array)(object)v1.coord);
            Point3D Y = getCoordinatesFrom((Array)(object)v2.coord);
            Point3D Z = getCoordinatesFrom((Array)(object)v3.coord);

            mesh.AddTriangleWithVertexes(X, Y, Z);
        }
    }
    #endregion

    #region NW Plugin
    [PluginAttribute("Test", "ADSK", DisplayName = "Test")]
    [AddInPluginAttribute(AddInLocation.AddIn)]
    public class Class1 : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            ModelItemCollection oModelColl = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems;

            COMApi.InwOpState oState = ComBridge.State;
            COMApi.InwOpSelection oSel = ComBridge.ToInwOpSelection(oModelColl);
            CallbackGeomListener callbkListener = new CallbackGeomListener();

            foreach (COMApi.InwOaPath3 path in oSel.Paths())
            {
                foreach (COMApi.InwOaFragment3 frag in path.Fragments())
                {
                    frag.GenerateSimplePrimitives(COMApi.nwEVertexProperty.eNORMAL, callbkListener);
                }
            }
            return 0;
        }
    }
    #endregion
}
