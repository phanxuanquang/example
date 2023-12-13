using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Export3D
{
    internal class Mesh
    {
        private List<Point3D> vertexes;
        private List<int> faceIndexes;
        public static Mesh instance;
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
        public void ExportTo(string filePath = "D:\\output.obj")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var point in vertexes)
                    {
                        writer.WriteLine(String.Format("v {0:0.000} {1:0.000} {2:0.000}", (float)point.X, (float)point.Y, (float)point.Z));
                    }

                    for (int i = 0; i < faceIndexes.Count; i = i + 3)
                    {
                        writer.WriteLine(String.Format("f {0} {1} {2}", faceIndexes[i] + 1, faceIndexes[i + 1] + 1, faceIndexes[i + 2] + 1));
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
}
