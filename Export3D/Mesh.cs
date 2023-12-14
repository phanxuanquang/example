using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Model2OBJ
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
        public void Export()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();

                saveDialog.Title = "Save as .obj file";
                saveDialog.Filter = "OBJ files (*.obj)|*.obj";
                saveDialog.FileName = String.Format("Navisworks Model - {0}.obj", DateTime.Now.ToString("MMdd-HHmm"));
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string location = saveDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(location))
                    {
                        foreach (var vertex in vertexes)
                        {
                            writer.WriteLine(String.Format("v {0} {1} {2}", vertex.X, vertex.Y, vertex.Z));
                        }

                        for (int i = 0; i < faceIndexes.Count; i = i + 3)
                        {
                            writer.WriteLine(String.Format("f {0} {1} {2}", faceIndexes[i] + 1, faceIndexes[i + 1] + 1, faceIndexes[i + 2] + 1));
                        }
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
