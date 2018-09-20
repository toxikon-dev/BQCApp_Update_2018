namespace Toxikon.BatchQC.Views.Results
{
    partial class UploadResultView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadResultView));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ElementDataGridView = new System.Windows.Forms.DataGridView();
            this.RunIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrumentIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BrowseButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "LCS Results";
            // 
           
            // 
            // ElementDataGridView
            // 
            this.ElementDataGridView.AllowUserToAddRows = false;
            this.ElementDataGridView.AllowUserToDeleteRows = false;
            this.ElementDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElementDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ElementDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ElementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RunIDCol,
            this.InstrumentIDCol,
            this.ElementCol,
            this.ResultCol,
            this.UnitCol});
            this.ElementDataGridView.Location = new System.Drawing.Point(18, 64);
            this.ElementDataGridView.MultiSelect = false;
            this.ElementDataGridView.Name = "ElementDataGridView";
            this.ElementDataGridView.Size = new System.Drawing.Size(745, 431);
            this.ElementDataGridView.TabIndex = 5;
            // 
            // RunIDCol
            // 
            this.RunIDCol.HeaderText = "Run ID";
            this.RunIDCol.Name = "RunIDCol";
            // 
            // InstrumentIDCol
            // 
            this.InstrumentIDCol.HeaderText = "Instrument ID";
            this.InstrumentIDCol.Name = "InstrumentIDCol";
            // 
            // ElementCol
            // 
            this.ElementCol.FillWeight = 99.49239F;
            this.ElementCol.HeaderText = "Element";
            this.ElementCol.Name = "ElementCol";
            // 
            // ResultCol
            // 
            this.ResultCol.FillWeight = 99.49239F;
            this.ResultCol.HeaderText = "Result";
            this.ResultCol.Name = "ResultCol";
            // 
            // UnitCol
            // 
            this.UnitCol.FillWeight = 99.49239F;
            this.UnitCol.HeaderText = "Unit";
            this.UnitCol.Name = "UnitCol";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmitButton,
            this.toolStripSeparator1,
            this.BrowseButton});
            this.toolStrip1.Location = new System.Drawing.Point(530, 14);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(233, 28);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmitButton.Image = ((System.Drawing.Image)(resources.GetObject("SubmitButton.Image")));
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(77, 25);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BrowseButton.Image = ((System.Drawing.Image)(resources.GetObject("BrowseButton.Image")));
            this.BrowseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(147, 25);
            this.BrowseButton.Text = "Browse Result File";
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // UploadResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ElementDataGridView);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UploadResultView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(776, 508);
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView ElementDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BrowseButton;
        private System.Windows.Forms.ToolStripButton SubmitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunIDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentIDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCol;
    }
}
