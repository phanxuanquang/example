﻿namespace example
{
    partial class ShowForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.PropertiesTabs = new System.Windows.Forms.TabControl();
            this.LoadButton = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(19, 17);
            this.treeView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(766, 1332);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // PropertiesTabs
            // 
            this.PropertiesTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesTabs.Location = new System.Drawing.Point(796, 940);
            this.PropertiesTabs.Margin = new System.Windows.Forms.Padding(5, 4, 16, 4);
            this.PropertiesTabs.Name = "PropertiesTabs";
            this.PropertiesTabs.SelectedIndex = 0;
            this.PropertiesTabs.Size = new System.Drawing.Size(1857, 593);
            this.PropertiesTabs.TabIndex = 1;
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(19, 1360);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(768, 158);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "LOAD";
            this.LoadButton.UseVisualStyleBackColor = false;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(796, 17);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1855, 912);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2672, 1550);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.PropertiesTabs);
            this.Controls.Add(this.treeView);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Something";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl PropertiesTabs;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}