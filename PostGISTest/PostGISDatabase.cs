using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PostGISTest
{
    internal class PostGISDatabase
    {
        public NpgsqlConnection connection { get; set; }
        public PostGISDatabase(string conncectionString)
        {
            connection = new NpgsqlConnection(conncectionString);
        }

        public void InitTables()
        {
            try
            {
                connection.Open();
                CreateTablesFrom("SQLite.sql");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot create tables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void CreateTablesFrom(string filePath)
        {
            string GetScript()
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("File not found. Please try again.", "Getting SQL script failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Reading SQL script failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return String.Empty;
                }
            }

            string sqlScript = GetScript();

            if (!string.IsNullOrEmpty(sqlScript))
            {
                using (var command = new NpgsqlCommand(sqlScript, connection))
                {
                    Execute(command, "Creating table failed");
                }
            }
        }
        private void Execute(NpgsqlCommand executer, string error)
        {
            try
            {
                executer.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertDataFrom(List<Table> tables)
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;

                    foreach (var table in tables)
                    {
                        foreach (var row in table.rows)
                        {
                            try
                            {
                                cmd.CommandText = String.Format("INSERT INTO {0} ({1}) VALUES ({2})", table.name, String.Join(", ", table.columns), row);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error while inserting data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                transaction.Commit();
            }

            connection.Close();
        }
        public void InsertMeshFrom(Mesh mesh, int id)
        {
            var jsonData = JsonConvert.SerializeObject(mesh);
            JObject jsonObject = JObject.Parse(jsonData);
            JArray vertices = (JArray)jsonObject["vertexes"];
            JArray vertexOrders = (JArray)jsonObject["faceIndexes"];

            List<string> uniqueVertices = new List<string>();
            foreach (var vertex in vertices)
            {
                uniqueVertices.Add($"{vertex["x"]} {vertex["y"]} {vertex["z"]}");
            }

            List<string> fullFaceVertices = new List<string>();
            foreach (int order in vertexOrders)
            {
                fullFaceVertices.Add(uniqueVertices[order]);
            }
            fullFaceVertices.Add(uniqueVertices[0]);

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string polygonString = $"POLYGON Z(({String.Join(",", fullFaceVertices)}))";
                    string sql = $"UPDATE MGeometry SET Triangles = (ST_GeomFromText('{polygonString}')) WHERE id = {id}";

                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while inserting meshes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<ExtendedMesh> GetMeshes()
        {
            List<ExtendedMesh> meshes = new List<ExtendedMesh>();
            connection.Open();
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT id, mesh FROM MGeometry order by id", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            Mesh mesh = JsonConvert.DeserializeObject<Mesh>(reader["mesh"].ToString());

                            ExtendedMesh geometryMesh = new ExtendedMesh(id, mesh);
                            meshes.Add(geometryMesh);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while getting meshes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
            return meshes;
        }

        public void RemoveColumn(string table, string column)
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                string sql = $"ALTER TABLE {table} DROP COLUMN {column}";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }

            connection.Close();
        }
    }
}
