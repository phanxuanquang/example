using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Windows.Forms;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;


namespace Model2OBJ
{
    [PluginAttribute("Model2OBJ", "ADSK", ToolTip = "Export model to .obj file", DisplayName = "Model2OBJ")]
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
                    try
                    {
                        Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3 localToWorld = (Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();
                        listener.coordinateStandard = localToWorld;

                        frag.GenerateSimplePrimitives(nwEVertexProperty.eCOLOR, listener);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Mesh.instance.Export();
            return 0;
        }
    }
}
