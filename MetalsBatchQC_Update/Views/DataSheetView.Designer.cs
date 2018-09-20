namespace Toxikon.BatchQC.Views.UserControls
{
    partial class DataSheetView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSheetView));
            this.DataSheetTabControl = new System.Windows.Forms.TabControl();
            this.batchDetailTabPage = new System.Windows.Forms.TabPage();
            this.projectsTabPage = new System.Windows.Forms.TabPage();
            this.spikeSolutionTabPage = new System.Windows.Forms.TabPage();
            this.reagentsTabPage = new System.Windows.Forms.TabPage();
            this.SamplesTabPage = new System.Windows.Forms.TabPage();
            this.TabControlImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadLCSResultTabPage = new System.Windows.Forms.TabPage();
            this.DataSheetTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSheetTabControl
            // 
            this.DataSheetTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSheetTabControl.Controls.Add(this.batchDetailTabPage);
            this.DataSheetTabControl.Controls.Add(this.projectsTabPage);
            this.DataSheetTabControl.Controls.Add(this.spikeSolutionTabPage);
            this.DataSheetTabControl.Controls.Add(this.reagentsTabPage);
            this.DataSheetTabControl.Controls.Add(this.SamplesTabPage);
            this.DataSheetTabControl.Controls.Add(this.UploadLCSResultTabPage);
            this.DataSheetTabControl.ImageList = this.TabControlImageList;
            this.DataSheetTabControl.Location = new System.Drawing.Point(0, 0);
            this.DataSheetTabControl.Name = "DataSheetTabControl";
            this.DataSheetTabControl.SelectedIndex = 0;
            this.DataSheetTabControl.Size = new System.Drawing.Size(784, 539);
            this.DataSheetTabControl.TabIndex = 0;
            this.DataSheetTabControl.SelectedIndexChanged += new System.EventHandler(this.dataSheetTabControl_SelectedIndexChanged);
            // 
            // batchDetailTabPage
            // 
            this.batchDetailTabPage.ImageIndex = 0;
            this.batchDetailTabPage.Location = new System.Drawing.Point(4, 30);
            this.batchDetailTabPage.Name = "batchDetailTabPage";
            this.batchDetailTabPage.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.batchDetailTabPage.Size = new System.Drawing.Size(776, 505);
            this.batchDetailTabPage.TabIndex = 0;
            this.batchDetailTabPage.Text = "Batch Detail";
            this.batchDetailTabPage.UseVisualStyleBackColor = true;
            // 
            // projectsTabPage
            // 
            this.projectsTabPage.ImageIndex = 2;
            this.projectsTabPage.Location = new System.Drawing.Point(4, 30);
            this.projectsTabPage.Name = "projectsTabPage";
            this.projectsTabPage.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.projectsTabPage.Size = new System.Drawing.Size(776, 505);
            this.projectsTabPage.TabIndex = 1;
            this.projectsTabPage.Text = "Projects";
            this.projectsTabPage.UseVisualStyleBackColor = true;
            // 
            // spikeSolutionTabPage
            // 
            this.spikeSolutionTabPage.ImageIndex = 3;
            this.spikeSolutionTabPage.Location = new System.Drawing.Point(4, 30);
            this.spikeSolutionTabPage.Name = "spikeSolutionTabPage";
            this.spikeSolutionTabPage.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.spikeSolutionTabPage.Size = new System.Drawing.Size(776, 505);
            this.spikeSolutionTabPage.TabIndex = 2;
            this.spikeSolutionTabPage.Text = "Spike Solutions";
            this.spikeSolutionTabPage.UseVisualStyleBackColor = true;
            // 
            // reagentsTabPage
            // 
            this.reagentsTabPage.ImageIndex = 3;
            this.reagentsTabPage.Location = new System.Drawing.Point(4, 30);
            this.reagentsTabPage.Name = "reagentsTabPage";
            this.reagentsTabPage.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.reagentsTabPage.Size = new System.Drawing.Size(776, 505);
            this.reagentsTabPage.TabIndex = 3;
            this.reagentsTabPage.Text = "Reagents";
            this.reagentsTabPage.UseVisualStyleBackColor = true;
            // 
            // SamplesTabPage
            // 
            this.SamplesTabPage.ImageIndex = 4;
            this.SamplesTabPage.Location = new System.Drawing.Point(4, 30);
            this.SamplesTabPage.Name = "SamplesTabPage";
            this.SamplesTabPage.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.SamplesTabPage.Size = new System.Drawing.Size(776, 505);
            this.SamplesTabPage.TabIndex = 4;
            this.SamplesTabPage.Text = "Samples";
            this.SamplesTabPage.UseVisualStyleBackColor = true;
            // 
            // TabControlImageList
            // 
            this.TabControlImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabControlImageList.ImageStream")));
            this.TabControlImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TabControlImageList.Images.SetKeyName(0, "CommentCode_16x.png");
            this.TabControlImageList.Images.SetKeyName(1, "RSReport_32xLG.png");
            this.TabControlImageList.Images.SetKeyName(2, "project_control_on_32x32.png");
            this.TabControlImageList.Images.SetKeyName(3, "test_32x_LG.png");
            this.TabControlImageList.Images.SetKeyName(4, "RunTests_8790.png");
            // 
            // UploadLCSResultTabPage
            // 
            this.UploadLCSResultTabPage.Location = new System.Drawing.Point(4, 30);
            this.UploadLCSResultTabPage.Name = "UploadLCSResultTabPage";
            this.UploadLCSResultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UploadLCSResultTabPage.Size = new System.Drawing.Size(776, 505);
            this.UploadLCSResultTabPage.TabIndex = 5;
            this.UploadLCSResultTabPage.Text = "Upload LCS Result";
            this.UploadLCSResultTabPage.UseVisualStyleBackColor = true;
            // 
            // DataSheetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DataSheetTabControl);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DataSheetView";
            this.Size = new System.Drawing.Size(784, 542);
            this.DataSheetTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DataSheetTabControl;
        private System.Windows.Forms.TabPage batchDetailTabPage;
        private System.Windows.Forms.TabPage projectsTabPage;
        private System.Windows.Forms.TabPage spikeSolutionTabPage;
        private System.Windows.Forms.TabPage reagentsTabPage;
        private System.Windows.Forms.TabPage SamplesTabPage;
        private System.Windows.Forms.ImageList TabControlImageList;
        private System.Windows.Forms.TabPage UploadLCSResultTabPage;


    }
}
