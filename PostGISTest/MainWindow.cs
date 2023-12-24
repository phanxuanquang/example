using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PostGISTest
{

    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void LoadSQLiteDB_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                SQLitePath_Box.Text = selectedFilePath;
            }
        }

        private void Convert_Btn_Click(object sender, EventArgs e)
        {
            if (Server_Box.Text != String.Empty && Port_Box.Text != String.Empty && Database_Box.Text != String.Empty && Username_Box.Text != String.Empty && Password_Box.Text != String.Empty)
            {
                var connectionString = String.Format("Host={0};Port={1};Database={2};Username={3};Password={4}", Server_Box.Text, Port_Box.Text, Database_Box.Text, Username_Box.Text, Password_Box.Text);
                PostGISDatabase postGISDatabase = new PostGISDatabase(connectionString);
                try
                {
                    postGISDatabase.InsertDataFrom(getExtractedTables(SQLitePath_Box.Text));
                    MessageBox.Show("Inserting data completely", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input credential of the PostGIS database and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Database_Box.Focus();
            }

            
        }

        private List<Table> getExtractedTables(string dataSource = @"D:\C++\Internship\SQLite\ModelDatabase.db")
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dataSource}"))
            {
                connection.Open();

                List<Table> tables = new List<Table>();

                foreach (DataRow tableRow in connection.GetSchema("Tables").Rows)
                {
                    Table table = new Table();

                    table.name = tableRow["TABLE_NAME"].ToString();


                    string selectQuery = $"SELECT * FROM {table.name}";

                    DataTable columns = connection.GetSchema("Columns", new[] { null, null, table.name });

                    foreach (DataRow columnRow in columns.Rows)
                    {
                        string columnName = columnRow["COLUMN_NAME"].ToString();
                        table.columns.Add(columnName);
                    }

                    SQLiteCommand command = new SQLiteCommand(selectQuery, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

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
                    reader.Close();

                    tables.Add(table);
                }

                connection.Close();

                return tables;

            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var connectionString = String.Format("Host={0};Port={1};Database={2};Username={3};Password={4}", Server_Box.Text, Port_Box.Text, Database_Box.Text, Username_Box.Text, Password_Box.Text);
            PostGISDatabase postGISDatabase = new PostGISDatabase(connectionString);
            try
            {
                List<GeometryMesh> meshes = postGISDatabase.GetMeshes();
                foreach (GeometryMesh mesh in meshes)
                {
                    richTextBox.Text += JsonConvert.SerializeObject(mesh.mesh) + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
