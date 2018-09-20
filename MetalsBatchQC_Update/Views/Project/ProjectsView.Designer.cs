namespace Toxikon.BatchQC.Views.UserControls
{
    partial class ProjectsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsView));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.addProjectButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.projectsListView = new System.Windows.Forms.ListView();
            this.projectNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sponsorNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StudyDirectorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.searchTextBox,
            this.addProjectButton,
            this.DeleteButton});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 10, 1, 10);
            this.toolStrip3.Size = new System.Drawing.Size(776, 49);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(162, 26);
            this.toolStripLabel1.Text = "Enter Project Number: ";
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 29);
            // 
            // addProjectButton
            // 
            this.addProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("addProjectButton.Image")));
            this.addProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(108, 26);
            this.addProjectButton.Text = "Add Project";
            this.addProjectButton.Click += new System.EventHandler(this.AddProjectButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(73, 26);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // projectsListView
            // 
            this.projectsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.projectNumberColumn,
            this.sponsorNameColumn,
            this.StudyDirectorCol});
            this.projectsListView.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectsListView.FullRowSelect = true;
            this.projectsListView.GridLines = true;
            this.projectsListView.Location = new System.Drawing.Point(0, 49);
            this.projectsListView.Name = "projectsListView";
            this.projectsListView.Size = new System.Drawing.Size(773, 446);
            this.projectsListView.TabIndex = 2;
            this.projectsListView.UseCompatibleStateImageBehavior = false;
            this.projectsListView.View = System.Windows.Forms.View.Details;
            // 
            // projectNumberColumn
            // 
            this.projectNumberColumn.Text = "Project Number";
            this.projectNumberColumn.Width = 195;
            // 
            // sponsorNameColumn
            // 
            this.sponsorNameColumn.Text = "Sponsor Name";
            this.sponsorNameColumn.Width = 312;
            // 
            // StudyDirectorCol
            // 
            this.StudyDirectorCol.Text = "Study Director";
            this.StudyDirectorCol.Width = 189;
            // 
            // ProjectsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.projectsListView);
            this.Controls.Add(this.toolStrip3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProjectsView";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Size = new System.Drawing.Size(776, 508);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton addProjectButton;
        private System.Windows.Forms.ListView projectsListView;
        private System.Windows.Forms.ColumnHeader projectNumberColumn;
        private System.Windows.Forms.ColumnHeader sponsorNameColumn;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ColumnHeader StudyDirectorCol;
    }
}
