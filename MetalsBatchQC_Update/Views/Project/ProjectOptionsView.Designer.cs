namespace Toxikon.BatchQC.Views.Forms
{
    partial class ProjectOptionsView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.projectListView = new System.Windows.Forms.ListView();
            this.projectNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sponsorNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectListView
            // 
            this.projectListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.projectNumberColumn,
            this.sponsorNameColumn});
            this.projectListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectListView.FullRowSelect = true;
            this.projectListView.GridLines = true;
            this.projectListView.Location = new System.Drawing.Point(0, 0);
            this.projectListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectListView.Name = "projectListView";
            this.projectListView.Size = new System.Drawing.Size(533, 201);
            this.projectListView.TabIndex = 1;
            this.projectListView.UseCompatibleStateImageBehavior = false;
            this.projectListView.View = System.Windows.Forms.View.Details;
            this.projectListView.SelectedIndexChanged += new System.EventHandler(this.projectListView_SelectedIndexChanged);
            // 
            // projectNumberColumn
            // 
            this.projectNumberColumn.Text = "Project Number";
            this.projectNumberColumn.Width = 143;
            // 
            // sponsorNameColumn
            // 
            this.sponsorNameColumn.Text = "Sponsor Name";
            this.sponsorNameColumn.Width = 390;
            // 
            // addButton
            // 
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Location = new System.Drawing.Point(433, 219);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 38);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ProjectOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 269);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.projectListView);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjectOptionsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectOptionsView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectOptionsView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView projectListView;
        private System.Windows.Forms.ColumnHeader projectNumberColumn;
        private System.Windows.Forms.ColumnHeader sponsorNameColumn;
        private System.Windows.Forms.Button addButton;
    }
}