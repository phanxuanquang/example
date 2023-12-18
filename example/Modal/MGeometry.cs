using Autodesk.Navisworks.Api;

namespace ModelViewer
{
    internal class MGeometry
    {
        public int id { get; set; }
        public MColor color { get; set; }
        public double transparency { get; set; }
        public Vector3D translation { get; set; }

        public MGeometry(int id, Transform3D transform, MColor color, double transparency)
        {
            this.id = id;
            translation = transform.Translation;
            this.color = color;
            this.transparency = transparency;
        }
    }
}
