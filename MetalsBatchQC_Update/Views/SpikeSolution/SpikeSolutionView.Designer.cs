namespace Toxikon.BatchQC.Views.UserControls
{
    partial class SpikeSolutionView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpikeSolutionView));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ChemicalComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.findCodeButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.spikeSolutionListView = new System.Windows.Forms.ListView();
            this.IDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChemicalComboBox,
            this.findCodeButton,
            this.DeleteButton});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 10, 1, 10);
            this.toolStrip2.Size = new System.Drawing.Size(776, 49);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // ChemicalComboBox
            // 
            this.ChemicalComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.ChemicalComboBox.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChemicalComboBox.Name = "ChemicalComboBox";
            this.ChemicalComboBox.Size = new System.Drawing.Size(200, 29);
            this.ChemicalComboBox.SelectedIndexChanged += new System.EventHandler(this.ChemicalComboBox_SelectedIndexChanged);
            // 
            // findCodeButton
            // 
            this.findCodeButton.Image = ((System.Drawing.Image)(resources.GetObject("findCodeButton.Image")));
            this.findCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findCodeButton.Name = "findCodeButton";
            this.findCodeButton.Size = new System.Drawing.Size(98, 26);
            this.findCodeButton.Text = "Find Code";
            this.findCodeButton.Click += new System.EventHandler(this.findCodeButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(73, 26);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // spikeSolutionListView
            // 
            this.spikeSolutionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spikeSolutionListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spikeSolutionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.NameColumn});
            this.spikeSolutionListView.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spikeSolutionListView.FullRowSelect = true;
            this.spikeSolutionListView.GridLines = true;
            this.spikeSolutionListView.Location = new System.Drawing.Point(0, 49);
            this.spikeSolutionListView.Name = "spikeSolutionListView";
            this.spikeSolutionListView.Size = new System.Drawing.Size(773, 446);
            this.spikeSolutionListView.TabIndex = 2;
            this.spikeSolutionListView.UseCompatibleStateImageBehavior = false;
            this.spikeSolutionListView.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            this.IDColumn.Width = 193;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 532;
            // 
            // SpikeSolutionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.spikeSolutionListView);
            this.Controls.Add(this.toolStrip2);
            this.Name = "SpikeSolutionView";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Size = new System.Drawing.Size(776, 508);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton findCodeButton;
        private System.Windows.Forms.ListView spikeSolutionListView;
        private System.Windows.Forms.ColumnHeader IDColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripComboBox ChemicalComboBox;
    }
}
