using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;


namespace Export3D
{
    [PluginAttribute("Test", "ADSK", DisplayName = "Test")]
    [AddInPluginAttribute(AddInLocation.AddIn)]
    public class Exporter : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Autodesk.Navisworks.Api.DocumentParts.DocumentCurrentSelection curSel = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection;
            curSel.SelectAll();
            ModelItemCollection allModelItems = Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems;

            InwOpState state = ComBridge.State;
            InwOpSelection selection = ComBridge.ToInwOpSelection(allModelItems);
            CallbackGeomListener listener = new CallbackGeomListener();

            foreach (InwOaPath3 path in selection.Paths())
            {
                foreach (InwOaFragment3 frag in path.Fragments())
                {
                    // frag.GenerateSimplePrimitives(nwEVertexProperty.eNORMAL, listener);

                    //var matrix = (InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();
                    //var translation = matrix.GetTranslation();
                    try
                    {
                        //var matrix = (InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();

                        COMApi.InwLTransform3f a = frag.GetLocalToWorldMatrix();
                        object obj = a.Matrix;
                        Array.Copy((Array)obj, listener.matrix, 16);

                        frag.GenerateSimplePrimitives(nwEVertexProperty.eNORMAL, listener);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Mesh.instance.ExportTo();
            return 0;
        }

        private List<double> ConvertMatrix(InwLTransform3f3 matrix)
        {
            

            return null;
        }
    }
}
