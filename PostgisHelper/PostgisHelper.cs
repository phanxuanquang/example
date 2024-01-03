using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;

namespace PostgisHelper
{
    /// <summary>
    /// Provide standard PostGIS functions and more
    /// </summary>
    internal partial class PostgisHelper
    {
        private NpgsqlConnection connection;
        /// <summary>
        /// Initializes a new helper with connection credential.
        /// </summary>
        /// <param name="server">The server name or IP address (default is "localhos"t).</param>
        /// <param name="port">The port number for the database connection (default is 5432).</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="username">The username for authentication (default is "postgis").</param>
        /// <param name="password">The password for authentication.</param>
        public PostgisHelper(string server, int port, string database, string username, string password)
        {
            string connectionString = $"Host={server};Port={port};Database={database};Username={username};Password={password}";
            connection = new NpgsqlConnection(connectionString);
            ActivatePostGIS();
        }
        private void Execute(string sqlCommand, string errorMessage)
        {
            if (connection != null)
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = sqlCommand;

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Connection is not intilized", "Cannot execute SQL command", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActivatePostGIS()
        {
            string sqlCommand = "CREATE EXTENSION IF NOT EXISTS postgis;";
            Execute(sqlCommand, "Cannot activate PostGIS extension");
        }
        /// <summary>
        /// Creates tables from provided a file that contains SQL script
        /// </summary>
        /// <param name="filePath">Path to the SQL script file</param>
        public void CreateTablesFrom(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlScript = File.ReadAllText(filePath);
            Execute(sqlScript, "Cannot create tables");
        }

        #region Controling functions
        /// <summary>
        /// Adds a geometry column to a table in the database.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="columnName">The name of the column to be added.</param>
        /// <param name="srid">The spatial reference system identifier (SRID).</param>
        /// <param name="type">The type of geometry column to be added.</param>
        /// <param name="dimension">The dimension of the geometry (default is 3).</param>
        public void AddGeometryColumn(string tableName, string columnName, int srid, string type, int dimension = 3)
        {
            string sqlCommand = $"SELECT AddGeometryColumn('{tableName}','{columnName}',{srid},'{type}',{dimension});";
            Execute(sqlCommand, "Cannot add geometry column");
        }

        /// <summary>
        /// Drops a geometry column from a table in the database.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="columnName">The name of the column to be dropped.</param>
        public void DropGeometryColumn(string tableName, string columnName)
        {
            string sqlCommand = $"SELECT DropGeometryColumn('{tableName}','{columnName}');";
            Execute(sqlCommand, "Cannot drop geometry column");
        }

        /// <summary>
        /// Drops a geometry table from the database.
        /// </summary>
        /// <param name="tableName">The name of the table to be dropped.</param>
        public void DropGeometryTable(string tableName)
        {
            string sqlCommand = $"SELECT DropGeometryTable('{tableName}');";
            Execute(sqlCommand, "Cannot drop geometry column");
        }

        /// <summary>
        /// Creates an index on a table column in the database.
        /// </summary>
        /// <param name="indexName">The name of the index to be created.</param>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="columnName">The name of the column on which the index is to be created.</param>
        /// <param name="isColumnTheGeometryFormat">Specifies if the column is in the geometry format (default is false).</param>
        public void CreateIndex(string indexName, string tableName, string columnName, bool isColumnTheGeometryFormat = false)
        {
            string sqlCommand = String.Empty;
            if (isColumnTheGeometryFormat)
            {
                sqlCommand = $"CREATE INDEX {indexName} on {tableName} USING GIST({columnName});";
            }
            else
            {
                sqlCommand = $"CREATE INDEX {indexName} on {tableName}({columnName});";
            }

            connection.Open();

            using (NpgsqlTransaction transaction = connection.BeginTransaction())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlCommand;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cannot create index", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                transaction.Commit();
            }

            connection.Close();
        }

        #endregion

