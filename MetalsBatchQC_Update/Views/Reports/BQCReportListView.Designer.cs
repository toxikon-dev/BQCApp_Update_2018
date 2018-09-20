namespace Toxikon.BatchQC.Views.Reports
{
    partial class BQCReportListView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectListView = new System.Windows.Forms.ListView();
            this.ProjectNumberCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SponsorNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StudyDirectorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MethodCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Projects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Double click on a project below to open BQC Report";
            // 
            // ProjectListView
            // 
            this.ProjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProjectNumberCol,
            this.MethodCodeCol,
            this.SponsorNameCol,
            this.StudyDirectorCol});
            this.ProjectListView.FullRowSelect = true;
            this.ProjectListView.GridLines = true;
            this.ProjectListView.Location = new System.Drawing.Point(17, 59);
            this.ProjectListView.Name = "ProjectListView";
            this.ProjectListView.Size = new System.Drawing.Size(754, 470);
            this.ProjectListView.TabIndex = 2;
            this.ProjectListView.UseCompatibleStateImageBehavior = false;
            this.ProjectListView.View = System.Windows.Forms.View.Details;
            this.ProjectListView.DoubleClick += new System.EventHandler(this.ProjectListView_DoubleClick);
            // 
            // ProjectNumberCol
            // 
            this.ProjectNumberCol.Text = "Project Number";
            this.ProjectNumberCol.Width = 184;
            // 
            // SponsorNameCol
            // 
            this.SponsorNameCol.Text = "Sponsor Name";
            this.SponsorNameCol.Width = 257;
            // 
            // StudyDirectorCol
            // 
            this.StudyDirectorCol.Text = "Study Director";
            this.StudyDirectorCol.Width = 165;
            // 
            // MethodCodeCol
            // 
            this.MethodCodeCol.Text = "Method Code";
            this.MethodCodeCol.Width = 133;
            // 
            // BQCReportListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ProjectListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BQCReportListView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(784, 542);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ProjectListView;
        private System.Windows.Forms.ColumnHeader ProjectNumberCol;
        private System.Windows.Forms.ColumnHeader SponsorNameCol;
        private System.Windows.Forms.ColumnHeader StudyDirectorCol;
        private System.Windows.Forms.ColumnHeader MethodCodeCol;
    }
}
