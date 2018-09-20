namespace Toxikon.BatchQC.Views.Reports
{
    partial class ControlChartReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlChartReportView));
            this.label1 = new System.Windows.Forms.Label();
            this.ReportListView = new System.Windows.Forms.ListView();
            this.InstrumentIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonthCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YearCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadProgressLabel = new System.Windows.Forms.Label();
            this.ProgressBarTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.ProgressBarTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Control Chart Reports";
            // 
            // ReportListView
            // 
            this.ReportListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReportListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InstrumentIDCol,
            this.MonthCol,
            this.YearCol});
            this.ReportListView.FullRowSelect = true;
            this.ReportListView.GridLines = true;
            this.ReportListView.Location = new System.Drawing.Point(13, 57);
            this.ReportListView.Name = "ReportListView";
            this.ReportListView.Size = new System.Drawing.Size(758, 472);
            this.ReportListView.TabIndex = 1;
            this.ReportListView.UseCompatibleStateImageBehavior = false;
            this.ReportListView.View = System.Windows.Forms.View.Details;
            this.ReportListView.SelectedIndexChanged += new System.EventHandler(this.ReportListView_SelectedIndexChanged);
            // 
            // InstrumentIDCol
            // 
            this.InstrumentIDCol.Text = "Instrument ID";
            this.InstrumentIDCol.Width = 129;
            // 
            // MonthCol
            // 
            this.MonthCol.Text = "Month";
            this.MonthCol.Width = 76;
            // 
            // YearCol
            // 
            this.YearCol.Text = "Year";
            this.YearCol.Width = 112;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadButton});
            this.toolStrip1.Location = new System.Drawing.Point(620, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(151, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadButton.Image")));
            this.DownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(148, 25);
            this.DownloadButton.Text = "Download Report";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DownloadProgressBar.Location = new System.Drawing.Point(313, 29);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(131, 23);
            this.DownloadProgressBar.TabIndex = 3;
            // 
            // DownloadProgressLabel
            // 
            this.DownloadProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgressLabel.AutoSize = true;
            this.DownloadProgressLabel.Location = new System.Drawing.Point(3, 0);
            this.DownloadProgressLabel.Name = "DownloadProgressLabel";
            this.DownloadProgressLabel.Size = new System.Drawing.Size(752, 21);
            this.DownloadProgressLabel.TabIndex = 4;
            this.DownloadProgressLabel.Text = "label2";
            this.DownloadProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProgressBarTableLayoutPanel
            // 
            this.ProgressBarTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBarTableLayoutPanel.ColumnCount = 1;
            this.ProgressBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ProgressBarTableLayoutPanel.Controls.Add(this.DownloadProgressLabel, 0, 0);
            this.ProgressBarTableLayoutPanel.Controls.Add(this.DownloadProgressBar, 0, 1);
            this.ProgressBarTableLayoutPanel.Location = new System.Drawing.Point(13, 190);
            this.ProgressBarTableLayoutPanel.Name = "ProgressBarTableLayoutPanel";
            this.ProgressBarTableLayoutPanel.RowCount = 2;
            this.ProgressBarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.ProgressBarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71F));
            this.ProgressBarTableLayoutPanel.Size = new System.Drawing.Size(758, 92);
            this.ProgressBarTableLayoutPanel.TabIndex = 5;
            // 
            // ControlChartReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ProgressBarTableLayoutPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ReportListView);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlChartReportView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(784, 542);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ProgressBarTableLayoutPanel.ResumeLayout(false);
            this.ProgressBarTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ReportListView;
        private System.Windows.Forms.ColumnHeader InstrumentIDCol;
        private System.Windows.Forms.ColumnHeader MonthCol;
        private System.Windows.Forms.ColumnHeader YearCol;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DownloadButton;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Label DownloadProgressLabel;
        private System.Windows.Forms.TableLayoutPanel ProgressBarTableLayoutPanel;
    }
}
