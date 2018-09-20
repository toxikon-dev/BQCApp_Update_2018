using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Reports;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Controllers.Reports
{
    public class ControlChartReportViewController
    {
        IControlChartReportView view;
        IList reports;
        ControlChartReport selectedReport;

        public ControlChartReportViewController(IControlChartReportView view)
        {
            this.view = view;
            this.view.SetController(this);

            reports = new ArrayList();
            selectedReport = new ControlChartReport();
        }

        public void LoadView()
        {
            LoadICPMSReports();
            LoadICAPReports();
            LoadICPMSQReports();
            LoadICAPRQReports();
            AddReportsToView();
        }

        public void LoadICPMSReports()
        {
            IList dbResults = BATCHQC_REPORT.GetAvailableReportsForInstrument("ICPMS");
            foreach(ControlChartReport report in dbResults)
            {
                this.reports.Add(report);
            }
        }
        public void LoadICPMSQReports()
        {
            IList dbResults = BATCHQC_REPORT.GetAvailableReportsForInstrument("ICPMSQ");
            foreach (ControlChartReport report in dbResults)
            {
                this.reports.Add(report);
            }
        }

        public void LoadICAPReports()
        {
            IList dbResults = BATCHQC_REPORT.GetAvailableReportsForInstrument("ICAP");
            foreach(ControlChartReport report in dbResults)
            {
                this.reports.Add(report);
            }
        }

        public void LoadICAPRQReports()
        {
            IList dbResults = BATCHQC_REPORT.GetAvailableReportsForInstrument("ICAPRQ");
            foreach (ControlChartReport report in dbResults)
            {
                this.reports.Add(report);
            }
        }

        private void AddReportsToView()
        {
            foreach(ControlChartReport report in reports)
            {
                view.AddReportToListView(report);
            }
        }

        public void ReportListViewIndexChanged(int index)
        {
            this.selectedReport = (ControlChartReport)reports[index];
        }

        public void DownloadButtonClicked()
        {
            try
            {
                if (this.selectedReport != null)
                {
                    this.selectedReport.OnProgressUpdate += this.OnReportProgressUpdate;
                    this.selectedReport.OnDownloadComplete += this.OnReportDownloadComplete;
                    this.selectedReport.CreateExcelReport();
                }
                else
                {
                    MessageBox.Show("Please select a report then try it again.");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnReportProgressUpdate(int value)
        {
            view.ShowProgress(value, value + "%");
        }

        private void OnReportDownloadComplete()
        {
            view.ShowProgressBar(false);
        }
    }
}
