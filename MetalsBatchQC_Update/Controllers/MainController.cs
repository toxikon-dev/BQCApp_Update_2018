using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Admin;
using Toxikon.BatchQC.Controllers.Reports;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Views;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Reports;
using Toxikon.BatchQC.Views.Admin;
using Toxikon.BatchQC.Views.Forms;
using Toxikon.BatchQC.Views.ICPRC;
using Toxikon.BatchQC.Views.Reports;
using Toxikon.BatchQC.Views.UserControls;

namespace Toxikon.BatchQC.Controllers
{
    public class MainController
    {
        IMainView mainView;
        List<SpikeSolution> spikeSolutionList;

        public MainController(IMainView view)
        {
            this.mainView = view;
            this.mainView.SetController(this);

            spikeSolutionList = new List<SpikeSolution>() { };
        }

        public void LoadView()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            if(loginInfo.RoleID != 1)
            {
                mainView.ShowAdminMenuItems(false);
            }
            LoadBatchCodeListView();
        }

        public void LoadDataSheetView()
        {
            try
            {
                DataSheetView dataSheetView = new DataSheetView();
                DataSheetController dataSheetController = new DataSheetController(dataSheetView);
                dataSheetController.LoadBatchDetailView();

                mainView.AddControlToMainPanel(dataSheetView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadSpikeSolutionAddView()
        {
            SpikeSolutionAddView view = new SpikeSolutionAddView();
            SpikeSolutionAddController viewController = new SpikeSolutionAddController(view);

            mainView.AddControlToMainPanel(view);
        }

        public void LoadReagentAddView()
        {
            ReagentAddView subView = new ReagentAddView();
            ReagentAddController subViewController = new ReagentAddController(subView);
            mainView.AddControlToMainPanel(subView);
        }

        public void LoadBatchCodeAddView()
        {
            BatchCodeAddView subView = new BatchCodeAddView();
            BatchCodeAddController subViewController = new BatchCodeAddController(subView);
            subViewController.LoadView();

            mainView.AddControlToMainPanel(subView);
        }

        public void AddNewRoleButtonClicked()
        {
            RoleAddView subView = new RoleAddView();
            RoleAddController subViewController = new RoleAddController(subView);
            mainView.AddControlToMainPanel(subView);
        }

        public void AddNewDepartmentButtonClicked()
        {
            DepartmentAddView subView = new DepartmentAddView();
            DepartmentAddController subViewController = new DepartmentAddController(subView);
            subViewController.LoadView();
            mainView.AddControlToMainPanel(subView);
        }

        public void AddNewUserButtonClicked()
        {
            UserAddView subView = new UserAddView();
            UserAddController subViewController = new UserAddController(subView);
            subViewController.LoadView();
            mainView.AddControlToMainPanel(subView);
        }

        public void BatchCodesButtonClicked()
        {
            try
            {
                LoadBatchCodeListView();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadBatchCodeListView()
        {
            BatchCodeListView subView = new BatchCodeListView();
            BatchCodeListController subViewController = new BatchCodeListController(subView);
            subViewController.LoadView();

            mainView.AddControlToMainPanel(subView);
        }

        public void ReagentsButtonClicked()
        {
            try
            {
                ReagentsMainView subView = new ReagentsMainView();
                ReagentsMainViewController subViewController = new ReagentsMainViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SpikeSolutionsButtonClicked()
        {
            try
            {
                SpikeSolutionMainView subView = new SpikeSolutionMainView();
                SpikeSolutionMainViewController subViewController = new SpikeSolutionMainViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void BQCReportsMenuItemClicked()
        {
            try
            {
                BQCReportListView subView = new BQCReportListView();
                BQCReportListViewController subViewController = new BQCReportListViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadBQCReportView()
        {
            try
            {
                BQCReportView subView = new BQCReportView();
                BQCReportViewController subViewController = new BQCReportViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void NewInstrumentButtonClicked()
        {
            try
            {
                InstrumentAddView subView = new InstrumentAddView();
                InstrumentAddViewController subViewController = new InstrumentAddViewController(subView);
                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void NewElementButtonClicked()
        {
            try
            {
                ElementAddView subView = new ElementAddView();
                ElementAddViewController subViewController = new ElementAddViewController(subView);
                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ControlChartReportsMenuItemClicked()
        {
            try
            {
                ControlChartReportView subView = new ControlChartReportView();
                ControlChartReportViewController subViewController = new ControlChartReportViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AdminUpdateUserButtonClicked()
        {
            try
            {
                UserUpdateView subView = new UserUpdateView();
                UserUpdateViewController subViewController = new UserUpdateViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateBatchCodeButtonClicked()
        {
            try
            {
                BatchCodeUpdateView subView = new BatchCodeUpdateView();
                BatchCodeUpdateViewController subViewController = new BatchCodeUpdateViewController(subView);
                subViewController.LoadView();

                mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ICPReportMenuItemClicked()
        {
            try
            {
                ReportHeaderListView subView = new ReportHeaderListView();
                ReportHeaderListViewController subViewController = new ReportHeaderListViewController(subView);
                subViewController.LoadView();

                this.mainView.AddControlToMainPanel(subView);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadReportBuilderView()
        {
            ReportBuilderView subView = new ReportBuilderView();
            ReportBuilderViewController subViewController = new ReportBuilderViewController(subView);
            subViewController.LoadView();

            mainView.AddControlToMainPanel(subView);
        }
    }
}
