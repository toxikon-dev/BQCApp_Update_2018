namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class ReportSamplesView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.SampleNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntitialDigestedAmtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalAmtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawFileSampleCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowUserToAddRows = false;
            this.MainDataGridView.AllowUserToDeleteRows = false;
            this.MainDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.MainDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SampleNameCol,
            this.IntitialDigestedAmtCol,
            this.FinalAmtCol,
            this.Description,
            this.RawFileSampleCol});
            this.MainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.MainDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MainDataGridView.Name = "MainDataGridView";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            this.MainDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(800, 500);
            this.MainDataGridView.TabIndex = 4;
            this.MainDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.MainDataGridView_EditingControlShowing);
            // 
            // SampleNameCol
            // 
            this.SampleNameCol.HeaderText = "Sample Code";
            this.SampleNameCol.Name = "SampleNameCol";
            // 
            // IntitialDigestedAmtCol
            // 
            this.IntitialDigestedAmtCol.HeaderText = "Initial Digested Amount";
            this.IntitialDigestedAmtCol.Name = "IntitialDigestedAmtCol";
            // 
            // FinalAmtCol
            // 
            this.FinalAmtCol.HeaderText = "Final Amount";
            this.FinalAmtCol.Name = "FinalAmtCol";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // RawFileSampleCol
            // 
            this.RawFileSampleCol.HeaderText = "Raw File Sample";
            this.RawFileSampleCol.Name = "RawFileSampleCol";
            this.RawFileSampleCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RawFileSampleCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ReportSamplesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.MainDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportSamplesView";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntitialDigestedAmtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalAmtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewComboBoxColumn RawFileSampleCol;
    }
}
