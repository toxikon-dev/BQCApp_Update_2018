using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class RawFileSamplesView : UserControl, IRawFileSamplesView
    {
        public RawFileSamplesViewController controller;

        public RawFileSamplesView()
        {
            InitializeComponent();
        }

        public void SetController(RawFileSamplesViewController controller)
        {
            this.controller = controller;
        }

        public void AddSampleNameToRawFileSamplesList(string sampleName)
        {
            this.RawFileSampleListView.Items.Add(sampleName);

        }

        public void ClearRawFileSamplesList()
        {
            this.RawFileSampleListView.Items.Clear();
        }

        public void AddSampleNameToReportSamplesList(string sampleName)
        {
            this.ReportSamplesListView.Items.Add(sampleName);
        }

        public void ClearReportSamplesList()
        {
            this.ReportSamplesListView.Items.Clear();
        }

        private void RawFileSamplesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RawFileSampleListView.SelectedIndices.Count != 0)
            {
                this.controller.AddSelectedSampleToReport(this.RawFileSampleListView.SelectedIndices[0]);
            }
        }

        private void ReportSamplesListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.MainContextMenuStrip.Show(this.ReportSamplesListView, new Point(e.X, e.Y));
            }
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            Control sourceControl = this.MainContextMenuStrip.SourceControl;
            switch (sourceControl.Name)
            {
                case "ReportSamplesListView":
                    RemoveReportSample();
                    break;
                default:
                    break;
            }
        }

        private void RemoveReportSample()
        {
            if (this.ReportSamplesListView.SelectedIndices.Count != 0)
            {
                int selectedIndex = this.ReportSamplesListView.SelectedIndices[0];
                this.ReportSamplesListView.Items.RemoveAt(selectedIndex);
                this.controller.RemoveSelectedSampleFromReport(selectedIndex);
            }
        }

        private void BrowseFileButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                controller.BrowseFileButtonClicked(openFileDialog.FileName);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.controller.RefreshButtonClicked();
        }
    }
}
