using Aspose.ThreeD;
using NetTopologySuite.Geometries;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PostgisUtilities;


namespace PostGISTest
{
    public partial class TestForm : Form
    {
        PostgresDatabase postGISDatabase;
        private string connectionString;
        public TestForm()
        {
            InitializeComponent();
        }
        private List<Table> GetDataFrom(string dataSource = @"D:\C++\Internship\SQLite\ModelDatabase.db")
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dataSource}"))
            {
                connection.Open();

                List<Table> tables = new List<Table>();

                DataTable tablesSchema = connection.GetSchema("Tables");

                foreach (DataRow row in tablesSchema.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    Table table = new Table { name = tableName };

                    DataTable columns = connection.GetSchema("Columns", new[] { null, null, tableName });
                    List<string> columnNames = columns.AsEnumerable().Select(col => col.Field<string>("COLUMN_NAME")).ToList();
                    table.columns.AddRange(columnNames);

                    string selectQuery = $"SELECT * FROM {tableName}";
                    SQLiteCommand command = new SQLiteCommand(selectQuery, connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> fieldValues = new List<string>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                object value = reader[i];
                                string valueString = (value == DBNull.Value || value == null) ? "NULL" : (value is string) ? $"'{value}'" : value.ToString();
                                fieldValues.Add(valueString);
                            }

                            table.rows.Add(string.Join(", ", fieldValues));
                        }
                    }

                    tables.Add(table);
                }

                connection.Close();

                return tables;
            }
        }
        private void ExportGLB_glTF(string OBJpath)
        {
            try
            {
                Scene scene = Scene.FromFile(OBJpath);
                scene.Save(OBJpath.Replace("obj", "gltf"));
                scene.Save(OBJpath.Replace("obj", "glb"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exporting to GLB and glTF files failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportOBJ(string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                Mesh combinedMesh = new Mesh();
                combinedMesh.CreateMergedMeshesFrom(postGISDatabase.GetMeshes());

                try
                {
                    foreach (Vertex vertex in combinedMesh.vertexes)
                    {
                        writer.WriteLine(String.Format("v {0} {1} {2}", vertex.x, vertex.y, vertex.z));
                    }

                    for (int i = 0; i < combinedMesh.faceIndexes.Count - 3; i = i + 3)
                    {
                        writer.WriteLine(String.Format("f {0} {1} {2}", combinedMesh.faceIndexes[i] + 1, combinedMesh.faceIndexes[i + 1] + 1, combinedMesh.faceIndexes[i + 2] + 1));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exporting to OBJ file failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                writer.Close();
            }
        }

        #region Button Events
        private void LoadSQLiteDB_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectDatabaseDialog = new OpenFileDialog();
            selectDatabaseDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            selectDatabaseDialog.Title = "Select a SQLite database to convert";

            DialogResult result = selectDatabaseDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = selectDatabaseDialog.FileName;
                SQLitePath_Box.Text = selectedFilePath;
                Convert_Btn.Enabled = true;
                Database_Box.Focus();
            }
        }
        private void SQLitePath_Box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadSQLiteDB_Button_Click(sender, e);
        }
        private void Convert_Btn_Click(object sender, EventArgs e)
        {
            if (Server_Box.Text != String.Empty && Port_Box.Text != String.Empty && Database_Box.Text != String.Empty && Username_Box.Text != String.Empty && Password_Box.Text != String.Empty)
            {
                connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
                postGISDatabase = new PostgresDatabase(connectionString);

                postGISDatabase.InitTables();
                try
                {
                    postGISDatabase.Insert(GetDataFrom(SQLitePath_Box.Text));

                    try
                    {
                        List<ExtendedMesh> extendedMeshes = postGISDatabase.GetMeshes();
                        foreach (ExtendedMesh item in extendedMeshes)
                        {
                            if (item.mesh != null)
                            {
                                postGISDatabase.Insert(item.mesh, item.id);
                            }
                        }
                        ExportOBJ_Btn.Enabled = true;
                        ExportJSON_Btn.Enabled = true;
                        //postGISDatabase.RemoveColumn("MGeometry", "Mesh");
                    }
                    catch
                    {
                        // We can assume selected database does not have geometry
                    }

                    MessageBox.Show("Inserting data completely", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Converting to PostGIS failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input credential of the PostGIS database and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Database_Box.Focus();
            }
        }
        private void ExportAsObjects_Btn_Click(object sender, EventArgs e)
        {
            connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
            postGISDatabase = new PostgresDatabase(connectionString);

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Export to 3D object file";
            saveDialog.Filter = "3D Object (*.obj)|*.obj";
            saveDialog.FileName = $"{DateTime.Now:MMdd-HHmm}";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string outputLocation = saveDialog.FileName;

                try
                {
                    ExportOBJ(outputLocation);
                    ExportGLB_glTF(outputLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exporting to OBJ failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Exporting to 3D object file completely.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportJSON_Btn_Click(object sender, EventArgs e)
        {
            connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
            postGISDatabase = new PostgresDatabase(connectionString);

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Export to JSON file";
            saveDialog.Filter = "JSON files (*.json)|*.json";
            saveDialog.FileName = String.Format("Navisworks Model - {0}", DateTime.Now.ToString("MMdd-HHmm"));
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string location = saveDialog.FileName;

                using (StreamWriter writer = new StreamWriter(location))
                {
                    Mesh combinedMesh = new Mesh();

                    try
                    {
                        combinedMesh.CreateMergedMeshesFrom(postGISDatabase.GetMeshes());

                        foreach (Vertex ok in combinedMesh.vertexes)
                        {
                            writer.WriteLine(ok.ToString() + ",");
                        }

                        //writer.WriteLine(JsonConvert.SerializeObject(combinedMesh, Formatting.Indented));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exporting to .JSON failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    writer.Close();
                }

                MessageBox.Show("Exporting to JSON file completely.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void QueryCommand_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Test_Btn_Click(sender, e);
            }
        }
        private void ResultTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = ResultTable.Rows[e.RowIndex].Cells[e.ColumnIndex];

                Clipboard.SetText(selectedCell.Value.ToString());

                MessageBox.Show("Cell value copied", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void WriteAllCoords()
        {
            connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
            postGISDatabase = new PostgresDatabase(connectionString);

            using (StreamWriter writer = new StreamWriter(@"D:\C++\Internship\SQLite\output.txt"))
            {
                Mesh combinedMesh = new Mesh();
                List<Polygon> polygons = postGISDatabase.GetPolygons();

                try
                {
                    foreach (Polygon polygon in polygons)
                    {
                        foreach (Coordinate coord in polygon.Coordinates)
                        {
                            writer.WriteLine($"{coord.X} {coord.Y} {coord.Z},");
                        }
                    }
                    MessageBox.Show("Writting coordinates completely", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    polygons.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Writting coordinates failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                writer.Close();
            }
        }
        private void QueryData()
        {
            connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
            string sqlQuery = QueryCommand_Box.Text;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                {
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        ResultTable.DataSource = dataTable;

                        #region Table Style Format
                        foreach (DataGridViewColumn column in ResultTable.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

                            column.HeaderText = column.HeaderText.ToUpper();
                        }
                        ResultTable.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ResultTable.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                        ResultTable.EnableHeadersVisualStyles = false;
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Querying data failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Test_Btn_Click(object sender, EventArgs e)
        {
            PostgisHelper helper = new PostgisHelper("localhost", 5432, "f", "postgres", "137925");
            var geometry = helper.SelectGeometryById("mgeometry", "triangles", "8");
            //Output_Box.Text = helper.ST_AsText(geometry);
        }
    }
}
