using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class ReportBuilderView : UserControl, IReportBuilderView
    {
        ReportBuilderViewController controller;
        public string RunID { get; private set; }

        public ReportBuilderView()
        {
            InitializeComponent();
        }

        public void SetController(ReportBuilderViewController controller)
        {
            this.controller = controller;
        }

        public void SetProjectInfoLabel(ReportHeader reportHeader)
        {
            this.ProjectInfoLabel.Text = "Method Code: " + reportHeader.MethodCode + " - Sequence Number: " +
                reportHeader.SequenceNumber + " - Project Number: " + reportHeader.ProjectNumber;
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.MainTabControl_TabIndexChanged(this.MainTabControl.SelectedIndex);
        }

        public void AddControlToRawFileSamplesTabPage(Control view)
        {
            this.RawFileSamplesTabPage.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.RawFileSamplesTabPage.Controls.Add(view);
        }

        public void AddControlToElementsTabPage(Control view)
        {
            this.ElementsTabPage.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.ElementsTabPage.Controls.Add(view);
        }

        public void AddControlToReportSamplesTabPage(Control subView)
        {
            this.ReportSampleTabPage.Controls.Clear();
            subView.Dock = DockStyle.Fill;
            this.ReportSampleTabPage.Controls.Add(subView);
        }
        
        /*public void AddControlToSolidTabPage(Control subView)
        {
            this.SolidTabPage.Controls.Clear();
            subView.Dock = DockStyle.Fill;
            this.SolidTabPage.Controls.Add(subView);
        }*/

        public void AddControlToSampleResultsTabPage(Control subView)
        {
            this.SampleResultsTabPage.Controls.Clear();
            subView.Dock = DockStyle.Fill;
            this.SampleResultsTabPage.Controls.Add(subView);
        }

        public void AddControlToBQCReportTabPage(Control subView)
        {
            this.BQCReportTabPage.Controls.Clear();
            subView.Dock = DockStyle.Fill;
            this.BQCReportTabPage.Controls.Add(subView);
        }
    }
}
