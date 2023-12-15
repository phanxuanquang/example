﻿using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Autodesk.Navisworks.Api;

namespace Viewer
{
    partial class ModelViewing : Form
    {
        public List<ModelItem> models;
        public ModelViewing()
        {
            InitializeComponent();
            models = new List<ModelItem>();
        }

        private void TreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ModelNode node)
            {
                PropertyCategoryTabs.TabPages.Clear();
                LoadPropertiesOf(node);
            }
        }

        private void LoadPropertiesOf(ModelNode node)
        {
            foreach (var propertyCategory in node.modelItem.PropertyCategories)
            {
                TabPage propertyCategoryTab = new TabPage(propertyCategory.DisplayName);

                DataGridView propertiesTable = new DataGridView();
                propertiesTable.Dock = DockStyle.Fill;
                propertiesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                propertiesTable.ReadOnly = true;
                foreach (var category in propertyCategory.Properties)
                {
                    DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                    newColumn.HeaderText = category.DisplayName; // Set the header text for the new column

                    newColumn.Name = category.Name;
                    propertiesTable.Columns.Add(newColumn);
                }

                propertyCategoryTab.Controls.Add(propertiesTable);
                PropertyCategoryTabs.TabPages.Add(propertyCategoryTab);
            }
        }

        private void ExportButton_Click(object sender, System.EventArgs e)
        {
            foreach (var model in models)
            {
                richTextBox.Text += model.DisplayName + "\n";
            }
            DatabaseExporter databaseExporter = new DatabaseExporter(models);
        }  
    }

    internal class DatabaseExporter
    {
        SQLiteConnection connection;
        public List<ModelItem> items = new List<ModelItem>();
        public DatabaseExporter(List<ModelItem> models)
        {
            items = models;
            string databaseName = @"D:\C++\Internship\SQLite\model.db";
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

        static Random random = new Random();
        static HashSet<string> generatedStrings = new HashSet<string>();

        /// <summary>
        /// Generate a unique ID with specific prefix
        /// </summary>
        /// <param name="prefix">The prefix which is reccommended with less than 5 characters</param>
        /// <returns></returns>
        string IDGeneratedWithPrefix(string prefix)
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
        int GeneratedNumber()
        {
            random = new Random();
            return random.Next(256);
        }
    }
}