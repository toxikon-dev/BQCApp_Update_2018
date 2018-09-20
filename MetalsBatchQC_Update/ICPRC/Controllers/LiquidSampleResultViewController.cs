using Microsoft.Office.Interop.Excel;
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
    public class LiquidSampleResultViewController
    {
        ILiquidSampleResultView view;
        Report report;

        IList SampleList;
        IList DataGridViewList;

        int  SelectedSampleIndex;
        LiquidResult SelectedResult;

        public delegate void UpdateSelectedElement(int selectedIndex);
        public static UpdateSelectedElement UpdateSelectedElementDelegate;

        public LiquidSampleResultViewController(ILiquidSampleResultView view)
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
            SampleList = LiquidReportUtility.CreateLiquidSamples(report.Elements, report.Samples);
            LiquidReportUtility.SetControlCorrectedResult(SampleList);
            DataGridViewList = LiquidReportUtility.CreateDataGridViews(SampleList);
            AddSampleNamesToView();
        }

        private void AddSampleNamesToView()
        {
            foreach(LiquidSample liquidSample in SampleList)
            {
                view.AddSampleNameToListBox(liquidSample.SampleName);
            }
        }

        public void SampleNameListBoxSelectedIndexChanged(int selectedIndex)
        {
            this.SelectedSampleIndex = selectedIndex;
            LiquidDataGridView grid = (LiquidDataGridView)DataGridViewList[selectedIndex];
            view.AddDataGridViewToView(grid);
        }

        /******************************* UPDATE ELEMENT RESULT *******************************/
        public void UpdateSelectedElementMethod(int selectedIndex)
        {
            LiquidSample selectedSample = (LiquidSample)this.SampleList[this.SelectedSampleIndex];
            this.SelectedResult = (LiquidResult)selectedSample.LiquidResultList[selectedIndex];
            double dilutedResult;
            double dilutionFactor;

            ReportUtility.ShowDilutedSampleViewPopup(view.ParentControl, this.SelectedResult.ElementSymbol,
                out dilutedResult, out dilutionFactor);
            if(dilutionFactor > 0)
            {
                DoUpdates(dilutedResult, dilutionFactor);
            }
        }

        private void DoUpdates(double dilutedResult, double dilutionFactor)
        {
            UpdateLiquidSample(dilutedResult, dilutionFactor);
            UpdateSampleResult(this.SelectedResult.ElementSymbol, dilutedResult, dilutionFactor);
            UpdateDataGridView();

            SampleNameListBoxSelectedIndexChanged(SelectedSampleIndex);
        }

        private void UpdateLiquidSample(double newResult, double dilutionFactor)
        {
            LiquidSample sample = (LiquidSample)this.SampleList[this.SelectedSampleIndex];
            sample.UpdateResult(this.SelectedResult, newResult, dilutionFactor);
            LiquidReportUtility.SetControlCorrectedResult(SampleList);
        }

        private void UpdateSampleResult(string elementSymbol, double newResult, double dilutionFactor)
        {
            LiquidSample sample = (LiquidSample)this.SampleList[this.SelectedSampleIndex];
            SampleResult sampleResult = (SampleResult)report.Samples[sample.SampleResultIndex];
            sampleResult.UpdateResult(elementSymbol, newResult, dilutionFactor);
        }

        private void UpdateDataGridView()
        {
            LiquidDataGridView grid = (LiquidDataGridView)DataGridViewList[SelectedSampleIndex];
            grid.UpdateRows();
        }

        public void DownloadReportButtonClicked()
        {
            try
            {
                IList dataTables = LiquidReportUtility.ConvertToDataTables(this.DataGridViewList);
                LiquidReportTemplate reportTemplate = new LiquidReportTemplate(report.ReportHeader, 
                                                      this.SampleList, dataTables);
                reportTemplate.Create();
                MessageBox.Show("Download Complete!");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
