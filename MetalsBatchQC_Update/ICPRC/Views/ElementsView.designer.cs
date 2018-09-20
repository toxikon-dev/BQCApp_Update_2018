namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class ElementsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementsView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.InstrumentElementListView = new System.Windows.Forms.ListView();
            this.InstrumentElementNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.ReportElementListView = new System.Windows.Forms.ListView();
            this.ReportElementNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.ElementsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.ElementsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshButton,
            this.toolStripSeparator1,
            this.SelectAllButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStrip1.Size = new System.Drawing.Size(800, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // SelectAllButton
            // 
            this.SelectAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SelectAllButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectAllButton.Image")));
            this.SelectAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(98, 25);
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
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
            this.LeftPanel.Controls.Add(this.InstrumentElementListView);
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(394, 446);
            this.LeftPanel.TabIndex = 0;
            // 
            // InstrumentElementListView
            // 
            this.InstrumentElementListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstrumentElementListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InstrumentElementNameCol});
            this.InstrumentElementListView.FullRowSelect = true;
            this.InstrumentElementListView.GridLines = true;
            this.InstrumentElementListView.Location = new System.Drawing.Point(8, 29);
            this.InstrumentElementListView.Name = "InstrumentElementListView";
            this.InstrumentElementListView.Size = new System.Drawing.Size(383, 414);
            this.InstrumentElementListView.TabIndex = 1;
            this.InstrumentElementListView.UseCompatibleStateImageBehavior = false;
            this.InstrumentElementListView.View = System.Windows.Forms.View.Details;
            this.InstrumentElementListView.SelectedIndexChanged += new System.EventHandler(this.InstrumentElementListView_SelectedIndexChanged);
            // 
            // InstrumentElementNameCol
            // 
            this.InstrumentElementNameCol.Text = "Element Name";
            this.InstrumentElementNameCol.Width = 357;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instrument Elements";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.ReportElementListView);
            this.RightPanel.Controls.Add(this.label2);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(403, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(394, 446);
            this.RightPanel.TabIndex = 1;
            // 
            // ReportElementListView
            // 
            this.ReportElementListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportElementListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ReportElementNameCol});
            this.ReportElementListView.FullRowSelect = true;
            this.ReportElementListView.GridLines = true;
            this.ReportElementListView.Location = new System.Drawing.Point(8, 29);
            this.ReportElementListView.Name = "ReportElementListView";
            this.ReportElementListView.Size = new System.Drawing.Size(383, 414);
            this.ReportElementListView.TabIndex = 1;
            this.ReportElementListView.UseCompatibleStateImageBehavior = false;
            this.ReportElementListView.View = System.Windows.Forms.View.Details;
            this.ReportElementListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReportElementListView_MouseClick);
            // 
            // ReportElementNameCol
            // 
            this.ReportElementNameCol.Text = "Element Name";
            this.ReportElementNameCol.Width = 356;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Report Elements";
            // 
            // ElementsContextMenuStrip
            // 
            this.ElementsContextMenuStrip.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElementsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveMenuItem});
            this.ElementsContextMenuStrip.Name = "ElementsContextMenuStrip";
            this.ElementsContextMenuStrip.Size = new System.Drawing.Size(135, 30);
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoveMenuItem.Image")));
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Size = new System.Drawing.Size(134, 26);
            this.RemoveMenuItem.Text = "Remove";
            this.RemoveMenuItem.Click += new System.EventHandler(this.RemoveMenuItem_Click);
            // 
            // ElementsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ElementsView";
            this.Size = new System.Drawing.Size(800, 500);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ElementsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SelectAllButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.ListView InstrumentElementListView;
        private System.Windows.Forms.ColumnHeader InstrumentElementNameCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.ListView ReportElementListView;
        private System.Windows.Forms.ColumnHeader ReportElementNameCol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip ElementsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveMenuItem;
    }
}
