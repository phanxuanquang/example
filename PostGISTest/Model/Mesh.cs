using System.Collections.Generic;

namespace PostGISTest
{
    internal class Vertex
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    internal class Mesh
    {
        public List<Vertex> vertexes { get; set; }
        public List<int> faceIndexes { get; set; }
    }

    internal class ExtendedMesh
    {
        public Mesh mesh { get; set; }
        public int id { get; set; }
        public ExtendedMesh(int id, Mesh mesh)
        {
            this.id = id;
            this.mesh = mesh;
        }
    }
}
