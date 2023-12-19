using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model2OBJ
{
    internal class DatabaseManager
    {
        public SQLiteConnection connection;
        public List<Point3D> items = new List<Point3D>();
        public DatabaseManager(List<Point3D> vertexes)
        {
            items = vertexes;
            string databaseName = @"D:\C++\Internship\SQLite\model2.db";
            connection = new SQLiteConnection($"Data Source={databaseName}");
            try
            {
                connection.Open();
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
