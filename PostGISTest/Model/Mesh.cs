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
        public Mesh()
        {
            vertexes = new List<Vertex>();
            faceIndexes = new List<int>();
        }

        public void CreateMergedMeshesFrom(List<ExtendedMesh> meshes)
        {
            foreach (ExtendedMesh item in meshes)
            {
                if (item.mesh != null)
                {
                    foreach (int index in item.mesh.faceIndexes)
                    {
                        faceIndexes.Add(index + vertexes.Count);
                    }
                    vertexes.AddRange(item.mesh.vertexes);
                }
            }
        }
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
