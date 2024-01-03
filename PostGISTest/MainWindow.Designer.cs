namespace PostGISTest
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Convert_Btn = new System.Windows.Forms.Button();
            this.SQLitePath_Box = new System.Windows.Forms.TextBox();
            this.LoadSQLiteDB_Button = new System.Windows.Forms.Button();
            this.Server_Box = new System.Windows.Forms.TextBox();
            this.Port_Box = new System.Windows.Forms.TextBox();
            this.Database_Box = new System.Windows.Forms.TextBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.QueryCommand_Box = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportOBJ_Btn = new System.Windows.Forms.Button();
            this.ExportJSON_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ResultTable = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Convert_Btn.Enabled = false;
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert_Btn.Location = new System.Drawing.Point(695, 194);
            this.Convert_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Convert_Btn.Name = "Convert_Btn";
            this.Convert_Btn.Size = new System.Drawing.Size(261, 89);
            this.Convert_Btn.TabIndex = 0;
            this.Convert_Btn.Text = "Convert to PostGIS";
            this.Convert_Btn.UseVisualStyleBackColor = true;
            this.Convert_Btn.Click += new System.EventHandler(this.Convert_Btn_Click);
            // 
            // SQLitePath_Box
            // 
            this.SQLitePath_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SQLitePath_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLitePath_Box.Location = new System.Drawing.Point(35, 21);
            this.SQLitePath_Box.Margin = new System.Windows.Forms.Padding(2);
            this.SQLitePath_Box.Name = "SQLitePath_Box";
            this.SQLitePath_Box.ReadOnly = true;
            this.SQLitePath_Box.Size = new System.Drawing.Size(1866, 48);
            this.SQLitePath_Box.TabIndex = 1;
            this.toolTip.SetToolTip(this.SQLitePath_Box, "Path to the selected .db file");
            this.SQLitePath_Box.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SQLitePath_Box_MouseDoubleClick);
            // 
            // LoadSQLiteDB_Button
            // 
            this.LoadSQLiteDB_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoadSQLiteDB_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadSQLiteDB_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LoadSQLiteDB_Button.Location = new System.Drawing.Point(421, 194);
            this.LoadSQLiteDB_Button.Margin = new System.Windows.Forms.Padding(2);
            this.LoadSQLiteDB_Button.Name = "LoadSQLiteDB_Button";
            this.LoadSQLiteDB_Button.Size = new System.Drawing.Size(261, 89);
            this.LoadSQLiteDB_Button.TabIndex = 2;
            this.LoadSQLiteDB_Button.Text = "Select Database";
            this.LoadSQLiteDB_Button.UseVisualStyleBackColor = true;
            this.LoadSQLiteDB_Button.Click += new System.EventHandler(this.LoadSQLiteDB_Button_Click);
            // 
            // Server_Box
            // 
            this.Server_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Server_Box.BackColor = System.Drawing.Color.White;
            this.Server_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Box.Location = new System.Drawing.Point(28, 38);
            this.Server_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(187, 45);
            this.Server_Box.TabIndex = 3;
            this.Server_Box.Text = "localhost";
            this.toolTip.SetToolTip(this.Server_Box, "Server | PostGIS Database");
            // 
            // Port_Box
            // 
            this.Port_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Port_Box.BackColor = System.Drawing.Color.White;
            this.Port_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Box.Location = new System.Drawing.Point(238, 38);
            this.Port_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Port_Box.Name = "Port_Box";
            this.Port_Box.Size = new System.Drawing.Size(187, 45);
            this.Port_Box.TabIndex = 4;
            this.Port_Box.Text = "5432";
            this.toolTip.SetToolTip(this.Port_Box, "Port | PostGIS Database");
            // 
            // Database_Box
            // 
            this.Database_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Database_Box.BackColor = System.Drawing.Color.White;
            this.Database_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database_Box.Location = new System.Drawing.Point(449, 38);
            this.Database_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Database_Box.Name = "Database_Box";
            this.Database_Box.Size = new System.Drawing.Size(187, 45);
            this.Database_Box.TabIndex = 5;
            this.Database_Box.Text = "e";
            this.toolTip.SetToolTip(this.Database_Box, "Database Name | PostGIS Database");
            // 
            // Password_Box
            // 
            this.Password_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Password_Box.BackColor = System.Drawing.Color.White;
            this.Password_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Box.Location = new System.Drawing.Point(868, 38);
            this.Password_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(187, 45);
            this.Password_Box.TabIndex = 6;
            this.Password_Box.Text = "137925";
            this.toolTip.SetToolTip(this.Password_Box, "Password | PostGIS Database");
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Username_Box
            // 
            this.Username_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Username_Box.BackColor = System.Drawing.Color.White;
            this.Username_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Box.Location = new System.Drawing.Point(658, 38);
            this.Username_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(187, 45);
            this.Username_Box.TabIndex = 7;
            this.Username_Box.Text = "postgres";
            this.toolTip.SetToolTip(this.Username_Box, "Username | PostGIS Database");
            // 
            // QueryCommand_Box
            // 
            this.QueryCommand_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryCommand_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryCommand_Box.Location = new System.Drawing.Point(30, 303);
            this.QueryCommand_Box.Margin = new System.Windows.Forms.Padding(2);
            this.QueryCommand_Box.Name = "QueryCommand_Box";
            this.QueryCommand_Box.Size = new System.Drawing.Size(1642, 48);
            this.QueryCommand_Box.TabIndex = 13;
            this.toolTip.SetToolTip(this.QueryCommand_Box, "Enter your SQL query here");
            this.QueryCommand_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QueryCommand_Box_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.Database_Box);
            this.groupBox1.Controls.Add(this.Server_Box);
            this.groupBox1.Controls.Add(this.Username_Box);
            this.groupBox1.Controls.Add(this.Port_Box);
            this.groupBox1.Controls.Add(this.Password_Box);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(426, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1083, 95);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PostgreSQL Credential";
            // 
            // ExportOBJ_Btn
            // 
            this.ExportOBJ_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ExportOBJ_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportOBJ_Btn.Location = new System.Drawing.Point(969, 194);
            this.ExportOBJ_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ExportOBJ_Btn.Name = "ExportOBJ_Btn";
            this.ExportOBJ_Btn.Size = new System.Drawing.Size(261, 89);
            this.ExportOBJ_Btn.TabIndex = 9;
            this.ExportOBJ_Btn.Text = "Export to 3D object";
            this.ExportOBJ_Btn.UseVisualStyleBackColor = true;
            this.ExportOBJ_Btn.Click += new System.EventHandler(this.ExportAsObjects_Btn_Click);
            // 
            // ExportJSON_Btn
            // 
            this.ExportJSON_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ExportJSON_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportJSON_Btn.Location = new System.Drawing.Point(1247, 194);
            this.ExportJSON_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ExportJSON_Btn.Name = "ExportJSON_Btn";
            this.ExportJSON_Btn.Size = new System.Drawing.Size(261, 89);
            this.ExportJSON_Btn.TabIndex = 10;
            this.ExportJSON_Btn.Text = "Export to JSON";
            this.ExportJSON_Btn.UseVisualStyleBackColor = true;
            this.ExportJSON_Btn.Click += new System.EventHandler(this.ExportJSON_Btn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1687, 302);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Test_Btn_Click);
            // 
            // ResultTable
            // 
            this.ResultTable.AllowUserToAddRows = false;
            this.ResultTable.AllowUserToDeleteRows = false;
            this.ResultTable.AllowUserToOrderColumns = true;
            this.ResultTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultTable.Location = new System.Drawing.Point(30, 371);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.ReadOnly = true;
            this.ResultTable.RowHeadersWidth = 92;
            this.ResultTable.RowTemplate.Height = 28;
            this.ResultTable.Size = new System.Drawing.Size(1871, 618);
            this.ResultTable.TabIndex = 14;
            this.ResultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultTable_CellDoubleClick);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1928, 1001);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.QueryCommand_Box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExportJSON_Btn);
            this.Controls.Add(this.ExportOBJ_Btn);
            this.Controls.Add(this.LoadSQLiteDB_Button);
            this.Controls.Add(this.SQLitePath_Box);
            this.Controls.Add(this.Convert_Btn);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostGIS Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Convert_Btn;
        private System.Windows.Forms.TextBox SQLitePath_Box;
        private System.Windows.Forms.Button LoadSQLiteDB_Button;
        private System.Windows.Forms.TextBox Server_Box;
        private System.Windows.Forms.TextBox Port_Box;
        private System.Windows.Forms.TextBox Database_Box;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ExportOBJ_Btn;
        private System.Windows.Forms.Button ExportJSON_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox QueryCommand_Box;
        private System.Windows.Forms.DataGridView ResultTable;
    }
}

