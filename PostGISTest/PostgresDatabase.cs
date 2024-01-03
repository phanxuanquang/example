using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PostGISTest
{
    internal class PostgresDatabase
    {
        public NpgsqlConnection connection { get; set; }
        public PostgresDatabase(string conncectionString)
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
        private void Execute(NpgsqlCommand executer, string errorMessage)
        {
            try
            {
                executer.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Insert(List<Table> tables)
        {
            connection.Open();

            using (NpgsqlTransaction transaction = connection.BeginTransaction())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;

                    foreach (Table table in tables)
                    {
                        foreach (string row in table.rows)
                        {
                            cmd.CommandText = $"INSERT INTO {table.name} ({String.Join(", ", table.columns)}) VALUES ({row})";
                            Execute(cmd, "Error while inserting data");
                        }
                    }
                }

                transaction.Commit();
            }

            connection.Close();
        }
        public void Insert(Mesh mesh, int id)
        {
            string jsonData = JsonConvert.SerializeObject(mesh);
            JObject jsonObject = JObject.Parse(jsonData);
            JArray vertices = (JArray)jsonObject["vertexes"];
            JArray vertexOrders = (JArray)jsonObject["faceIndexes"];

            List<string> uniqueVertices = new List<string>();
            foreach (JToken vertex in vertices)
            {
                uniqueVertices.Add($"{vertex["x"]} {vertex["y"]} {vertex["z"]}");
            }

            List<string> fullFaceVertices = new List<string>();
            foreach (int order in vertexOrders)
            {
                fullFaceVertices.Add(uniqueVertices[order]);
            }
            fullFaceVertices.Add(uniqueVertices[0]);

            connection.Open();

            using (NpgsqlTransaction transaction = connection.BeginTransaction())
            {
                string polygonString = $"POLYGON Z(({String.Join(",", fullFaceVertices)}))";
                string sql = $"UPDATE MGeometry SET Triangles = (ST_GeomFromText('{polygonString}')) WHERE id = {id}";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                {
                    Execute(cmd, "Error while inserting meshes");
                }

                transaction.Commit();
            }

            connection.Close();
        }
        public void Insert(List<Triangle> triangles)
        {
            connection.Open();

            using (NpgsqlTransaction transaction = connection.BeginTransaction())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;

                    foreach (Triangle triangle in triangles)
                    {
                        cmd.CommandText = $"INSERT INTO Geo (id, geos) VALUES ({triangle.id}, ST_GeomFromText('{triangle.triangle}'))";
                        Execute(cmd, "Error while inserting triangles");
                    }
                }

                transaction.Commit();
            }

            connection.Close();
        }
        public List<ExtendedMesh> GetMeshes()
        {
            List<ExtendedMesh> meshes = new List<ExtendedMesh>();
            connection.Open();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id, mesh FROM MGeometry order by id", connection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
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
        public List<Triangle> GetTriangles()
        {
            List<Triangle> triangles = new List<Triangle>();
            connection.Open();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("select id, ST_AsText(triangles) from mgeometry where triangles is not null order by id", connection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string triangle = reader["st_astext"].ToString();

                            Triangle newTriangle = new Triangle(id, triangle);
                            triangles.Add(newTriangle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while getting triangles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
            return triangles;
        }
        public List<Polygon> GetPolygons()
        {
            List<Polygon> polygons = new List<Polygon>();
            connection.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT ST_asText(triangles) FROM mgeometry WHERE triangles IS NOT NULL ORDER BY id", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string wktGeometry = reader["st_astext"].ToString();
                    WKTReader readerGeometry = new WKTReader();
                    Geometry geometry = readerGeometry.Read(wktGeometry);

                    foreach (Coordinate coordinate in geometry.Coordinates)
                    {
                        if (geometry is Polygon polygon)
                        {
                            polygons.Add(polygon);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while getting meshes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
            return polygons;
        }
        public void RemoveColumn(string table, string column)
        {
            connection.Open();

            using (NpgsqlTransaction transaction = connection.BeginTransaction())
            {
                string sql = $"ALTER TABLE {table} DROP COLUMN {column}";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                {
                    Execute(cmd, "Removing column failed");
                }

                transaction.Commit();
            }

            connection.Close();
        }
        private void CreateTablesFrom(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found. Please try again.", "Getting SQL script failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlScript = File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(sqlScript))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlScript, connection))
                {
                    Execute(command, "Creating table failed");
                }
            }
        }

    }
    internal class Triangle
    {
        public int id;
        public string triangle;
        public Triangle(int id, string triangle)
        {
            this.id = id;
            this.triangle = triangle;
        }
    }
}