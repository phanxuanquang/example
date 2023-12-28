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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportOBJ_Btn = new System.Windows.Forms.Button();
            this.ExportJSON_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Convert_Btn.Enabled = false;
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert_Btn.Location = new System.Drawing.Point(476, 254);
            this.Convert_Btn.Name = "Convert_Btn";
            this.Convert_Btn.Size = new System.Drawing.Size(406, 129);
            this.Convert_Btn.TabIndex = 0;
            this.Convert_Btn.Text = "Convert to PostGIS";
            this.Convert_Btn.UseVisualStyleBackColor = true;
            this.Convert_Btn.Click += new System.EventHandler(this.Convert_Btn_Click);
            // 
            // SQLitePath_Box
            // 
            this.SQLitePath_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SQLitePath_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLitePath_Box.Location = new System.Drawing.Point(54, 30);
            this.SQLitePath_Box.Name = "SQLitePath_Box";
            this.SQLitePath_Box.ReadOnly = true;
            this.SQLitePath_Box.Size = new System.Drawing.Size(1684, 35);
            this.SQLitePath_Box.TabIndex = 1;
            this.toolTip.SetToolTip(this.SQLitePath_Box, "Path to the selected .db file");
            this.SQLitePath_Box.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SQLitePath_Box_MouseDoubleClick);
            // 
            // LoadSQLiteDB_Button
            // 
            this.LoadSQLiteDB_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoadSQLiteDB_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadSQLiteDB_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LoadSQLiteDB_Button.Location = new System.Drawing.Point(50, 254);
            this.LoadSQLiteDB_Button.Name = "LoadSQLiteDB_Button";
            this.LoadSQLiteDB_Button.Size = new System.Drawing.Size(406, 129);
            this.LoadSQLiteDB_Button.TabIndex = 2;
            this.LoadSQLiteDB_Button.Text = "Select Database";
            this.LoadSQLiteDB_Button.UseVisualStyleBackColor = true;
            this.LoadSQLiteDB_Button.Click += new System.EventHandler(this.LoadSQLiteDB_Button_Click);
            // 
            // Server_Box
            // 
            this.Server_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Server_Box.BackColor = System.Drawing.Color.White;
            this.Server_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Box.Location = new System.Drawing.Point(44, 52);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(289, 32);
            this.Server_Box.TabIndex = 3;
            this.Server_Box.Text = "localhost";
            this.toolTip.SetToolTip(this.Server_Box, "Server | PostGIS Database");
            // 
            // Port_Box
            // 
            this.Port_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Port_Box.BackColor = System.Drawing.Color.White;
            this.Port_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Box.Location = new System.Drawing.Point(371, 52);
            this.Port_Box.Name = "Port_Box";
            this.Port_Box.Size = new System.Drawing.Size(289, 32);
            this.Port_Box.TabIndex = 4;
            this.Port_Box.Text = "5432";
            this.toolTip.SetToolTip(this.Port_Box, "Port | PostGIS Database");
            // 
            // Database_Box
            // 
            this.Database_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Database_Box.BackColor = System.Drawing.Color.White;
            this.Database_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database_Box.Location = new System.Drawing.Point(698, 52);
            this.Database_Box.Name = "Database_Box";
            this.Database_Box.Size = new System.Drawing.Size(289, 32);
            this.Database_Box.TabIndex = 5;
            this.toolTip.SetToolTip(this.Database_Box, "Database Name | PostGIS Database");
            // 
            // Password_Box
            // 
            this.Password_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password_Box.BackColor = System.Drawing.Color.White;
            this.Password_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Box.Location = new System.Drawing.Point(1351, 52);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(289, 32);
            this.Password_Box.TabIndex = 6;
            this.Password_Box.Text = "137925";
            this.toolTip.SetToolTip(this.Password_Box, "Password | PostGIS Database");
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Username_Box
            // 
            this.Username_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username_Box.BackColor = System.Drawing.Color.White;
            this.Username_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Box.Location = new System.Drawing.Point(1024, 52);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(289, 32);
            this.Username_Box.TabIndex = 7;
            this.Username_Box.Text = "postgres";
            this.toolTip.SetToolTip(this.Username_Box, "Username | PostGIS Database");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.Database_Box);
            this.groupBox1.Controls.Add(this.Server_Box);
            this.groupBox1.Controls.Add(this.Username_Box);
            this.groupBox1.Controls.Add(this.Port_Box);
            this.groupBox1.Controls.Add(this.Password_Box);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1685, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PostgreSQL Credential";
            // 
            // ExportOBJ_Btn
            // 
            this.ExportOBJ_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExportOBJ_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportOBJ_Btn.Location = new System.Drawing.Point(902, 254);
            this.ExportOBJ_Btn.Name = "ExportOBJ_Btn";
            this.ExportOBJ_Btn.Size = new System.Drawing.Size(406, 129);
            this.ExportOBJ_Btn.TabIndex = 9;
            this.ExportOBJ_Btn.Text = "Export to 3D object";
            this.ExportOBJ_Btn.UseVisualStyleBackColor = true;
            this.ExportOBJ_Btn.Click += new System.EventHandler(this.Export3Dobject_Btn_Click);
            // 
            // ExportJSON_Btn
            // 
            this.ExportJSON_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExportJSON_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportJSON_Btn.Location = new System.Drawing.Point(1327, 254);
            this.ExportJSON_Btn.Name = "ExportJSON_Btn";
            this.ExportJSON_Btn.Size = new System.Drawing.Size(406, 129);
            this.ExportJSON_Btn.TabIndex = 10;
            this.ExportJSON_Btn.Text = "Export to JSON";
            this.ExportJSON_Btn.UseVisualStyleBackColor = true;
            this.ExportJSON_Btn.Click += new System.EventHandler(this.ExportJSON_Btn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(684, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(406, 129);
            this.button1.TabIndex = 11;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1782, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExportJSON_Btn);
            this.Controls.Add(this.ExportOBJ_Btn);
            this.Controls.Add(this.LoadSQLiteDB_Button);
            this.Controls.Add(this.SQLitePath_Box);
            this.Controls.Add(this.Convert_Btn);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostGIS Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