        #region Converter
        /// <summary>
        /// Generates a geometry from Well-Known Text (WKT) representation.
        /// </summary>
        /// <param name="text">The Well-Known Text representation of the geometry.</param>
        /// <returns>The generated geometry.</returns>
        public Geometry ST_GeometryFromText(string text)
        {
            WKTReader readerGeometry = new WKTReader();
            Geometry geometry = null;
            try
            {
                geometry = readerGeometry.Read(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot generate geometry from text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return geometry;
        }

        /// <summary>
        /// Generates the Well-Known Text (WKT) representation of a geometry.
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <returns>The Well-Known Text representation of the geometry.</returns>
        public string ST_AsText(Geometry geometry)
        {
            string text = String.Empty;

            try
            {
                text = geometry.AsText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot generate text from geometry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return text;
        }

        #endregion

        #region Checker
        /// <summary>
        /// Determines whether two geometries are equal.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries are equal, otherwise false.</returns>
        public bool ST_Equals(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Equals(geometry2);
        }

        /// <summary>
        /// Determines whether two geometries are disjoint (have no intersection).
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries are disjoint, otherwise false.</returns>
        public bool ST_Disjoint(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Disjoint(geometry2);
        }

        /// <summary>
        /// Determines whether two geometries intersect.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries intersect, otherwise false.</returns>
        public bool ST_Intersects(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Intersects(geometry2);
        }

        /// <summary>
        /// Determines whether two geometries touch (share a common boundary point).
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries touch, otherwise false.</returns>
        public bool ST_Touches(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Touches(geometry2);
        }

        /// <summary>
        /// Determines whether two geometries overlap.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries overlap, otherwise false.</returns>
        public bool ST_Overlaps(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Overlaps(geometry2);
        }

        /// <summary>
        /// Determines whether two geometries cross (have some but not all interior points in common).
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if the geometries cross, otherwise false.</returns>
        public bool ST_Crosses(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Crosses(geometry2);
        }

        /// <summary>
        /// Determines whether geometry1 is within geometry2.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if geometry1 is within geometry2, otherwise false.</returns>
        public bool ST_Within(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Within(geometry2);
        }

        /// <summary>
        /// Determines whether geometry1 contains geometry2.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>True if geometry1 contains geometry2, otherwise false.</returns>
        public bool ST_Contains(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Contains(geometry2);
        }

        #endregion

        /// <summary>
        /// Gets the distance between two geometries.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>The distance between the two geometries.</returns>
        public double ST_Distance(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Distance(geometry2);
        }

        /// <summary>
        /// Gets the area of a geometry.
        /// </summary>
        /// <param name="geometry">The geometry.</param>
        /// <returns>The area of the geometry.</returns>
        public double ST_Area(Geometry geometry)
        {
            return geometry.Area;
        }

        /// <summary>
        /// Gets the length of a geometry.
        /// </summary>
        /// <param name="geometry">The geometry.</param>
        /// <returns>The length of the geometry.</returns>
        public double ST_Length(Geometry geometry)
        {
            return geometry.Length;
        }

        /// <summary>
        /// Computes the intersection of two geometries.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>The intersection geometry.</returns>
        public Geometry ST_Intersection(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Intersection(geometry2);
        }

        /// <summary>
        /// Computes the difference of two geometries.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>The difference geometry.</returns>
        public Geometry ST_Difference(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Difference(geometry2);
        }

        /// <summary>
        /// Computes the union of two geometries.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>The union geometry.</returns>
        public Geometry ST_Union(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.Union(geometry2);
        }

        /// <summary>
        /// Computes the symmetric difference of two geometries.
        /// </summary>
        /// <param name="geometry1">The first geometry.</param>
        /// <param name="geometry2">The second geometry.</param>
        /// <returns>The symmetric difference geometry.</returns>
        public Geometry ST_SymDifference(Geometry geometry1, Geometry geometry2)
        {
            return geometry1.SymmetricDifference(geometry2);
        }

        /// <summary>
        /// Computes the buffer of a geometry with specified parameters.
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <param name="radius">The buffer radius.</param>
        /// <param name="quadrantSegments">The number of quadrant segments.</param>
        /// <param name="endcap">The style of endcap (round, flat, square).</param>
        /// <returns>The buffered geometry.</returns>
        public Geometry ST_Buffer(Geometry geometry, double radius, int quadrantSegments = 8, string endcap = "round")
        {
            NetTopologySuite.Operation.Buffer.EndCapStyle endCapStyle;
            switch (endcap.ToLower())
            {
                case "round":
                    endCapStyle = NetTopologySuite.Operation.Buffer.EndCapStyle.Round;
                    break;
                case "flat":
                    endCapStyle = NetTopologySuite.Operation.Buffer.EndCapStyle.Flat;
                    break;
                case "square":
                    endCapStyle = NetTopologySuite.Operation.Buffer.EndCapStyle.Square;
                    break;
                default:
                    MessageBox.Show("Endcap style does not exist", "Cannot create endcap style", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }

            return geometry.Buffer(radius, quadrantSegments, endCapStyle);
        }

        /// <summary>
        /// Gets the geometry type of the provided geometry.
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <returns>The Geometry Type of the input geometry.</returns>
        public string ST_GeometryType(Geometry geometry)
        {
            return geometry.GeometryType;
        }

        /// <summary>
        /// Checks if the provided geometry is valid.
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <returns>True if the geometry is valid, otherwise false.</returns>
        public bool ST_IsValid(Geometry geometry)
        {
            return geometry.IsValid;
        }

        /// <summary>
        /// Gets the Open Geospatial Consortium (OGC) geometry type of the provided geometry.
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <returns>The OGC geometry type of the input geometry.</returns>
        public OgcGeometryType GeometryType(Geometry geometry)
        {
            return geometry.OgcGeometryType;
        }

        /// <summary>
        /// Creates a valid representation of a given invalid geometry without losing any of the input vertices. 
        /// </summary>
        /// <param name="geometry">The input geometry.</param>
        /// <returns></returns>
        public Geometry ST_MakeValid(Geometry geometry)
        {
            if (ST_IsValid(geometry))
            {
                return geometry;
            }
            return NetTopologySuite.Geometries.Utilities.GeometryFixer.Fix(geometry);
        }
    }
}
