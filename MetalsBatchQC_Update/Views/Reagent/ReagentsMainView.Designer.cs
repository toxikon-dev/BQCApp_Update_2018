namespace Toxikon.BatchQC.Views.UserControls
{
    partial class ReagentsMainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReagentsMainView));
            this.ReagentListView = new System.Windows.Forms.ListView();
            this.ProductCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddNewReagentButton = new System.Windows.Forms.ToolStripButton();
            this.TopTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.TopTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReagentListView
            // 
            this.ReagentListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReagentListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReagentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductCodeCol,
            this.ProductNameCol});
            this.ReagentListView.FullRowSelect = true;
            this.ReagentListView.GridLines = true;
            this.ReagentListView.Location = new System.Drawing.Point(13, 56);
            this.ReagentListView.Name = "ReagentListView";
            this.ReagentListView.Size = new System.Drawing.Size(760, 475);
            this.ReagentListView.TabIndex = 7;
            this.ReagentListView.UseCompatibleStateImageBehavior = false;
            this.ReagentListView.View = System.Windows.Forms.View.Details;
            // 
            // ProductCodeCol
            // 
            this.ProductCodeCol.Text = "Product Code";
            this.ProductCodeCol.Width = 190;
            // 
            // ProductNameCol
            // 
            this.ProductNameCol.Text = "Product Name";
            this.ProductNameCol.Width = 388;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reagents";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewReagentButton});
            this.toolStrip1.Location = new System.Drawing.Point(611, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(155, 40);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddNewReagentButton
            // 
            this.AddNewReagentButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewReagentButton.Image")));
            this.AddNewReagentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewReagentButton.Name = "AddNewReagentButton";
            this.AddNewReagentButton.Size = new System.Drawing.Size(152, 37);
            this.AddNewReagentButton.Text = "Add New Reagent";
            this.AddNewReagentButton.Click += new System.EventHandler(this.AddNewReagentButton_Click);
            // 
            // TopTableLayoutPanel
            // 
            this.TopTableLayoutPanel.ColumnCount = 2;
            this.TopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.32981F));
            this.TopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.67018F));
            this.TopTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.TopTableLayoutPanel.Controls.Add(this.toolStrip1, 1, 0);
            this.TopTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopTableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.TopTableLayoutPanel.Name = "TopTableLayoutPanel";
            this.TopTableLayoutPanel.RowCount = 1;
            this.TopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TopTableLayoutPanel.Size = new System.Drawing.Size(766, 40);
            this.TopTableLayoutPanel.TabIndex = 9;
            // 
            // ReagentsMainView
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.TopTableLayoutPanel);
            this.Controls.Add(this.ReagentListView);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(784, 542);
            this.Name = "ReagentsMainView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(786, 544);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TopTableLayoutPanel.ResumeLayout(false);
            this.TopTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ReagentListView;
        private System.Windows.Forms.ColumnHeader ProductCodeCol;
        private System.Windows.Forms.ColumnHeader ProductNameCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewReagentButton;
        private System.Windows.Forms.TableLayoutPanel TopTableLayoutPanel;
    }
}
