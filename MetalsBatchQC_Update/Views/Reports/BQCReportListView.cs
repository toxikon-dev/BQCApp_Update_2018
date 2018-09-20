using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Reports;
using Toxikon.BatchQC.Controllers.Reports;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Views.Reports
{
    public partial class BQCReportListView : UserControl, IBQCReportListView
    {
        BQCReportListViewController controller;

        public BQCReportListView()
        {
            InitializeComponent();
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public void SetController(BQCReportListViewController controller)
        {
            this.controller = controller;
        }

        public void AddProjectToListView(Project project)
        {
            ListViewItem item = this.ProjectListView.Items.Add(project.ProjectNumber);
            item.SubItems.Add(project.MethodCode);
            item.SubItems.Add(project.SponsorName);
            item.SubItems.Add(project.StudyDirector);
        }

        private void ProjectListView_DoubleClick(object sender, EventArgs e)
        {
            if(this.ProjectListView.SelectedIndices.Count > 0)
            {
                this.controller.ProjectListViewDoubleClicked(this.ProjectListView.SelectedIndices[0]);
            }
        }

        public void ClearProjectListView()
        {
            this.ProjectListView.Items.Clear();
        }
    }
}
