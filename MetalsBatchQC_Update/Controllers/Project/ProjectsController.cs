using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Views.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class ProjectsController
    {
        IProjectsView _view;
        DataSheet dataSheet;
        Project searchedProject;
        LoginInfo loginInfo;

        public ProjectsController()
        {

        }

        public ProjectsController(IProjectsView view)
        {
            _view = view;
            dataSheet = DataSheet.GetInstance();
            _view.SetController(this);

            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            HideDeleteButton();
            foreach(Project project in dataSheet.Projects)
            {
                _view.AddItemToListView(project);
            }
        }

        private void HideDeleteButton()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            if (loginInfo.RoleID != 1)
            {
                this._view.ShowDeleteButton(false);
            }
        }

        public void AddButtonClicked(string searchString)
        {
            try
            {
                SearchProject(searchString);
                if (searchedProject.ProjectNumber == "")
                {
                    MessageBox.Show("Invalid project number.");
                }
                else
                {
                    Project project = CreateNewProject(dataSheet.BatchCode.MethodCode);
                    dataSheet.AddProject(project);
                    _view.AddItemToListView(project);
                    Int32 insertResult = BATCHQC_INSERT.InsertBatchProject(project);
                    InsertProjectIntoBQCReport(project, loginInfo.UserName);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SearchProject(string searchString)
        {
            searchedProject = LIMS_Queries.SearchProjectNumber(searchString);
        }
       
        public Project CreateNewProject(string methodCode)
        {
            Project project = new Project();
            project.MethodCode = methodCode;
            project.ProjectNumber = searchedProject.ProjectNumber;
            project.StudyDirector = searchedProject.StudyDirector;
            project.StudyCode = searchedProject.StudyCode;
            project.StudyName = searchedProject.StudyName;
            project.SponsorCode = searchedProject.SponsorCode;
            project.SponsorName = searchedProject.SponsorName;
            return project;
        }

        public void InsertProjectIntoBQCReport(Project project, string userName)
        {
            Int32 dbSearchResult = BATCHQC_SEARCH.SearchProjectFromBQCReport(project);
            if(dbSearchResult == 0)
            {
                Int32 dbInsertResult = BATCHQC_INSERT.InsertBQCReport(project, userName);
            }
        }

        public void DeleteButtonClicked(int itemIndex)
        {
            try
            {
                Project selectedProject = (Project)dataSheet.Projects[itemIndex];
                ProjectDeleteView deleteView = new ProjectDeleteView();
                ProjectDeleteController controller = new ProjectDeleteController(deleteView, selectedProject);
                controller.LoadView();

                DialogResult dialogResult = deleteView.ShowDialog(_view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    dataSheet.Projects.RemoveAt(itemIndex);
                    _view.RemoveItemFromListViewAt(itemIndex);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
