using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SQLiteExample
{
    /// <summary>
    /// Export model data into a SQL database using SQLite
    /// </summary>
    internal class DatabaseExporter
    {
        private SQLiteConnection connection;
        public DatabaseExporter()
        {
            connection = new SQLiteConnection("DataSource=Model.db");
            try
            {
                connection.Open();
                //CreateTables("SQLite.sql");
                for (int i = 0; i < 100; i++)
                {
                    InsertColor(IDGeneratedWithPrefix("COL"), GeneratedNumber(), GeneratedNumber(), GeneratedNumber());
                }
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
        /// <summary>
        /// Create tables from SQL script file.
        /// </summary>
        private void CreateTables(string filePath)
        {
            try
            {
                SQLiteCommand executer = new SQLiteCommand(GetScriptFrom(filePath), connection);
                executer.ExecuteNonQuery();

                MessageBox.Show("Tables are created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creating table failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertColor(string ID, int Red, int Green, int Blue)
        {
            try
            {
                connection.Open();
                string sqlCommand = String.Format("INSERT INTO 'Color' ('ID', 'Red', 'Green', 'Blue') VALUES ('{0}', {1}, {2}, {3})", ID, Red, Green, Blue);
                SQLiteCommand executer = new SQLiteCommand(sqlCommand, connection);
                executer.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Obtain the script from a .sql file and convert into string data type
        /// </summary>
        /// <param name="filePath">Path of the .sql file</param>
        /// <returns>SQL script</returns>
        private string GetScriptFrom(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File not found. Please try again.", "Getting SQL script failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sqlScript = File.ReadAllText(filePath);

                return sqlScript;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reading SQL script failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
        }

        private static Random random = new Random();
        private static HashSet<string> generatedStrings = new HashSet<string>();

        /// <summary>
        /// Generate a unique ID with specific prefix
        /// </summary>
        /// <param name="prefix">The prefix which is reccommended with less than 5 characters</param>
        /// <returns></returns>
        private string IDGeneratedWithPrefix(string prefix)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[16 - prefix.Length - 1];
            string randomString;

            do
            {
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                randomString = new string(stringChars);
            } while (!generatedStrings.Add(randomString)); // Keep generating until a unique string is generated

            return prefix.ToUpper() + "-" + randomString;
        }

        /// <summary>
        /// Generate a unique number in range [0:255]
        /// </summary>
        /// <returns></returns>
        private int GeneratedNumber()
        {
            Random random = random = new Random();
            return random.Next(256);
        }
    }
}
