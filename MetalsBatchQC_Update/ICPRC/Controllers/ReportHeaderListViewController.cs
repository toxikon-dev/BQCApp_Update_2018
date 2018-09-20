using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.ICPRC.Queries;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class ReportHeaderListViewController
    {
        IReportHeaderListView view;
        IList reportHeaders;
        ReportHeader selectedReportHeader;

        public ReportHeaderListViewController(IReportHeaderListView view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public void LoadView()
        {
            reportHeaders = BQCDB_SELECT.SelectActiveReportHeaders();
            foreach(ReportHeader reportHeader in reportHeaders)
            {
                view.AddReportHeaderToListView(reportHeader);
            }
        }

        public void ReportHeaderListViewSelectedIndexChanged(int selectedIndex)
        {
            this.selectedReportHeader = (ReportHeader)reportHeaders[selectedIndex];
        }

        public void OpenButtonClicked()
        {
            if (this.selectedReportHeader == null)
            {
                MessageBox.Show("Please select one batch code and try it again.");
            }
            else
            {
                UpdateReport();
                LoadReportBuilderView();
            }
        }

        public void UpdateReport()
        {
            Report report = Report.GetInstance();
            report.Clear();
            report.Load(this.selectedReportHeader);
        }

        private void LoadReportBuilderView()
        {
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.loadReportBuilderViewDelegate);
        }
    }
}
