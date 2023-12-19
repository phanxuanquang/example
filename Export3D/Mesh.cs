using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Model2OBJ
{
    internal class Mesh
    {
        /// <summary>
        /// Vertex list of the mesh
        /// </summary>
        private List<Point3D> vertexes;
        /// <summary>
        /// Face index list of the mesh
        /// </summary>
        private List<int> faceIndexes;
        /// <summary>
        /// This mesh
        /// </summary>
        public static Mesh instance;
        public Mesh()
        {
            vertexes = new List<Point3D>();
            faceIndexes = new List<int>();
            instance = this;
        }
        /// <summary>
        /// Add created created triangle to the mesh.
        /// </summary>
        /// <param name="x">1st vertex</param>
        /// <param name="y">2nd vertex</param>
        /// <param name="z">3nd vertex</param>
        public void AppendTriangleWithVertexes(Point3D x, Point3D y, Point3D z)
        {
            vertexes.Add(x);
            vertexes.Add(y);
            vertexes.Add(z);

            faceIndexes.Add(vertexes.Count - 3);
            faceIndexes.Add(vertexes.Count - 2);
            faceIndexes.Add(vertexes.Count - 1);
        }
        /// <summary>
        /// Export all the mest to a .obj file to the seleted location
        /// </summary>
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
