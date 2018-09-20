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
using Toxikon.BatchQC.Views.Results;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class DataSheetView : UserControl, IDataSheetView
    {
        private DataSheetController _controller;
        public bool IsBatchDetailViewLoaded { get; set; }
        public bool IsProjectsViewLoaded { get; set; }
        public bool IsSpikeSolutionViewLoaded { get; set; }
        public bool IsReagentsViewLoaded { get; set; }
        public bool IsSampleViewLoaded { get; set; }
        public bool IsUploadLCSResultLoaded { get; set; }

        public DataSheetView()
        {
            InitializeComponent();
        }

        public void SetController(DataSheetController controller)
        {
            this._controller = controller;
        }

        public void AddToBatchDetailTabPage(BatchDetailView batchDetailView)
        {
            this.batchDetailTabPage.Controls.Clear();
            batchDetailView.Dock = DockStyle.Fill;
            this.batchDetailTabPage.Controls.Add(batchDetailView);
        }

        public void AddToProjectsTabPage(ProjectsView projectsView)
        {
            this.projectsTabPage.Controls.Clear();
            projectsView.Dock = DockStyle.Fill;
            this.projectsTabPage.Controls.Add(projectsView);
        }

        public void AddToSpikeSolutionTabPage(SpikeSolutionView spikeSolutionView)
        {
            this.spikeSolutionTabPage.Controls.Clear();
            spikeSolutionView.Dock = DockStyle.Fill;
            this.spikeSolutionTabPage.Controls.Add(spikeSolutionView);
        }

        public void AddToReagentsTabPage(ReagentsView reagentsView)
        {
            this.reagentsTabPage.Controls.Clear();
            reagentsView.Dock = DockStyle.Fill;
            this.reagentsTabPage.Controls.Add(reagentsView);
        }

        public void AddToSamplesTabPage(SampleView sampleView)
        {
            this.SamplesTabPage.Controls.Clear();
            sampleView.Dock = DockStyle.Fill;
            this.SamplesTabPage.Controls.Add(sampleView);
        }

        public void AddToUploadLCSResultTabPage(UploadResultView view)
        {
            this.UploadLCSResultTabPage.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.UploadLCSResultTabPage.Controls.Add(view);
        }

        public void RefreshUploadResultView()
        {
            UploadResultView control = (UploadResultView)this.UploadLCSResultTabPage.Controls[0];
            control.Refresh();
        }

        private void dataSheetTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.TabControlSelectedIndexChanged(this.DataSheetTabControl.SelectedIndex);
        }

    }
}
