using System.Windows.Forms;
namespace Toxikon.BatchQC.Views.UserControls
{
    partial class BatchCodeListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchCodeListView));
            this.label1 = new System.Windows.Forms.Label();
            this.BQCListView = new System.Windows.Forms.ListView();
            this.BatchCodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SequenceNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdatedDateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdatedByCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddNewBatchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TopTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MethodCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.TopTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Batch Codes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BQCListView
            // 
            this.BQCListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BQCListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BQCListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BatchCodeColumn,
            this.MethodCodeCol,
            this.SequenceNumberColumn,
            this.UpdatedDateCol,
            this.UpdatedByCol});
            this.BQCListView.FullRowSelect = true;
            this.BQCListView.GridLines = true;
            this.BQCListView.Location = new System.Drawing.Point(10, 86);
            this.BQCListView.Name = "BQCListView";
            this.BQCListView.Size = new System.Drawing.Size(765, 443);
            this.BQCListView.TabIndex = 2;
            this.BQCListView.UseCompatibleStateImageBehavior = false;
            this.BQCListView.View = System.Windows.Forms.View.Details;
            this.BQCListView.SelectedIndexChanged += new System.EventHandler(this.BQCListView_SelectedIndexChanged);
            this.BQCListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BQCListView_MouseDoubleClick);
            // 
            // BatchCodeColumn
            // 
            this.BatchCodeColumn.Text = "Batch Code";
            this.BatchCodeColumn.Width = 190;
            // 
            // SequenceNumberColumn
            // 
            this.SequenceNumberColumn.Text = "Sequence Number";
            this.SequenceNumberColumn.Width = 138;
            // 
            // UpdatedDateCol
            // 
            this.UpdatedDateCol.Text = "Updated Date";
            this.UpdatedDateCol.Width = 116;
            // 
            // UpdatedByCol
            // 
            this.UpdatedByCol.Text = "Updated By";
            this.UpdatedByCol.Width = 171;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewBatchButton,
            this.toolStripSeparator1,
            this.OpenButton});
            this.toolStrip1.Location = new System.Drawing.Point(553, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(211, 40);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddNewBatchButton
            // 
            this.AddNewBatchButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewBatchButton.Image")));
            this.AddNewBatchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewBatchButton.Name = "AddNewBatchButton";
            this.AddNewBatchButton.Size = new System.Drawing.Size(134, 37);
            this.AddNewBatchButton.Text = "Add New Batch";
            this.AddNewBatchButton.Click += new System.EventHandler(this.AddNewBatchButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // OpenButton
            // 
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(68, 37);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.TopTableLayoutPanel.SetColumnSpan(this.label3, 2);
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please select one batch code below and click Open button.";
            // 
            // TopTableLayoutPanel
            // 
            this.TopTableLayoutPanel.ColumnCount = 2;
            this.TopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.34896F));
            this.TopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.65104F));
            this.TopTableLayoutPanel.Controls.Add(this.toolStrip1, 1, 0);
            this.TopTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.TopTableLayoutPanel.Controls.Add(this.label3, 0, 1);
            this.TopTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopTableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.TopTableLayoutPanel.Name = "TopTableLayoutPanel";
            this.TopTableLayoutPanel.RowCount = 2;
            this.TopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TopTableLayoutPanel.Size = new System.Drawing.Size(764, 70);
            this.TopTableLayoutPanel.TabIndex = 6;
            // 
            // MethodCodeCol
            // 
            this.MethodCodeCol.Text = "Method Code";
            this.MethodCodeCol.Width = 109;
            // 
            // BatchCodeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.TopTableLayoutPanel);
            this.Controls.Add(this.BQCListView);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(784, 542);
            this.Name = "BatchCodeListView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(784, 542);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TopTableLayoutPanel.ResumeLayout(false);
            this.TopTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView BQCListView;
        private System.Windows.Forms.ColumnHeader BatchCodeColumn;
        private System.Windows.Forms.ColumnHeader SequenceNumberColumn;
        private System.Windows.Forms.ColumnHeader UpdatedDateCol;
        private System.Windows.Forms.ColumnHeader UpdatedByCol;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewBatchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel TopTableLayoutPanel;
        private ColumnHeader MethodCodeCol;
    }
}
