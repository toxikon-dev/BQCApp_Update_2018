namespace Toxikon.BatchQC.Views.ICPRC
{
    partial class BatchReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchReportView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.ElementCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrueValueCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MBCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LCSCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LCSDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LCSRecoveryCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LCSDRecoveryCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RPDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubmitLCSResultsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadButton,
            this.SubmitLCSResultsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStrip1.Size = new System.Drawing.Size(800, 48);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DownloadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadButton.Image")));
            this.DownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(159, 25);
            this.DownloadButton.Text = "Download Report";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // ResultListView
            // 
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ElementCol,
            this.TrueValueCol,
            this.MBCol,
            this.LCSCol,
            this.LCSDCol,
            this.LCSRecoveryCol,
            this.LCSDRecoveryCol,
            this.RPDCol});
            this.ResultListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.GridLines = true;
            this.ResultListView.Location = new System.Drawing.Point(0, 48);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(800, 452);
            this.ResultListView.TabIndex = 6;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ResultListView_MouseDoubleClick);
            // 
            // ElementCol
            // 
            this.ElementCol.Text = "ELEMENT";
            this.ElementCol.Width = 102;
            // 
            // TrueValueCol
            // 
            this.TrueValueCol.Text = "TRUE VALUE";
            this.TrueValueCol.Width = 110;
            // 
            // MBCol
            // 
            this.MBCol.Text = "MB";
            // 
            // LCSCol
            // 
            this.LCSCol.Text = "LCS";
            // 
            // LCSDCol
            // 
            this.LCSDCol.Text = "LCSD";
            // 
            // LCSRecoveryCol
            // 
            this.LCSRecoveryCol.Text = "LCS %";
            // 
            // LCSDRecoveryCol
            // 
            this.LCSDRecoveryCol.Text = "LCSD %";
            this.LCSDRecoveryCol.Width = 76;
            // 
            // RPDCol
            // 
            this.RPDCol.Text = "RPD %";
            // 
            // SubmitLCSResultsButton
            // 
            this.SubmitLCSResultsButton.Image = ((System.Drawing.Image)(resources.GetObject("SubmitLCSResultsButton.Image")));
            this.SubmitLCSResultsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitLCSResultsButton.Name = "SubmitLCSResultsButton";
            this.SubmitLCSResultsButton.Size = new System.Drawing.Size(156, 25);
            this.SubmitLCSResultsButton.Text = "Submit LCS Results";
            this.SubmitLCSResultsButton.Click += new System.EventHandler(this.SubmitLCSResultsButton_Click);
            // 
            // BatchReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BatchReportView";
            this.Size = new System.Drawing.Size(800, 500);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DownloadButton;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ColumnHeader ElementCol;
        private System.Windows.Forms.ColumnHeader TrueValueCol;
        private System.Windows.Forms.ColumnHeader MBCol;
        private System.Windows.Forms.ColumnHeader LCSCol;
        private System.Windows.Forms.ColumnHeader LCSDCol;
        private System.Windows.Forms.ColumnHeader LCSRecoveryCol;
        private System.Windows.Forms.ColumnHeader LCSDRecoveryCol;
        private System.Windows.Forms.ColumnHeader RPDCol;
        private System.Windows.Forms.ToolStripButton SubmitLCSResultsButton;
    }
}
