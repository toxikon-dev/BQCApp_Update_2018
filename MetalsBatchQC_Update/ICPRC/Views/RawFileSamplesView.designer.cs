namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class RawFileSamplesView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawFileSamplesView));
            this.TabPage1ToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BrowseFileButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.RawFileSampleListView = new System.Windows.Forms.ListView();
            this.RawFileSampleNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.ReportSamplesListView = new System.Windows.Forms.ListView();
            this.ReportSampleNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.MainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TabPage1ToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.MainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1ToolStrip
            // 
            this.TabPage1ToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1ToolStrip.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TabPage1ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshButton,
            this.toolStripSeparator1,
            this.BrowseFileButton});
            this.TabPage1ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TabPage1ToolStrip.Name = "TabPage1ToolStrip";
            this.TabPage1ToolStrip.Padding = new System.Windows.Forms.Padding(10);
            this.TabPage1ToolStrip.Size = new System.Drawing.Size(800, 48);
            this.TabPage1ToolStrip.TabIndex = 1;
            this.TabPage1ToolStrip.Text = "toolStrip1";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Black;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(86, 25);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // BrowseFileButton
            // 
            this.BrowseFileButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BrowseFileButton.BackColor = System.Drawing.SystemColors.Control;
            this.BrowseFileButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseFileButton.ForeColor = System.Drawing.Color.Black;
            this.BrowseFileButton.Image = ((System.Drawing.Image)(resources.GetObject("BrowseFileButton.Image")));
            this.BrowseFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BrowseFileButton.Name = "BrowseFileButton";
            this.BrowseFileButton.Size = new System.Drawing.Size(113, 25);
            this.BrowseFileButton.Text = "Browse File";
            this.BrowseFileButton.Click += new System.EventHandler(this.BrowseFileButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LeftPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 452);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.RawFileSampleListView);
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(394, 446);
            this.LeftPanel.TabIndex = 0;
            // 
            // RawFileSampleListView
            // 
            this.RawFileSampleListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RawFileSampleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RawFileSampleNameCol});
            this.RawFileSampleListView.FullRowSelect = true;
            this.RawFileSampleListView.GridLines = true;
            this.RawFileSampleListView.Location = new System.Drawing.Point(8, 29);
            this.RawFileSampleListView.Name = "RawFileSampleListView";
            this.RawFileSampleListView.Size = new System.Drawing.Size(383, 414);
            this.RawFileSampleListView.TabIndex = 1;
            this.RawFileSampleListView.UseCompatibleStateImageBehavior = false;
            this.RawFileSampleListView.View = System.Windows.Forms.View.Details;
            this.RawFileSampleListView.SelectedIndexChanged += new System.EventHandler(this.RawFileSamplesListView_SelectedIndexChanged);
            // 
            // RawFileSampleNameCol
            // 
            this.RawFileSampleNameCol.Text = "Sample Name";
            this.RawFileSampleNameCol.Width = 357;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raw File Samples";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.ReportSamplesListView);
            this.RightPanel.Controls.Add(this.label2);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(403, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(394, 446);
            this.RightPanel.TabIndex = 1;
            // 
            // ReportSamplesListView
            // 
            this.ReportSamplesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportSamplesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ReportSampleNameCol});
            this.ReportSamplesListView.FullRowSelect = true;
            this.ReportSamplesListView.GridLines = true;
            this.ReportSamplesListView.Location = new System.Drawing.Point(8, 29);
            this.ReportSamplesListView.Name = "ReportSamplesListView";
            this.ReportSamplesListView.Size = new System.Drawing.Size(383, 414);
            this.ReportSamplesListView.TabIndex = 1;
            this.ReportSamplesListView.UseCompatibleStateImageBehavior = false;
            this.ReportSamplesListView.View = System.Windows.Forms.View.Details;
            this.ReportSamplesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReportSamplesListView_MouseClick);
            // 
            // ReportSampleNameCol
            // 
            this.ReportSampleNameCol.Text = "Sample Name";
            this.ReportSampleNameCol.Width = 356;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Report Samples";
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveMenuItem});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.Size = new System.Drawing.Size(135, 30);
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoveMenuItem.Image")));
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Size = new System.Drawing.Size(134, 26);
            this.RemoveMenuItem.Text = "Remove";
            this.RemoveMenuItem.Click += new System.EventHandler(this.RemoveMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // RawFileSamplesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TabPage1ToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RawFileSamplesView";
            this.Size = new System.Drawing.Size(800, 500);
            this.TabPage1ToolStrip.ResumeLayout(false);
            this.TabPage1ToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.MainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TabPage1ToolStrip;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BrowseFileButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.ListView RawFileSampleListView;
        private System.Windows.Forms.ColumnHeader RawFileSampleNameCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.ListView ReportSamplesListView;
        private System.Windows.Forms.ColumnHeader ReportSampleNameCol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip MainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
