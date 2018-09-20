using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class ProjectOptionsView : Form, IProjectOptionsView
    {
        ProjectOptionsController _controller;
        public string SelectedProjectNumber { get; set; }

        public ProjectOptionsView()
        {
            InitializeComponent();
        }

        public void SetController(ProjectOptionsController controller)
        {
            _controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void AddProjectToListView(Project project)
        {
            ListViewItem item;
            item = this.projectListView.Items.Add(project.ProjectNumber);
            item.SubItems.Add(project.SponsorName);
        }

        private void projectListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.projectListView.SelectedIndices.Count > 0)
            {
                SelectedProjectNumber = this.projectListView.SelectedItems[0].Text;
                _controller.SelectedIndexChanged();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _controller.AddButtonClicked();
        }

        private void ProjectOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
