using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostGISTest
{
    internal class PostGISDatabase
    {
        public NpgsqlConnection connection { get; set; }
        public PostGISDatabase(string conncectionString)
        {
            connection = new NpgsqlConnection(conncectionString);
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
                                MessageBox.Show(cmd.CommandText + "\n" + ex.Message);
                                return;
                            }
                        }
                    }
                }

                transaction.Commit();
            }
            
            connection.Close();
        }
    }
}
