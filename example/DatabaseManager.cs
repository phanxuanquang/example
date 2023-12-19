using Autodesk.Navisworks.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ModelViewer
{
    internal class DatabaseManager
    {
        public SQLiteConnection connection;
        public List<ModelItem> items = new List<ModelItem>();
        public DatabaseManager(List<ModelItem> models)
        {
            items = models;
            string databaseName = @"D:\C++\Internship\SQLite\model2.db";
            connection = new SQLiteConnection($"Data Source={databaseName}");
            try
            {
                connection.Open();
                CreateTablesFrom(@"D:\C++\Internship\example\example\bin\Debug\SQLite.sql");
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
        private void CreateTablesFrom(string filePath)
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

        #region Insert Data
        /// <summary>
        /// Insert color of a model to SQLite database
        /// </summary>
        /// <param name="color">The color of the model to input</param>
        public void Insert(MColor color)
        {
            string insertQuery = "INSERT INTO Color (ID, Red, Green, Blue) VALUES (@ID, @Red, @Green, @Blue)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ID", color.id);
                executer.Parameters.AddWithValue("@Red", color.red);
                executer.Parameters.AddWithValue("@Green", color.green);
                executer.Parameters.AddWithValue("@Blue", color.blue);

                Execute(executer, "Cannot insert colors!");
            }
        }

        [Obsolete]
        public void Insert(MGeometry geometry)
        {
            string insertQuery = "INSERT INTO Geometry (ID, ColorID, Transparency, Mesh) VALUES (@ID, @ColorID, @Transparency, @Mesh)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ID", geometry.id);
                executer.Parameters.AddWithValue("@ColorID", geometry.color.id);
                executer.Parameters.AddWithValue("@Transparency", geometry.transparency);
                //executer.Parameters.AddWithValue("@Mesh", JsonConvert.SerializeObject(geometry.mesh));

                MemoryStream streamer = new MemoryStream();
                using (BsonWriter writer = new BsonWriter(streamer))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, geometry.mesh);
                }
                executer.Parameters.AddWithValue("@Mesh", Convert.ToBase64String(streamer.ToArray()));

                Execute(executer, "Cannot insert geometry");
            }
        }
        public void Insert(MPropertyCategory propertyCategory)
        {
            string insertQuery = "INSERT INTO PropertyCategory (ID, DisplayName) VALUES (@ID, @DisplayName)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ID", propertyCategory.id);
                executer.Parameters.AddWithValue("@DisplayName", propertyCategory.displayName);

                Execute(executer, "Cannot insert property category");
            }
        }
        public void Insert(MProperty property)
        {
            string insertQuery = "INSERT INTO Property (ID, Key, Value) VALUES (@ID, @Key, @Value)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ID", property.id);
                executer.Parameters.AddWithValue("@Key", property.displayName);
                executer.Parameters.AddWithValue("@Value", property.value);

                Execute(executer, "Cannot insert property");
            }
        }
        public void Insert(MModel mModel)
        {
            string insertQuery = "INSERT INTO Model (ID, ParentModelID, DisplayName, GeometryID) VALUES (@ID, @ParentModelID, @DisplayName, @GeometryID)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ID", mModel.id);
                executer.Parameters.AddWithValue("@ParentModelID", mModel.parentModelID);
                executer.Parameters.AddWithValue("@DisplayName", mModel.displayName);
                if (mModel.geometry != null)
                {
                    executer.Parameters.AddWithValue("@GeometryID", mModel.geometry.id);
                }
                else
                {
                    executer.Parameters.AddWithValue("@GeometryID", null);
                }

                Execute(executer, "Cannot insert model");
            }
        }
        public void Insert(MModel model, MPropertyCategory propertyCategory, MProperty property)
        {
            string insertQuery = "INSERT INTO HasProperty (ModelID, PropertyCategoryID, PropertyID) VALUES (@ModelID, @PropertyCategoryID, @PropertyID)";
            using (SQLiteCommand executer = new SQLiteCommand(insertQuery, connection))
            {
                executer.Parameters.AddWithValue("@ModelID", model.id);
                executer.Parameters.AddWithValue("@PropertyCategoryID", propertyCategory.id);
                executer.Parameters.AddWithValue("@PropertyID", property.id);

                Execute(executer, "Cannot insert bridge table");
            }
        }
        #endregion

        private void Execute(SQLiteCommand executer, string error)
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
