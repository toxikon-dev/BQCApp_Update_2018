using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Reports;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.Reports;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.Controllers.Reports
{
    public class BQCReportListViewController
    {
        IBQCReportListView view;
        IList projects;
        LoginInfo loginInfo;

        public BQCReportListViewController(IBQCReportListView view)
        {
            this.view = view;
            this.view.SetController(this);
            projects = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            LoadProjects();
            AddProjectsToView();
        }

        private void LoadProjects()
        {
            switch(loginInfo.RoleID)
            {
                case 1:
                    projects = BATCHQC_REPORT.GetActiveBQCReportForAnalyst();
                    break;
                case 2:
                    projects = BATCHQC_REPORT.GetActiveBQCReportForAnalyst();
                    break;
                default:
                    break;
            }
        }

        private void AddProjectsToView()
        {
            foreach (Project item in projects)
            {
                this.view.AddProjectToListView(item);
            }
        }

        public void ProjectListViewDoubleClicked(int index)
        {
            try
            {
                Project selectedProject = (Project)projects[index];

                BQCReport report = BQCReport.GetInstance();
                report.SetMethod(selectedProject.MethodCode);
                report.SetProjectNumber(selectedProject.ProjectNumber);
                report.Load();

                MainView mainView = (MainView)view.ParentControl;
                mainView.Invoke(mainView.loadBQCReportViewDelegate);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
