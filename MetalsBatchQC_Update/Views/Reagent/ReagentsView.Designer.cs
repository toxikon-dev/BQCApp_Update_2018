namespace Toxikon.BatchQC.Views.UserControls
{
    partial class ReagentsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReagentsView));
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.reagentComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.findCodeButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.reagentsListView = new System.Windows.Forms.ListView();
            this.IDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TopToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reagentComboBox,
            this.findCodeButton,
            this.DeleteButton,
            this.toolStripSeparator1,
            this.UpdateButton});
            this.TopToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Padding = new System.Windows.Forms.Padding(0, 10, 1, 10);
            this.TopToolStrip.Size = new System.Drawing.Size(776, 49);
            this.TopToolStrip.TabIndex = 1;
            this.TopToolStrip.Text = "toolStrip1";
            // 
            // reagentComboBox
            // 
            this.reagentComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.reagentComboBox.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reagentComboBox.Name = "reagentComboBox";
            this.reagentComboBox.Size = new System.Drawing.Size(200, 29);
            this.reagentComboBox.SelectedIndexChanged += new System.EventHandler(this.reagentComboBox_SelectedIndexChanged);
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
            // UpdateButton
            // 
            this.UpdateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateButton.Image")));
            this.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(79, 26);
            this.UpdateButton.Text = "Update";
            this.UpdateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // reagentsListView
            // 
            this.reagentsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reagentsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reagentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.NameColumn,
            this.AmountColumn,
            this.UnitColumn});
            this.reagentsListView.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reagentsListView.FullRowSelect = true;
            this.reagentsListView.GridLines = true;
            this.reagentsListView.HideSelection = false;
            this.reagentsListView.Location = new System.Drawing.Point(0, 54);
            this.reagentsListView.Margin = new System.Windows.Forms.Padding(5);
            this.reagentsListView.MultiSelect = false;
            this.reagentsListView.Name = "reagentsListView";
            this.reagentsListView.Size = new System.Drawing.Size(776, 440);
            this.reagentsListView.TabIndex = 2;
            this.reagentsListView.UseCompatibleStateImageBehavior = false;
            this.reagentsListView.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            this.IDColumn.Width = 165;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 370;
            // 
            // AmountColumn
            // 
            this.AmountColumn.Text = "Amount";
            this.AmountColumn.Width = 93;
            // 
            // UnitColumn
            // 
            this.UnitColumn.Text = "Unit";
            this.UnitColumn.Width = 97;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // ReagentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.reagentsListView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReagentsView";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Size = new System.Drawing.Size(776, 508);
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ListView reagentsListView;
        private System.Windows.Forms.ColumnHeader IDColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader AmountColumn;
        private System.Windows.Forms.ColumnHeader UnitColumn;
        private System.Windows.Forms.ToolStripComboBox reagentComboBox;
        private System.Windows.Forms.ToolStripButton findCodeButton;
        private System.Windows.Forms.ToolStripButton UpdateButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
