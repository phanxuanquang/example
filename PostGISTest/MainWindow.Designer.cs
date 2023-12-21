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
            this.Convert_Btn = new System.Windows.Forms.Button();
            this.SQLitePath_Box = new System.Windows.Forms.TextBox();
            this.LoadSQLiteDB_Button = new System.Windows.Forms.Button();
            this.Server_Box = new System.Windows.Forms.TextBox();
            this.Port_Box = new System.Windows.Forms.TextBox();
            this.Database_Box = new System.Windows.Forms.TextBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert_Btn.Location = new System.Drawing.Point(627, 194);
            this.Convert_Btn.Name = "Convert_Btn";
            this.Convert_Btn.Size = new System.Drawing.Size(478, 102);
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
            this.SQLitePath_Box.Location = new System.Drawing.Point(73, 30);
            this.SQLitePath_Box.Name = "SQLitePath_Box";
            this.SQLitePath_Box.ReadOnly = true;
            this.SQLitePath_Box.Size = new System.Drawing.Size(1276, 48);
            this.SQLitePath_Box.TabIndex = 1;
            // 
            // LoadSQLiteDB_Button
            // 
            this.LoadSQLiteDB_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadSQLiteDB_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadSQLiteDB_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadSQLiteDB_Button.Location = new System.Drawing.Point(1377, 25);
            this.LoadSQLiteDB_Button.Name = "LoadSQLiteDB_Button";
            this.LoadSQLiteDB_Button.Size = new System.Drawing.Size(275, 144);
            this.LoadSQLiteDB_Button.TabIndex = 2;
            this.LoadSQLiteDB_Button.Text = "LOAD";
            this.LoadSQLiteDB_Button.UseVisualStyleBackColor = true;
            this.LoadSQLiteDB_Button.Click += new System.EventHandler(this.LoadSQLiteDB_Button_Click);
            // 
            // Server_Box
            // 
            this.Server_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Server_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Box.Location = new System.Drawing.Point(73, 106);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(230, 45);
            this.Server_Box.TabIndex = 3;
            this.Server_Box.Text = "localhost";
            // 
            // Port_Box
            // 
            this.Port_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Port_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Box.Location = new System.Drawing.Point(334, 106);
            this.Port_Box.Name = "Port_Box";
            this.Port_Box.Size = new System.Drawing.Size(230, 45);
            this.Port_Box.TabIndex = 4;
            this.Port_Box.Text = "5432";
            // 
            // Database_Box
            // 
            this.Database_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Database_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database_Box.Location = new System.Drawing.Point(594, 106);
            this.Database_Box.Name = "Database_Box";
            this.Database_Box.Size = new System.Drawing.Size(230, 45);
            this.Database_Box.TabIndex = 5;
            this.Database_Box.Text = "ok";
            // 
            // Password_Box
            // 
            this.Password_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Box.Location = new System.Drawing.Point(1117, 106);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(230, 45);
            this.Password_Box.TabIndex = 6;
            this.Password_Box.Text = "137925";
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Username_Box
            // 
            this.Username_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Box.Location = new System.Drawing.Point(856, 106);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(230, 45);
            this.Username_Box.TabIndex = 7;
            this.Username_Box.Text = "postgres";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1725, 331);
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
            this.Text = "Form1";
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
    }
}

