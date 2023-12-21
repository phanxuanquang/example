using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

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
            var connectionString = String.Format("Host={0};Port={1};Database={1};Username={2};Password={3}", Server_Box.Text, Port_Box.Text, Database_Box.Text, Username_Box.Text, Password_Box.Text);
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
    }
}
