using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.ICPRC.Views;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Views.ICPRC;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class ReportBuilderViewController
    {
        IReportBuilderView view;
        Report report;
        IList RawFileSampleResults;
        bool IsElementsLoaded;
        bool IsRawFileSamplesLoaded;

        public ReportBuilderViewController(IReportBuilderView view)
        {
            this.view = view;
            this.view.SetController(this);
            report = Report.GetInstance();
            this.view.SetProjectInfoLabel(report.ReportHeader);
            RawFileSampleResults = new ArrayList();
            IsElementsLoaded = false;
            IsRawFileSamplesLoaded = false;
        }

        public void LoadView()
        {
            LoadRawFileSamplesView();
        }

        /*************************** MAIN TAB CONTROL ***********************/
        public void MainTabControl_TabIndexChanged(int tabIndex)
        {
            switch(tabIndex)
            {
                case 0:
                    LoadRawFileSamplesView();
                    break;
                case 1:
                    LoadElementsView();
                    break;
                case 2:
                    LoadReportSamplesView();
                    break;
                case 3:
                    LoadSampleResultView();
                    break;
                case 4:
                    LoadBatchReportView();
                    break;
                default:
                    break;
            }
        }

        private void LoadRawFileSamplesView()
        {
            if(!IsRawFileSamplesLoaded)
            {
                RawFileSamplesView subView = new RawFileSamplesView();
                RawFileSamplesViewController subViewController = new RawFileSamplesViewController(subView);
                view.AddControlToRawFileSamplesTabPage(subView);
                this.IsRawFileSamplesLoaded = true;
            }
        }

        private void LoadElementsView()
        {
            if (!IsElementsLoaded)
            {
                ElementsView subView = new ElementsView();
                ElementsViewController subViewController = new ElementsViewController(subView);
                subViewController.LoadView();
                view.AddControlToElementsTabPage(subView);

                this.IsElementsLoaded = true;
            }
        }

        private void LoadReportSamplesView()
        {
            ReportSamplesView subView = new ReportSamplesView();
            ReportSamplesViewController subViewController = new ReportSamplesViewController(subView);
            subViewController.LoadView();
            this.view.AddControlToReportSamplesTabPage(subView);
        }

        public void LoadSampleResultView()
        {
            if(this.report.ReportHeader.SampleType == SampleTypes.LIQUID)
            {
                LoadLiquidSampleResultView();
            }
            else if(this.report.ReportHeader.SampleType == SampleTypes.SOLID)
            {
                LoadSolidSampleResultView();
            }
        }

        private void LoadLiquidSampleResultView()
        {
            LiquidSampleResultsView subView = new LiquidSampleResultsView();
            LiquidSampleResultViewController subViewController = new LiquidSampleResultViewController(subView);
            subViewController.LoadView();

            this.view.AddControlToSampleResultsTabPage(subView);
        }

        private void LoadSolidSampleResultView()
        {
            SolidSampleResultsView subView = new SolidSampleResultsView();
            SolidSampleResultViewController subViewController = new SolidSampleResultViewController(subView);
            subViewController.LoadView();

            this.view.AddControlToSampleResultsTabPage(subView);
        }

        private void LoadBatchReportView()
        {
            BatchReportView subView = new BatchReportView();
            BatchReportViewController subViewController = new BatchReportViewController(subView);
            subViewController.LoadView();

            this.view.AddControlToBQCReportTabPage(subView);
        }
    }
}
