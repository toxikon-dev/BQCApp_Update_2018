namespace Toxikon.BatchQC.Views.UserControls
{
    partial class SampleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddMBToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddLCSToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AddLCSDToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddSampleGroupButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.samplesListView = new System.Windows.Forms.ListView();
            this.GroupCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SampleCodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SampleAmountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InitialDigestionAmountCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FinalAmountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMBToolStripButton,
            this.toolStripSeparator1,
            this.AddLCSToolStripButton,
            this.toolStripSeparator2,
            this.AddLCSDToolStripButton,
            this.toolStripSeparator3,
            this.AddSampleGroupButton,
            this.DeleteButton,
            this.toolStripSeparator4,
            this.UpdateButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 10, 1, 10);
            this.toolStrip1.Size = new System.Drawing.Size(776, 48);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddMBToolStripButton
            // 
            this.AddMBToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddMBToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddMBToolStripButton.Image")));
            this.AddMBToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddMBToolStripButton.Name = "AddMBToolStripButton";
            this.AddMBToolStripButton.Size = new System.Drawing.Size(68, 25);
            this.AddMBToolStripButton.Text = "Add MB";
            this.AddMBToolStripButton.Click += new System.EventHandler(this.AddMBToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // AddLCSToolStripButton
            // 
            this.AddLCSToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddLCSToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddLCSToolStripButton.Image")));
            this.AddLCSToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddLCSToolStripButton.Name = "AddLCSToolStripButton";
            this.AddLCSToolStripButton.Size = new System.Drawing.Size(71, 25);
            this.AddLCSToolStripButton.Text = "Add LCS";
            this.AddLCSToolStripButton.Click += new System.EventHandler(this.AddLCSToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // AddLCSDToolStripButton
            // 
            this.AddLCSDToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddLCSDToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddLCSDToolStripButton.Image")));
            this.AddLCSDToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddLCSDToolStripButton.Name = "AddLCSDToolStripButton";
            this.AddLCSDToolStripButton.Size = new System.Drawing.Size(82, 25);
            this.AddLCSDToolStripButton.Text = "Add LCSD";
            this.AddLCSDToolStripButton.Click += new System.EventHandler(this.AddLCSDToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // AddSampleGroupButton
            // 
            this.AddSampleGroupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddSampleGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSampleGroupButton.Image")));
            this.AddSampleGroupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddSampleGroupButton.Name = "AddSampleGroupButton";
            this.AddSampleGroupButton.Size = new System.Drawing.Size(142, 25);
            this.AddSampleGroupButton.Text = "Add Sample Group";
            this.AddSampleGroupButton.Click += new System.EventHandler(this.AddSampleGroupButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateButton.Image")));
            this.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(79, 25);
            this.UpdateButton.Text = "Update";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // samplesListView
            // 
            this.samplesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.samplesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.samplesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupCodeCol,
            this.SampleCodeColumn,
            this.SampleAmountColumn,
            this.InitialDigestionAmountCol,
            this.FinalAmountColumn,
            this.DescriptionColumn,
            this.CommentColumn});
            this.samplesListView.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.samplesListView.FullRowSelect = true;
            this.samplesListView.GridLines = true;
            this.samplesListView.Location = new System.Drawing.Point(0, 54);
            this.samplesListView.Margin = new System.Windows.Forms.Padding(5);
            this.samplesListView.Name = "samplesListView";
            this.samplesListView.Size = new System.Drawing.Size(774, 439);
            this.samplesListView.TabIndex = 2;
            this.samplesListView.UseCompatibleStateImageBehavior = false;
            this.samplesListView.View = System.Windows.Forms.View.Details;
            this.samplesListView.SelectedIndexChanged += new System.EventHandler(this.samplesListView_SelectedIndexChanged);
            // 
            // GroupCodeCol
            // 
            this.GroupCodeCol.Text = "Group Code";
            this.GroupCodeCol.Width = 100;
            // 
            // SampleCodeColumn
            // 
            this.SampleCodeColumn.Text = "Sample Code";
            this.SampleCodeColumn.Width = 133;
            // 
            // SampleAmountColumn
            // 
            this.SampleAmountColumn.Text = "Sample Amount";
            this.SampleAmountColumn.Width = 63;
            // 
            // InitialDigestionAmountCol
            // 
            this.InitialDigestionAmountCol.Text = "Initial Digestion Amount";
            this.InitialDigestionAmountCol.Width = 75;
            // 
            // FinalAmountColumn
            // 
            this.FinalAmountColumn.Text = "Final Amount";
            this.FinalAmountColumn.Width = 103;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.Text = "Description";
            this.DescriptionColumn.Width = 136;
            // 
            // CommentColumn
            // 
            this.CommentColumn.Text = "Comment";
            this.CommentColumn.Width = 133;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(73, 25);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // SampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.samplesListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SampleView";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Size = new System.Drawing.Size(776, 508);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddMBToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddLCSToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton AddLCSDToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton AddSampleGroupButton;
        private System.Windows.Forms.ListView samplesListView;
        private System.Windows.Forms.ColumnHeader SampleCodeColumn;
        private System.Windows.Forms.ColumnHeader SampleAmountColumn;
        private System.Windows.Forms.ColumnHeader FinalAmountColumn;
        private System.Windows.Forms.ColumnHeader DescriptionColumn;
        private System.Windows.Forms.ColumnHeader CommentColumn;
        private System.Windows.Forms.ToolStripButton UpdateButton;
        private System.Windows.Forms.ColumnHeader GroupCodeCol;
        private System.Windows.Forms.ColumnHeader InitialDigestionAmountCol;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
