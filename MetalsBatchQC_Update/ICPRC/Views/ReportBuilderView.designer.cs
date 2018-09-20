namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class ReportBuilderView
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ReportSampleTabPage = new System.Windows.Forms.TabPage();
            this.ElementsTabPage = new System.Windows.Forms.TabPage();
            this.RawFileSamplesTabPage = new System.Windows.Forms.TabPage();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.SampleResultsTabPage = new System.Windows.Forms.TabPage();
            this.BQCReportTabPage = new System.Windows.Forms.TabPage();
            this.ProjectInfoLabel = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ReportSampleTabPage
            // 
            this.ReportSampleTabPage.Location = new System.Drawing.Point(4, 30);
            this.ReportSampleTabPage.Name = "ReportSampleTabPage";
            this.ReportSampleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReportSampleTabPage.Size = new System.Drawing.Size(776, 468);
            this.ReportSampleTabPage.TabIndex = 2;
            this.ReportSampleTabPage.Text = "Report Samples";
            this.ReportSampleTabPage.UseVisualStyleBackColor = true;
            // 
            // ElementsTabPage
            // 
            this.ElementsTabPage.Location = new System.Drawing.Point(4, 30);
            this.ElementsTabPage.Name = "ElementsTabPage";
            this.ElementsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ElementsTabPage.Size = new System.Drawing.Size(776, 468);
            this.ElementsTabPage.TabIndex = 1;
            this.ElementsTabPage.Text = "Elements";
            this.ElementsTabPage.UseVisualStyleBackColor = true;
            // 
            // RawFileSamplesTabPage
            // 
            this.RawFileSamplesTabPage.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawFileSamplesTabPage.Location = new System.Drawing.Point(4, 30);
            this.RawFileSamplesTabPage.Name = "RawFileSamplesTabPage";
            this.RawFileSamplesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RawFileSamplesTabPage.Size = new System.Drawing.Size(776, 468);
            this.RawFileSamplesTabPage.TabIndex = 0;
            this.RawFileSamplesTabPage.Text = "Raw File Samples";
            this.RawFileSamplesTabPage.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.RawFileSamplesTabPage);
            this.MainTabControl.Controls.Add(this.ElementsTabPage);
            this.MainTabControl.Controls.Add(this.ReportSampleTabPage);
            this.MainTabControl.Controls.Add(this.SampleResultsTabPage);
            this.MainTabControl.Controls.Add(this.BQCReportTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(0, 40);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(784, 502);
            this.MainTabControl.TabIndex = 1;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // SampleResultsTabPage
            // 
            this.SampleResultsTabPage.Location = new System.Drawing.Point(4, 30);
            this.SampleResultsTabPage.Name = "SampleResultsTabPage";
            this.SampleResultsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SampleResultsTabPage.Size = new System.Drawing.Size(776, 468);
            this.SampleResultsTabPage.TabIndex = 3;
            this.SampleResultsTabPage.Text = "Sample Results";
            this.SampleResultsTabPage.UseVisualStyleBackColor = true;
            // 
            // BQCReportTabPage
            // 
            this.BQCReportTabPage.Location = new System.Drawing.Point(4, 30);
            this.BQCReportTabPage.Name = "BQCReportTabPage";
            this.BQCReportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BQCReportTabPage.Size = new System.Drawing.Size(776, 468);
            this.BQCReportTabPage.TabIndex = 4;
            this.BQCReportTabPage.Text = "BQC Report";
            this.BQCReportTabPage.UseVisualStyleBackColor = true;
            // 
            // ProjectInfoLabel
            // 
            this.ProjectInfoLabel.AutoSize = true;
            this.ProjectInfoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectInfoLabel.Location = new System.Drawing.Point(4, 4);
            this.ProjectInfoLabel.Name = "ProjectInfoLabel";
            this.ProjectInfoLabel.Size = new System.Drawing.Size(96, 21);
            this.ProjectInfoLabel.TabIndex = 2;
            this.ProjectInfoLabel.Text = "Project Info";
            // 
            // ReportBuilderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ProjectInfoLabel);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportBuilderView";
            this.Size = new System.Drawing.Size(784, 542);
            this.MainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage ReportSampleTabPage;
        private System.Windows.Forms.TabPage ElementsTabPage;
        private System.Windows.Forms.TabPage RawFileSamplesTabPage;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage SampleResultsTabPage;
        private System.Windows.Forms.Label ProjectInfoLabel;
        private System.Windows.Forms.TabPage BQCReportTabPage;
    }
}
