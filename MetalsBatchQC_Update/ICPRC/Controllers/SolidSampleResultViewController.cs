using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class SolidSampleResultViewController
    {
        ISolidSampleResultView view;
        Report report;

        IList SampleList;
        IList DataGridViewList;

        int SelectedSampleIndex;
        SolidResult SelectedResult;

        public delegate void UpdateSelectedElement(int selectedIndex);
        public static UpdateSelectedElement UpdateSelectedElementDelegate;

        public SolidSampleResultViewController(ISolidSampleResultView view)
        {
            this.view = view;
            this.view.SetController(this);
            report = Report.GetInstance();
            SampleList = new ArrayList();
            DataGridViewList = new ArrayList();
            UpdateSelectedElementDelegate = new UpdateSelectedElement(this.UpdateSelectedElementMethod);
        }

        public void LoadView()
        {
            view.ClearSampleNameListBox();
            SampleList = SolidReportUtility.CreateSolidSamples(report.Elements, report.Samples);
            DataGridViewList = SolidReportUtility.CreateDataGridViews(SampleList);
            AddSampleNamesToView();
        }

        private void AddSampleNamesToView()
        {
            foreach (SolidSample sample in SampleList)
            {
                view.AddSampleNameToListBox(sample.SampleName);
            }
        }

        public void SampleNameListBoxSelectedIndexChanged(int selectedIndex)
        {
            this.SelectedSampleIndex = selectedIndex;
            SolidDataGridView grid = (SolidDataGridView)DataGridViewList[selectedIndex];
            view.AddDataGridViewToView(grid);
        }

        /****************************** UPDATE RESULT *********************/
        public void UpdateSelectedElementMethod(int selectedIndex)
        {
            SolidSample sample = (SolidSample)this.SampleList[this.SelectedSampleIndex];
            this.SelectedResult = (SolidResult)sample.SolidResultList[selectedIndex];
            double dilutedResult;
            double dilutionFactor;

            ReportUtility.ShowDilutedSampleViewPopup(view.ParentControl, this.SelectedResult.ElementSymbol,
                out dilutedResult, out dilutionFactor);
            if (dilutionFactor > 0)
            {
                DoUpdates(dilutedResult, dilutionFactor);
            }
        }

        private void DoUpdates(double dilutedResult, double dilutionFactor)
        {
            UpdateSolidSample(dilutedResult, dilutionFactor);
            UpdateReportSample(this.SelectedResult.ElementSymbol, dilutedResult, dilutionFactor);
            UpdateDataGridView();

            this.SampleNameListBoxSelectedIndexChanged(this.SelectedSampleIndex);
        }

        private void UpdateSolidSample(double newResult, double dilutionFactor)
        {
            SolidSample sample = (SolidSample)this.SampleList[this.SelectedSampleIndex];
            sample.UpdateResult(this.SelectedResult, newResult, dilutionFactor);
        }

        private void UpdateReportSample(string elementSymbol, double newResult, double dilutionFactor)
        {
            SampleResult sampleResult = (SampleResult)report.Samples[this.SelectedSampleIndex];
            sampleResult.UpdateResult(elementSymbol, newResult, dilutionFactor);
        }

        private void UpdateDataGridView()
        {
            SolidDataGridView grid = (SolidDataGridView)DataGridViewList[SelectedSampleIndex];
            grid.UpdateRows();
        }

        public void DownloadReportButtonClicked()
        {
            try
            {
                IList DataTables = SolidReportUtility.ConvertToDataTables(this.DataGridViewList);
                SolidReportTemplate reportTemplate = new SolidReportTemplate(report.ReportHeader,
                                    this.SampleList, DataTables);
                reportTemplate.Create();
                MessageBox.Show("Download Complete!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
