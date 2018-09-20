using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Interfaces;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class ProjectsView : UserControl, IProjectsView
    {
        private ProjectsController _controller;
        public Control ParentControl { get; private set; }

        public ProjectsView()
        {
            InitializeComponent();
            this.ParentControl = this.Parent;
        }

        public void SetController(ProjectsController controller)
        {
            _controller = controller;
        }

        public void ShowDeleteButton(bool value)
        {
            this.DeleteButton.Visible = value;
        }

        public void AddItemToListView(Project project)
        {
            ListViewItem parent;
            parent = this.projectsListView.Items.Add(project.ProjectNumber);
            parent.SubItems.Add(project.SponsorName);
            parent.SubItems.Add(project.StudyDirector);
        }

        public void RemoveItemFromListViewAt(int itemIndex)
        {
            this.projectsListView.Items.RemoveAt(itemIndex);
        }

        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            if(this.searchTextBox.Text.Trim() != "")
            {
                _controller.AddButtonClicked(this.searchTextBox.Text.Trim());
            }
            else
            {
                MessageBox.Show("Project number is required.");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (this.projectsListView.SelectedItems.Count != 0)
            {
                _controller.DeleteButtonClicked(this.projectsListView.SelectedItems[0].Index);
            }
            else
            {
                MessageBox.Show("Please select an item and try it again.");
            }
        }
    }
}
