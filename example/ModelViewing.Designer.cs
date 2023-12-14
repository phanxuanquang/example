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
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModelHiariachyTree
            // 
            this.ModelHiariachyTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ModelHiariachyTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelHiariachyTree.Location = new System.Drawing.Point(19, 17);
            this.ModelHiariachyTree.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ModelHiariachyTree.Name = "ModelHiariachyTree";
            this.ModelHiariachyTree.Size = new System.Drawing.Size(766, 768);
            this.ModelHiariachyTree.TabIndex = 0;
            this.ModelHiariachyTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // PropertyCategoryTabs
            // 
            this.PropertyCategoryTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyCategoryTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyCategoryTabs.Location = new System.Drawing.Point(796, 17);
            this.PropertyCategoryTabs.Margin = new System.Windows.Forms.Padding(5, 4, 16, 4);
            this.PropertyCategoryTabs.Name = "PropertyCategoryTabs";
            this.PropertyCategoryTabs.SelectedIndex = 0;
            this.PropertyCategoryTabs.Size = new System.Drawing.Size(756, 952);
            this.PropertyCategoryTabs.TabIndex = 1;
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(19, 796);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(768, 158);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "LOAD";
            this.LoadButton.UseVisualStyleBackColor = false;
            // 
            // ModelViewing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 986);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.PropertyCategoryTabs);
            this.Controls.Add(this.ModelHiariachyTree);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ModelViewing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView ModelHiariachyTree;
        private System.Windows.Forms.TabControl PropertyCategoryTabs;
        private System.Windows.Forms.Button LoadButton;
    }
}