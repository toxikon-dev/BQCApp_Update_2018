namespace Toxikon.BatchQC.Views.Forms
{
    partial class MainView
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
            this.MainViewMenuStrip = new System.Windows.Forms.MenuStrip();
            this.BatchCodesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.batchQCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SpikeSolutionsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ReagentsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BQCReportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlChartReportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ICPReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateBatchCodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewRoleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewDepartmentButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewUserButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewInstrumentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewElementMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminUpdateUserButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFlowLayoutPanel = new System.Windows.Forms.Panel();
            this.MainViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainViewMenuStrip
            // 
            this.MainViewMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatchCodesButton,
            this.reportsToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.MainViewMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainViewMenuStrip.Name = "MainViewMenuStrip";
            this.MainViewMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MainViewMenuStrip.Size = new System.Drawing.Size(984, 29);
            this.MainViewMenuStrip.TabIndex = 0;
            this.MainViewMenuStrip.Text = "menuStrip1";
            // 
            // BatchCodesButton
            // 
            this.BatchCodesButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchQCToolStripMenuItem1,
            this.SpikeSolutionsButton,
            this.ReagentsButton});
            this.BatchCodesButton.Name = "BatchCodesButton";
            this.BatchCodesButton.Size = new System.Drawing.Size(62, 25);
            this.BatchCodesButton.Text = "Menu";
            // 
            // batchQCToolStripMenuItem1
            // 
            this.batchQCToolStripMenuItem1.Name = "batchQCToolStripMenuItem1";
            this.batchQCToolStripMenuItem1.Size = new System.Drawing.Size(187, 26);
            this.batchQCToolStripMenuItem1.Text = "Batch Codes";
            this.batchQCToolStripMenuItem1.Click += new System.EventHandler(this.BatchCodesButton_Click);
            // 
            // SpikeSolutionsButton
            // 
            this.SpikeSolutionsButton.Name = "SpikeSolutionsButton";
            this.SpikeSolutionsButton.Size = new System.Drawing.Size(187, 26);
            this.SpikeSolutionsButton.Text = "Spike Solutions";
            this.SpikeSolutionsButton.Click += new System.EventHandler(this.SpikeSolutionsButton_Click);
            // 
            // ReagentsButton
            // 
            this.ReagentsButton.Name = "ReagentsButton";
            this.ReagentsButton.Size = new System.Drawing.Size(187, 26);
            this.ReagentsButton.Text = "Reagents";
            this.ReagentsButton.Click += new System.EventHandler(this.ReagentsButton_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BQCReportsMenuItem,
            this.ControlChartReportsMenuItem,
            this.ICPReportMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // BQCReportsMenuItem
            // 
            this.BQCReportsMenuItem.Name = "BQCReportsMenuItem";
            this.BQCReportsMenuItem.Size = new System.Drawing.Size(232, 26);
            this.BQCReportsMenuItem.Text = "BQC Reports";
            this.BQCReportsMenuItem.Click += new System.EventHandler(this.BQCReportsMenuItem_Click);
            // 
            // ControlChartReportsMenuItem
            // 
            this.ControlChartReportsMenuItem.Name = "ControlChartReportsMenuItem";
            this.ControlChartReportsMenuItem.Size = new System.Drawing.Size(232, 26);
            this.ControlChartReportsMenuItem.Text = "Control Chart Reports";
            this.ControlChartReportsMenuItem.Click += new System.EventHandler(this.ControlChartReportsMenuItem_Click);
            // 
            // ICPReportMenuItem
            // 
            this.ICPReportMenuItem.Name = "ICPReportMenuItem";
            this.ICPReportMenuItem.Size = new System.Drawing.Size(232, 26);
            this.ICPReportMenuItem.Text = "ICP Report";
            this.ICPReportMenuItem.Click += new System.EventHandler(this.ICPReportMenuItem_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateBatchCodeMenuItem});
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.UpdateToolStripMenuItem.Text = "Update";
            // 
            // UpdateBatchCodeMenuItem
            // 
            this.UpdateBatchCodeMenuItem.Name = "UpdateBatchCodeMenuItem";
            this.UpdateBatchCodeMenuItem.Size = new System.Drawing.Size(158, 26);
            this.UpdateBatchCodeMenuItem.Text = "Batch Code";
            this.UpdateBatchCodeMenuItem.Click += new System.EventHandler(this.UpdateBatchCodeMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.UpdateButton});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // NewButton
            // 
            this.NewButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewRoleButton,
            this.AddNewDepartmentButton,
            this.AddNewUserButton,
            this.NewInstrumentMenuItem,
            this.NewElementMenuItem});
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(130, 26);
            this.NewButton.Text = "New";
            // 
            // AddNewRoleButton
            // 
            this.AddNewRoleButton.Name = "AddNewRoleButton";
            this.AddNewRoleButton.Size = new System.Drawing.Size(163, 26);
            this.AddNewRoleButton.Text = "Role";
            this.AddNewRoleButton.Click += new System.EventHandler(this.AddNewRoleButton_Click);
            // 
            // AddNewDepartmentButton
            // 
            this.AddNewDepartmentButton.Name = "AddNewDepartmentButton";
            this.AddNewDepartmentButton.Size = new System.Drawing.Size(163, 26);
            this.AddNewDepartmentButton.Text = "Department";
            this.AddNewDepartmentButton.Click += new System.EventHandler(this.AddNewDepartmentButton_Click);
            // 
            // AddNewUserButton
            // 
            this.AddNewUserButton.Name = "AddNewUserButton";
            this.AddNewUserButton.Size = new System.Drawing.Size(163, 26);
            this.AddNewUserButton.Text = "User";
            this.AddNewUserButton.Click += new System.EventHandler(this.AddNewUserButton_Click);
            // 
            // NewInstrumentMenuItem
            // 
            this.NewInstrumentMenuItem.Name = "NewInstrumentMenuItem";
            this.NewInstrumentMenuItem.Size = new System.Drawing.Size(163, 26);
            this.NewInstrumentMenuItem.Text = "Instrument";
            this.NewInstrumentMenuItem.Click += new System.EventHandler(this.NewInstrumentMenuItem_Click);
            // 
            // NewElementMenuItem
            // 
            this.NewElementMenuItem.Name = "NewElementMenuItem";
            this.NewElementMenuItem.Size = new System.Drawing.Size(163, 26);
            this.NewElementMenuItem.Text = "Element";
            this.NewElementMenuItem.Click += new System.EventHandler(this.NewElementMenuItem_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminUpdateUserButton});
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(130, 26);
            this.UpdateButton.Text = "Update";
            // 
            // AdminUpdateUserButton
            // 
            this.AdminUpdateUserButton.Name = "AdminUpdateUserButton";
            this.AdminUpdateUserButton.Size = new System.Drawing.Size(112, 26);
            this.AdminUpdateUserButton.Text = "User";
            this.AdminUpdateUserButton.Click += new System.EventHandler(this.AdminUpdateUserButton_Click);
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(0, 29);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(984, 542);
            this.mainFlowLayoutPanel.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 571);
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.Controls.Add(this.MainViewMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 609);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDMS - Metals";
            this.Shown += new System.EventHandler(this.MainView_Shown);
            this.MainViewMenuStrip.ResumeLayout(false);
            this.MainViewMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BatchCodesButton;
        private System.Windows.Forms.ToolStripMenuItem batchQCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SpikeSolutionsButton;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReagentsButton;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewButton;
        private System.Windows.Forms.ToolStripMenuItem UpdateButton;
        private System.Windows.Forms.ToolStripMenuItem AddNewRoleButton;
        private System.Windows.Forms.ToolStripMenuItem AddNewDepartmentButton;
        private System.Windows.Forms.ToolStripMenuItem AddNewUserButton;
        private System.Windows.Forms.Panel mainFlowLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem NewInstrumentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewElementMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ControlChartReportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BQCReportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminUpdateUserButton;
        private System.Windows.Forms.ToolStripMenuItem UpdateBatchCodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ICPReportMenuItem;



    }
}