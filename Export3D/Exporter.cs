using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;

using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;

using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.Interop.ComApi;

namespace Export3D
{
    #region InwSimplePrimitivesCB Class
    class Mesh
    {
        List<Point3D> points;
        List<int> faces;
        public static Mesh instance;
        public Mesh()
        {
            points = new List<Point3D>();
            faces = new List<int>();
            instance = this;
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
        public void ExportTo(string filePath = "D:\\output.obj")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var point in points)
                    {
                        writer.WriteLine(String.Format("v {0} {1} {2}", (float)point.X, (float)point.Y, (float)point.Z));
                    }

                    for (int i = 0; i < faces.Count; i = i + 3)
                    {
                        writer.WriteLine(String.Format("f {0} {1} {2}", faces[i]+1, faces[i + 1]+1, faces[i + 2] + 1));
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
        Mesh mesh = new Mesh();
        Transform3D transform = new Transform3D();
        public void Line(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2) { }
        public void Point(COMApi.InwSimpleVertex v1) 
        {

        }
        public void SnapPoint(COMApi.InwSimpleVertex v1) { }
        public void Triangle(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2, COMApi.InwSimpleVertex v3)
        {
            Point3D getCoordinatesFrom(Array triangle)
            {
                return new Point3D(Convert.ToDouble(triangle.GetValue(1)), Convert.ToDouble(triangle.GetValue(2)), Convert.ToDouble(triangle.GetValue(3)));
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
    public class Exporter : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Autodesk.Navisworks.Api.DocumentParts.DocumentCurrentSelection curSel = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection;
            curSel.SelectAll();
            ModelItemCollection oModelColl = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems;
            

            COMApi.InwOpState oState = ComBridge.State;
            COMApi.InwOpSelection oSel = ComBridge.ToInwOpSelection(oModelColl);
            CallbackGeomListener callbkListener = new CallbackGeomListener();

            foreach (COMApi.InwOaPath3 path in oSel.Paths())
            {
                foreach (COMApi.InwOaFragment3 frag in path.Fragments())
                {
                    frag.GenerateSimplePrimitives(COMApi.nwEVertexProperty.eNORMAL, callbkListener);
                    var matrix = (InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();
                    var X = matrix.GetTranslation().data1;
                }
            }

            Mesh.instance.ExportTo();
            return 0;
        }
    }
    #endregion
}
