using Toxikon.BatchQC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Views.UserControls;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Interfaces;

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class MainView : Form, IMainView
    {
        MainController mainController;

        public delegate void LoadDataSheet();
        public LoadDataSheet loadDataSheetDelegate;

        public delegate void LoadBatchCodeAddView();
        public LoadBatchCodeAddView loadBatchCodeAddViewDelegate;

        public delegate void LoadBatchCodeListView();
        public LoadBatchCodeListView loadBatchCodeListViewDelegate;

        public delegate void LoadReagentAddView();
        public LoadReagentAddView loadReagentAddViewDelegate;

        public delegate void LoadSpikeSolutionAddView();
        public LoadSpikeSolutionAddView loadSpikeSolutionAddViewDelegate;

        public delegate void LoadBQCReportView();
        public LoadBQCReportView loadBQCReportViewDelegate;

        public delegate void LoadReportBuilderView();
        public LoadReportBuilderView loadReportBuilderViewDelegate;

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = this.MainViewMenuStrip;
            Application.DoEvents();
        }

        public void SetController(MainController controller)
        {
            mainController = controller;
            loadDataSheetDelegate = new LoadDataSheet(mainController.LoadDataSheetView);
            loadBatchCodeAddViewDelegate = new LoadBatchCodeAddView(mainController.LoadBatchCodeAddView);
            loadReagentAddViewDelegate = new LoadReagentAddView(mainController.LoadReagentAddView);
            loadSpikeSolutionAddViewDelegate = new LoadSpikeSolutionAddView(mainController.LoadSpikeSolutionAddView);
            loadBatchCodeListViewDelegate = new LoadBatchCodeListView(mainController.LoadBatchCodeListView);
            loadBQCReportViewDelegate = new LoadBQCReportView(mainController.LoadBQCReportView);
            this.loadReportBuilderViewDelegate = new LoadReportBuilderView(mainController.LoadReportBuilderView);
        }

        public void AddControlToMainPanel(Control control)
        {
            this.mainFlowLayoutPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.mainFlowLayoutPanel.Controls.Add(control);
        }

        public void ShowAdminMenuItems(bool value)
        {
            this.adminToolStripMenuItem.Visible = value;
        }

        private void showRecentActivitiesForm()
        {
            HistoryView historyView = new HistoryView();
            mainFlowLayoutPanel.Controls.Add(historyView);
        }

        private void AddNewRoleButton_Click(object sender, EventArgs e)
        {
            mainController.AddNewRoleButtonClicked();
        }

        private void AddNewDepartmentButton_Click(object sender, EventArgs e)
        {
            mainController.AddNewDepartmentButtonClicked();
        }

        private void AddNewUserButton_Click(object sender, EventArgs e)
        {
            mainController.AddNewUserButtonClicked();
        }

        private void BatchCodesButton_Click(object sender, EventArgs e)
        {
            mainController.BatchCodesButtonClicked();
        }

        private void ReagentsButton_Click(object sender, EventArgs e)
        {
            mainController.ReagentsButtonClicked();
        }

        private void SpikeSolutionsButton_Click(object sender, EventArgs e)
        {
            mainController.SpikeSolutionsButtonClicked();
        }

        private void BQCReportsMenuItem_Click(object sender, EventArgs e)
        {
            mainController.BQCReportsMenuItemClicked();
        }

        private void NewInstrumentMenuItem_Click(object sender, EventArgs e)
        {
            mainController.NewInstrumentButtonClicked();
        }

        private void NewElementMenuItem_Click(object sender, EventArgs e)
        {
            mainController.NewElementButtonClicked();
        }

        private void ControlChartReportsMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ControlChartReportsMenuItemClicked();
        }

        private void AdminUpdateUserButton_Click(object sender, EventArgs e)
        {
            mainController.AdminUpdateUserButtonClicked();
        }

        private void UpdateBatchCodeMenuItem_Click(object sender, EventArgs e)
        {
            mainController.UpdateBatchCodeButtonClicked();
        }

        private void ICPReportMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ICPReportMenuItemClicked();
        }
    }
}
