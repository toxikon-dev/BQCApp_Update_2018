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
using Toxikon.BatchQC.Models.Reports;
using System.Threading;
using System.Diagnostics;

namespace Toxikon.BatchQC.Views.Reports
{
    public partial class ControlChartReportView : UserControl, IControlChartReportView
    {
        ControlChartReportViewController controller;
       
        private delegate void ShowProgressDelegate(int value, string valueString);

        public ControlChartReportView()
        {
            InitializeComponent();
            ShowProgressBar(false);
        }

        public void SetController(ControlChartReportViewController controller)
        {
            this.controller = controller;
        }

        public void AddReportToListView(ControlChartReport report)
        {
            ListViewItem item = this.ReportListView.Items.Add(report.InstrumentID);
            item.SubItems.Add(report.ReportMonth.ToString());
            item.SubItems.Add(report.ReportYear.ToString());
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            ShowProgressBar(true);
            this.controller.DownloadButtonClicked();
        }

        private void ReportListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ReportListView.SelectedIndices.Count != 0)
            {
                this.controller.ReportListViewIndexChanged(this.ReportListView.SelectedIndices[0]);
            }
        }

        public void ShowProgress(int progressValue, string message)
        {
            if(this.DownloadProgressBar.InvokeRequired == false)
            {
                Debug.WriteLine("Invoked Show Progress on Thread {0} {1}", Thread.CurrentThread.ManagedThreadId,
                                progressValue);
                this.DownloadProgressBar.Maximum = 100;
                this.DownloadProgressBar.Value = progressValue;
                this.DownloadProgressLabel.Text = message;
            }
            else
            {
                ShowProgressDelegate showProgressDelegate = new ShowProgressDelegate(this.ShowProgress);
                Debug.WriteLine("Begin Invoke on Thread {0}, {1}", Thread.CurrentThread.ManagedThreadId,
                                progressValue);
                this.DownloadProgressBar.BeginInvoke(showProgressDelegate, new object[] { progressValue, message });
                return;
            }
        }

        public void ShowProgressBar(bool value)
        {
            this.ProgressBarTableLayoutPanel.Visible = value;
        }

    }
}
