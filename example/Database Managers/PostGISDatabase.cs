using Npgsql;
using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ModelViewer
{
    internal class PostGISDatabase
    {
        public NpgsqlConnection connection { get; set; }

        public PostGISDatabase(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                CreateTablesFrom("SQLite.sql");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateTablesFrom(string filePath)
        {
            string sqlScript = GetScriptFrom(filePath);

            if (!string.IsNullOrEmpty(sqlScript))
            {
                using (var command = new NpgsqlCommand(sqlScript, connection))
                {
                    Execute(command, "Creating table failed");
                }
            }
        }

        private string GetScriptFrom(string filePath)
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
    }
}
