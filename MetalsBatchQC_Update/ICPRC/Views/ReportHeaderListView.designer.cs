namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class ReportHeaderListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportHeaderListView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.BCListView = new System.Windows.Forms.ListView();
            this.BatchCodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MethodCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SequenceNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjectNumberCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SponsorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrepDateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstrumentIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.OpenButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStrip1.Size = new System.Drawing.Size(800, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Active Batch Codes";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(119, 25);
            this.toolStripLabel1.Text = "Active Projects";
            // 
            // OpenButton
            // 
            this.OpenButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OpenButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(70, 25);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // BCListView
            // 
            this.BCListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BCListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BatchCodeColumn,
            this.MethodCodeCol,
            this.SequenceNumberColumn,
            this.ProjectNumberCol,
            this.SponsorCol,
            this.PrepDateCol,
            this.InstrumentIDCol});
            this.BCListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BCListView.FullRowSelect = true;
            this.BCListView.GridLines = true;
            this.BCListView.Location = new System.Drawing.Point(0, 48);
            this.BCListView.Name = "BCListView";
            this.BCListView.Size = new System.Drawing.Size(800, 494);
            this.BCListView.TabIndex = 3;
            this.BCListView.UseCompatibleStateImageBehavior = false;
            this.BCListView.View = System.Windows.Forms.View.Details;
            this.BCListView.SelectedIndexChanged += new System.EventHandler(this.BCListView_SelectedIndexChanged);
            this.BCListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BCListView_MouseDoubleClick);
            // 
            // BatchCodeColumn
            // 
            this.BatchCodeColumn.Text = "Batch Code";
            this.BatchCodeColumn.Width = 178;
            // 
            // MethodCodeCol
            // 
            this.MethodCodeCol.Text = "Method Code";
            this.MethodCodeCol.Width = 105;
            // 
            // SequenceNumberColumn
            // 
            this.SequenceNumberColumn.Text = "Sequence Number";
            this.SequenceNumberColumn.Width = 137;
            // 
            // ProjectNumberCol
            // 
            this.ProjectNumberCol.Text = "Project Number";
            this.ProjectNumberCol.Width = 146;
            // 
            // SponsorCol
            // 
            this.SponsorCol.Text = "Sponsor Name";
            this.SponsorCol.Width = 300;
            // 
            // PrepDateCol
            // 
            this.PrepDateCol.Text = "Prep Date";
            this.PrepDateCol.Width = 100;
            // 
            // InstrumentIDCol
            // 
            this.InstrumentIDCol.Text = "Instrument ID";
            this.InstrumentIDCol.Width = 135;
            // 
            // ReportHeaderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BCListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportHeaderListView";
            this.Size = new System.Drawing.Size(800, 542);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ListView BCListView;
        private System.Windows.Forms.ColumnHeader BatchCodeColumn;
        private System.Windows.Forms.ColumnHeader MethodCodeCol;
        private System.Windows.Forms.ColumnHeader SequenceNumberColumn;
        private System.Windows.Forms.ColumnHeader ProjectNumberCol;
        private System.Windows.Forms.ColumnHeader SponsorCol;
        private System.Windows.Forms.ColumnHeader PrepDateCol;
        private System.Windows.Forms.ColumnHeader InstrumentIDCol;
    }
}
