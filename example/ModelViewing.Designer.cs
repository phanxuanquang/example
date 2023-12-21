﻿namespace Viewer
{
    partial class ModelViewing
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
            this.ModelHiariachyTree = new System.Windows.Forms.TreeView();
            this.Export2SQLiteButton = new System.Windows.Forms.Button();
            this.Export2PostGISButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModelHiariachyTree
            // 
            this.ModelHiariachyTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModelHiariachyTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelHiariachyTree.Location = new System.Drawing.Point(19, 13);
            this.ModelHiariachyTree.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ModelHiariachyTree.Name = "ModelHiariachyTree";
            this.ModelHiariachyTree.Size = new System.Drawing.Size(1051, 457);
            this.ModelHiariachyTree.TabIndex = 0;
            // 
            // Export2SQLiteButton
            // 
            this.Export2SQLiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Export2SQLiteButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Export2SQLiteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Export2SQLiteButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export2SQLiteButton.Location = new System.Drawing.Point(19, 488);
            this.Export2SQLiteButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Export2SQLiteButton.Name = "Export2SQLiteButton";
            this.Export2SQLiteButton.Size = new System.Drawing.Size(515, 158);
            this.Export2SQLiteButton.TabIndex = 0;
            this.Export2SQLiteButton.Text = "Export to SQLite database";
            this.Export2SQLiteButton.UseVisualStyleBackColor = false;
            this.Export2SQLiteButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // Export2PostGISButton
            // 
            this.Export2PostGISButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Export2PostGISButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Export2PostGISButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Export2PostGISButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export2PostGISButton.Location = new System.Drawing.Point(555, 488);
            this.Export2PostGISButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Export2PostGISButton.Name = "Export2PostGISButton";
            this.Export2PostGISButton.Size = new System.Drawing.Size(515, 158);
            this.Export2PostGISButton.TabIndex = 1;
            this.Export2PostGISButton.Text = "Export to PostGIS database";
            this.Export2PostGISButton.UseVisualStyleBackColor = false;
            this.Export2PostGISButton.Click += new System.EventHandler(this.Export2PostGISButton_Click);
            // 
            // ModelViewing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 666);
            this.Controls.Add(this.Export2PostGISButton);
            this.Controls.Add(this.Export2SQLiteButton);
            this.Controls.Add(this.ModelHiariachyTree);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ModelViewing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView ModelHiariachyTree;
        private System.Windows.Forms.Button Export2SQLiteButton;
        private System.Windows.Forms.Button Export2PostGISButton;
    }
}