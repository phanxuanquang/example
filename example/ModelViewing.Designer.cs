namespace Viewer
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
            this.PropertyCategoryTabs = new System.Windows.Forms.TabControl();
            this.ExportButton = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ModelHiariachyTree
            // 
            this.ModelHiariachyTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ModelHiariachyTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelHiariachyTree.Location = new System.Drawing.Point(12, 12);
            this.ModelHiariachyTree.Name = "ModelHiariachyTree";
            this.ModelHiariachyTree.Size = new System.Drawing.Size(331, 652);
            this.ModelHiariachyTree.TabIndex = 0;
            this.ModelHiariachyTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseClick);
            // 
            // PropertyCategoryTabs
            // 
            this.PropertyCategoryTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyCategoryTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyCategoryTabs.Location = new System.Drawing.Point(363, 535);
            this.PropertyCategoryTabs.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.PropertyCategoryTabs.Name = "PropertyCategoryTabs";
            this.PropertyCategoryTabs.SelectedIndex = 0;
            this.PropertyCategoryTabs.Size = new System.Drawing.Size(1155, 371);
            this.PropertyCategoryTabs.TabIndex = 1;
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportButton.Location = new System.Drawing.Point(12, 670);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(331, 236);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "EXPORT";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.Location = new System.Drawing.Point(363, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(1155, 517);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // ModelViewing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 918);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.PropertyCategoryTabs);
            this.Controls.Add(this.ModelHiariachyTree);
            this.Name = "ModelViewing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView ModelHiariachyTree;
        private System.Windows.Forms.TabControl PropertyCategoryTabs;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}