using System;
using System.Collections.Generic;
using System.Data;
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
            OpenFileDialog selectDatabaseDialog = new OpenFileDialog();
            selectDatabaseDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            selectDatabaseDialog.Title = "Select a SQLite database to convert";

            DialogResult result = selectDatabaseDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = selectDatabaseDialog.FileName;
                SQLitePath_Box.Text = selectedFilePath;
            }
        }

        private void Convert_Btn_Click(object sender, EventArgs e)
        {
            if (Server_Box.Text != String.Empty && Port_Box.Text != String.Empty && Database_Box.Text != String.Empty && Username_Box.Text != String.Empty && Password_Box.Text != String.Empty)
            {
                var connectionString = $"Host={Server_Box.Text};Port={Port_Box.Text};Database={Database_Box.Text};Username={Username_Box.Text};Password={Password_Box.Text}";
                PostGISDatabase postGISDatabase = new PostGISDatabase(connectionString);

                try
                {
                    postGISDatabase.InsertDataFrom(GetDataFrom(SQLitePath_Box.Text));

                    try {
                        List<ExtendedMesh> extendedMeshes = postGISDatabase.GetMeshes();
                        foreach (ExtendedMesh item in extendedMeshes)
                        {
                            if (item.mesh != null)
                            {
                                postGISDatabase.InsertMeshFrom(item.mesh, item.id);
                            }
                        }
                        postGISDatabase.RemoveColumn("MGeometry", "Mesh");
                    }
                    catch
                    {
                        // We can assume select database does not have geometry
                    }

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

        private List<Table> GetDataFrom(string dataSource = @"D:\C++\Internship\SQLite\ModelDatabase.db")
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dataSource}"))
            {
                connection.Open();

                List<Table> tables = new List<Table>();

                foreach (DataRow row in connection.GetSchema("Tables").Rows)
                {
                    Table table = new Table();

                    table.name = row["TABLE_NAME"].ToString();

                    string selectQuery = $"SELECT * FROM {table.name}";

                    DataTable columns = connection.GetSchema("Columns", new[] { null, null, table.name });

                    foreach (DataRow columnRow in columns.Rows)
                    {
                        table.columns.Add(columnRow["COLUMN_NAME"].ToString());
                    }

                    SQLiteDataReader reader = (new SQLiteCommand(selectQuery, connection)).ExecuteReader();

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
    }
}
