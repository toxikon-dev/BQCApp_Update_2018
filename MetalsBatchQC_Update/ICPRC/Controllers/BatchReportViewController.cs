using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.ICPRC.Queries;
using Toxikon.BatchQC.ICPRC.Views;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class BatchReportViewController
    {
        IBatchReportView view;
        Report report;
        Dictionary<string, BQCElementResult> resultDictionary;
        private string runDate;

        public BatchReportViewController(IBatchReportView view)
        {
            this.view = view;
            this.view.SetController(this);

            report = Report.GetInstance();
            resultDictionary = new Dictionary<string, BQCElementResult>() { };
            this.runDate = "";
        }

        public void LoadView()
        {
            LoadActiveElements();
            LoadSampleResults();
            CalculateResultRecoveries();
            AddBQCElementResultToView();
        }

        private void LoadActiveElements()
        {
            foreach(Element element in report.Elements)
            {
                if (element.IsActive)
                {
                    BQCElementResult elementResult = new BQCElementResult(element);
                    resultDictionary.Add(element.Symbol, elementResult);
                }
            }
        }

        private void LoadSampleResults()
        {
            foreach(SampleResult sampleResult in report.Samples)
            {
                if(sampleResult.GroupCode == "G01")
                {
                    AddResultToDictionary(sampleResult);
                    if(this.runDate == "")
                    {
                        this.runDate = sampleResult.RunDate.ToString("MM/dd/yyyy");
                        
                    }
                }
            }
        }

        private void AddResultToDictionary(SampleResult sampleResult)
        {
            foreach(string elementSymbol in resultDictionary.Keys.ToList())
            {
                Element sampleResultElement = sampleResult.ElementDictionary[elementSymbol];
                BQCElementResult bqcElement = resultDictionary[elementSymbol];
                bqcElement.SetResult(sampleResult.BatchSampleName, sampleResultElement.ResultValue);
            }
        }

        private void CalculateResultRecoveries()
        {
            foreach(BQCElementResult elementResult in resultDictionary.Values.ToList())
            {
                elementResult.SetLCSRecovery();
                elementResult.SetLCSDRecovery();
                elementResult.SetRPDRecovery();
            }
        }

        private void AddBQCElementResultToView()
        {
            foreach (BQCElementResult elementResult in resultDictionary.Values.ToList())
            {
                view.AddBQCElementResultToView(elementResult);
            }
        }

        public void ShowBQCElementUpdatePopup(int selectedIndex)
        {
            BQCElementResult bqcElement = resultDictionary.Values.ToList()[selectedIndex];

            BQCElementUpdatePopup popUp = new BQCElementUpdatePopup();
            BQCElementUpdatePopupController popupController = new BQCElementUpdatePopupController(popUp, bqcElement);
            popupController.LoadView();

            DialogResult dialogResult = popUp.ShowDialog(view.ParentControl);
            if(dialogResult == DialogResult.OK)
            {
                view.UpdateElementResult(selectedIndex, bqcElement);
                SampleResult LCSSampleResult = SearchSampleResultByName("G01-LCS");
                Int32 dbUpdate = BQCDB_UPDATE.UpdateLCSResults_ResultValue(LCSSampleResult, bqcElement);
            }

            popUp.Dispose();
        }

        public void DownloadReportButtonClicked()
        {
            try
            {
                DataTable dataTable = view.GetCurrentDataTable();
                BQCReportTemplate template = new BQCReportTemplate(dataTable, this.runDate);
                template.Create();
                MessageBox.Show("Download Complete!");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Submit_LCSResult_ForControlChartReport()
        {
            try
            {
                SampleResult sampleResult = SearchSampleResultByName("G01-LCS");
                IList elements = resultDictionary.Values.ToList();
                Int32 resultCount = BQCDB_SELECT.SelectLCSResultsByBatchID(sampleResult.InstrumentID, 
                                    sampleResult.BatchID);
                if (resultCount == 0)
                {
                    Int32 insertResult = BQCDB_INSERT.InsertLCSSampleResult(sampleResult, elements);
                    MessageBox.Show("LCS Results are submitted for control chart report.");
                }
                else
                {
                    MessageBox.Show("LCS Results already exist");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private SampleResult SearchSampleResultByName(string name)
        {
            SampleResult result = new SampleResult();
            foreach (SampleResult sampleResult in report.Samples)
            {
                if (sampleResult.BatchSampleName == name)
                {
                    result = sampleResult;
                    break;
                }
            }
            return result;
        }
    }
}
