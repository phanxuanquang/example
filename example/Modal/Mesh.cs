using Autodesk.Navisworks.Api;
using System.Collections.Generic;

namespace ModelViewer.Modal
{
    internal class Mesh
    {
        /// <summary>
        /// Vertex list of the mesh
        /// </summary>
        public List<Point3D> vertexes { get; set; }
        /// <summary>
        /// Face index list of the mesh
        /// </summary>
        public List<int> faceIndexes { get; set; }
        /// <summary>
        /// This mesh
        /// </summary>
        public static Mesh instance { get; set; }
        public Mesh()
        {
            vertexes = new List<Point3D>();
            faceIndexes = new List<int>();
            instance = this;
        }
        public void AppendTriangleWithVertexes(Point3D x, Point3D y, Point3D z)
        {
            vertexes.Add(x);
            vertexes.Add(y);
            vertexes.Add(z);

            faceIndexes.Add(vertexes.Count - 3);
            faceIndexes.Add(vertexes.Count - 2);
            faceIndexes.Add(vertexes.Count - 1);

        }
    }
}
