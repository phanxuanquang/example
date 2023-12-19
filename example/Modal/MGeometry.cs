using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Interop.ComApi;
using ModelViewer.Modal;
using System.Windows.Forms;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;

namespace ModelViewer
{
    internal class MGeometry
    {
        public int id { get; set; }
        public MColor color { get; set; }
        public double transparency { get; set; }
        public Mesh mesh { get; set; }

        public Mesh GetMeshFrom(ModelItem model)
        {
            if (model != null)
            {
                InwOpState state = ComBridge.State;
                CallbackGeomListener listener = new CallbackGeomListener();
                InwOaPath3 path = (InwOaPath3)ComBridge.ToInwOaPath(model);
                foreach (InwOaFragment3 frag in path.Fragments())
                {
                    Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3 localToWorld = (Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();
                    listener.coordinateStandard = localToWorld;

                    frag.GenerateSimplePrimitives(nwEVertexProperty.eCOLOR, listener);
                }
                return listener.mesh;
            }
            MessageBox.Show("Get Mess Failed");
            return null;
        }

        public MGeometry(int id, MColor color, double transparency, ModelItem model)
        {
            this.id = id;
            this.color = color;
            this.transparency = transparency;
            mesh = GetMeshFrom(model);
        }


    }
}
