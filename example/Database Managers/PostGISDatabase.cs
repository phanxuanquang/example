using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
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

        #region Insert Data
        [Obsolete]
        public void Insert(MGeometry geometry)
        {
            string command = "INSERT INTO Geometry (ID, ColorID, Transparency, Mesh) VALUES (@ID, @ColorID, @Transparency, @Mesh)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
            {
                executer.Parameters.AddWithValue("@ID", geometry.id);
                executer.Parameters.AddWithValue("@ColorID", geometry.color.id);
                executer.Parameters.AddWithValue("@Transparency", geometry.transparency);
                executer.Parameters.AddWithValue("@Mesh", JsonConvert.SerializeObject(geometry.mesh));

                //MemoryStream streamer = new MemoryStream();
                //using (BsonWriter writer = new BsonWriter(streamer))
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    serializer.Serialize(writer, geometry.mesh);
                //}
                //executer.Parameters.AddWithValue("@Mesh", Convert.ToBase64String(streamer.ToArray()));

                Execute(executer, "Cannot insert geometry");
            }
        }
        public void Insert(MColor color)
        {
            string command = "INSERT INTO Color (ID, Red, Green, Blue) VALUES (@ID, @Red, @Green, @Blue)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
            {
                executer.Parameters.AddWithValue("@ID", color.id);
                executer.Parameters.AddWithValue("@Red", color.red);
                executer.Parameters.AddWithValue("@Green", color.green);
                executer.Parameters.AddWithValue("@Blue", color.blue);

                Execute(executer, "Cannot insert colors!");
            }
        }
        public void Insert(MPropertyCategory propertyCategory)
        {
            string command = "INSERT INTO PropertyCategory (ID, DisplayName) VALUES (@ID, @DisplayName)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
            {
                executer.Parameters.AddWithValue("@ID", propertyCategory.id);
                executer.Parameters.AddWithValue("@DisplayName", propertyCategory.displayName);

                Execute(executer, "Cannot insert property category");
            }
        }
        public void Insert(MProperty property)
        {
            string command = "INSERT INTO Property (ID, Key, Value) VALUES (@ID, @Key, @Value)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
            {
                executer.Parameters.AddWithValue("@ID", property.id);
                executer.Parameters.AddWithValue("@Key", property.displayName);
                executer.Parameters.AddWithValue("@Value", property.value);

                Execute(executer, "Cannot insert property");
            }
        }
        public void Insert(MModel mModel)
        {
            string command = "INSERT INTO Model (ID, ParentModelID, DisplayName, GeometryID) VALUES (@ID, @ParentModelID, @DisplayName, @GeometryID)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
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
            string command = "INSERT INTO HasProperty (ModelID, PropertyCategoryID, PropertyID) VALUES (@ModelID, @PropertyCategoryID, @PropertyID)";
            using (NpgsqlCommand executer = new NpgsqlCommand(command, connection))
            {
                executer.Parameters.AddWithValue("@ModelID", model.id);
                executer.Parameters.AddWithValue("@PropertyCategoryID", propertyCategory.id);
                executer.Parameters.AddWithValue("@PropertyID", property.id);

                Execute(executer, "Cannot insert bridge table");
            }
        }
        #endregion
    }
}
