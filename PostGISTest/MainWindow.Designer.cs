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
            this.SuspendLayout();
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert_Btn.Location = new System.Drawing.Point(924, 238);
            this.Convert_Btn.Name = "Convert_Btn";
            this.Convert_Btn.Size = new System.Drawing.Size(575, 129);
            this.Convert_Btn.TabIndex = 0;
            this.Convert_Btn.Text = "Convert to PostGIS";
            this.Convert_Btn.UseVisualStyleBackColor = true;
            this.Convert_Btn.Click += new System.EventHandler(this.Convert_Btn_Click);
            // 
            // SQLitePath_Box
            // 
            this.SQLitePath_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SQLitePath_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLitePath_Box.Location = new System.Drawing.Point(87, 55);
            this.SQLitePath_Box.Name = "SQLitePath_Box";
            this.SQLitePath_Box.ReadOnly = true;
            this.SQLitePath_Box.Size = new System.Drawing.Size(1595, 48);
            this.SQLitePath_Box.TabIndex = 1;
            this.toolTip.SetToolTip(this.SQLitePath_Box, "Path to the selected .db file");
            // 
            // LoadSQLiteDB_Button
            // 
            this.LoadSQLiteDB_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoadSQLiteDB_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadSQLiteDB_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LoadSQLiteDB_Button.Location = new System.Drawing.Point(271, 238);
            this.LoadSQLiteDB_Button.Name = "LoadSQLiteDB_Button";
            this.LoadSQLiteDB_Button.Size = new System.Drawing.Size(575, 129);
            this.LoadSQLiteDB_Button.TabIndex = 2;
            this.LoadSQLiteDB_Button.Text = "Select File";
            this.LoadSQLiteDB_Button.UseVisualStyleBackColor = true;
            this.LoadSQLiteDB_Button.Click += new System.EventHandler(this.LoadSQLiteDB_Button_Click);
            // 
            // Server_Box
            // 
            this.Server_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Server_Box.BackColor = System.Drawing.Color.White;
            this.Server_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Box.Location = new System.Drawing.Point(87, 144);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(289, 45);
            this.Server_Box.TabIndex = 3;
            this.Server_Box.Text = "localhost";
            this.toolTip.SetToolTip(this.Server_Box, "Server | PostGIS Database");
            // 
            // Port_Box
            // 
            this.Port_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Port_Box.BackColor = System.Drawing.Color.White;
            this.Port_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Box.Location = new System.Drawing.Point(414, 144);
            this.Port_Box.Name = "Port_Box";
            this.Port_Box.Size = new System.Drawing.Size(289, 45);
            this.Port_Box.TabIndex = 4;
            this.Port_Box.Text = "5432";
            this.toolTip.SetToolTip(this.Port_Box, "Port | PostGIS Database");
            // 
            // Database_Box
            // 
            this.Database_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Database_Box.BackColor = System.Drawing.Color.White;
            this.Database_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database_Box.Location = new System.Drawing.Point(740, 144);
            this.Database_Box.Name = "Database_Box";
            this.Database_Box.Size = new System.Drawing.Size(289, 45);
            this.Database_Box.TabIndex = 5;
            this.Database_Box.Text = "dm";
            this.toolTip.SetToolTip(this.Database_Box, "Database Name | PostGIS Database");
            // 
            // Password_Box
            // 
            this.Password_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password_Box.BackColor = System.Drawing.Color.White;
            this.Password_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Box.Location = new System.Drawing.Point(1394, 144);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(289, 45);
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
            this.Username_Box.Location = new System.Drawing.Point(1067, 144);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(289, 45);
            this.Username_Box.TabIndex = 7;
            this.Username_Box.Text = "postgres";
            this.toolTip.SetToolTip(this.Username_Box, "Username | PostGIS Database");
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1770, 416);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Database_Box);
            this.Controls.Add(this.Port_Box);
            this.Controls.Add(this.Server_Box);
            this.Controls.Add(this.LoadSQLiteDB_Button);
            this.Controls.Add(this.SQLitePath_Box);
            this.Controls.Add(this.Convert_Btn);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostGIS Converter";
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
    }
}

