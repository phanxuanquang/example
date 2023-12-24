using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGISTest
{
    internal class Vertex
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vertex(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    internal class Mesh
    {
        /// <summary>
        /// Vertex list of the mesh
        /// </summary>
        public List<Vertex> vertexes { get; set; }
        /// <summary>
        /// Face index list of the mesh
        /// </summary>
        public List<int> faceIndexes { get; set; }
        /// <summary>
        /// This mesh
        /// </summary>
        public Mesh()
        {
            vertexes = new List<Vertex>();
            faceIndexes = new List<int>();
        }
    }

    internal class GeometryMesh
    {
        public Mesh mesh { get; set; }
        public int id { get; set; }
        public GeometryMesh(int id, Mesh mesh)
        {
            this.id = id;
            this.mesh = mesh;
        }
    }
}
