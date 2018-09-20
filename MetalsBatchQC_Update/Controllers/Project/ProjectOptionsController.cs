using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class ProjectOptionsController
    {
        IProjectOptionsView _view;
        IList _projects;

        Project _selectedProject;

        public ProjectOptionsController(IProjectOptionsView view, IList projects)
        {
            _view = view;
            _view.SelectedProjectNumber = "";
            _projects = projects;

            _view.SetController(this);
        }

        public Project SelectedProject
        {
            get
            {
                return this._selectedProject;
            }
        }

        public void LoadView()
        {
            foreach(Project project in _projects)
            {
                _view.AddProjectToListView(project);
            }
        }

        public void SelectedIndexChanged()
        {
            foreach(Project project in _projects)
            {
                if(project.ProjectNumber == _view.SelectedProjectNumber)
                {
                    _selectedProject = project;
                    break;
                }
            }
        }

        public void AddButtonClicked()
        {
            if(IsValidSelectedID())
            {
                _view.SetDialogResult(DialogResult.OK);
            }
            else
            {
                ShowInvalidValueMessageBox("Please select one project number.");
            }
        }

        private bool IsValidSelectedID()
        {
            bool result = true;
            if(_view.SelectedProjectNumber == "")
            {
                result = false;
            }
            return result;
        }

        private void ShowInvalidValueMessageBox(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                _view.SetDialogResult(DialogResult.Retry);
            }
        }
    }
}
