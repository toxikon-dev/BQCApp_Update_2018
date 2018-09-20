namespace Toxikon.BatchQC.Views.UserControls
{
    partial class SpikeSolutionMainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpikeSolutionMainView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddNewSpikeSolutionButton = new System.Windows.Forms.ToolStripButton();
            this.SpikeSolutionListView = new System.Windows.Forms.ListView();
            this.ProductCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewSpikeSolutionButton});
            this.toolStrip1.Location = new System.Drawing.Point(571, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(193, 40);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddNewSpikeSolutionButton
            // 
            this.AddNewSpikeSolutionButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewSpikeSolutionButton.Image")));
            this.AddNewSpikeSolutionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewSpikeSolutionButton.Name = "AddNewSpikeSolutionButton";
            this.AddNewSpikeSolutionButton.Size = new System.Drawing.Size(190, 37);
            this.AddNewSpikeSolutionButton.Text = "Add New Spike Solution";
            this.AddNewSpikeSolutionButton.Click += new System.EventHandler(this.AddNewSpikeSolutionButton_Click);
            // 
            // SpikeSolutionListView
            // 
            this.SpikeSolutionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpikeSolutionListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpikeSolutionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductCodeCol,
            this.ProductNameCol});
            this.SpikeSolutionListView.FullRowSelect = true;
            this.SpikeSolutionListView.GridLines = true;
            this.SpikeSolutionListView.Location = new System.Drawing.Point(13, 56);
            this.SpikeSolutionListView.Name = "SpikeSolutionListView";
            this.SpikeSolutionListView.Size = new System.Drawing.Size(758, 473);
            this.SpikeSolutionListView.TabIndex = 10;
            this.SpikeSolutionListView.UseCompatibleStateImageBehavior = false;
            this.SpikeSolutionListView.View = System.Windows.Forms.View.Details;
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
            this.label1.Size = new System.Drawing.Size(122, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Spike Solutions";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 40);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // SpikeSolutionMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SpikeSolutionListView);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SpikeSolutionMainView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(784, 542);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewSpikeSolutionButton;
        private System.Windows.Forms.ListView SpikeSolutionListView;
        private System.Windows.Forms.ColumnHeader ProductCodeCol;
        private System.Windows.Forms.ColumnHeader ProductNameCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
