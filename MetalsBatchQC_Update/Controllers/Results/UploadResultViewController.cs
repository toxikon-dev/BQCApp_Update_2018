using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Results;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.Controllers.Results
{
    public class UploadResultViewController
    {
        IUploadResultView view;
        BQCSampleResult LCSResult;
        IList uploadedResults;
        DataSheet dataSheet;

        public UploadResultViewController(IUploadResultView view)
        {
            this.view = view;
            this.view.SetController(this);
            dataSheet = DataSheet.GetInstance();
            uploadedResults = new ArrayList();
        }

        public void LoadView()
        {
            LoadUploadedResults();
            AddUploadedResultsToView();
            view.ShowSubmitButton(false);
        }

        public void RefreshView()
        {
            LoadUploadedResults();
            AddUploadedResultsToView();
            view.ShowSubmitButton(false);
        }

        private void LoadUploadedResults()
        {
            if (dataSheet.BatchCode.MethodCode == MethodCodes.MEMS)
            {
                uploadedResults = BATCHQC_REPORT.GetICPMSElementResults();
            }
            else if (dataSheet.BatchCode.MethodCode == MethodCodes.MEOE)
            {
                uploadedResults = BATCHQC_REPORT.GetICAPElementResults();
            }
            else if (dataSheet.BatchCode.MethodCode == MethodCodes.MERQ)
            {
                uploadedResults = BATCHQC_REPORT.GetICAPRQElementResults();
            }
            else if (dataSheet.BatchCode.MethodCode == MethodCodes.MEPQ)
            {
                uploadedResults = BATCHQC_REPORT.GetICPMSQElementResults();
            }
        }

        private void AddUploadedResultsToView()
        {
            view.ClearDataGrid();
            foreach(Element element in uploadedResults)
            {
                view.AddElementToDataGrid(element);
            }
        }

        public void BrowseButtonClicked(string filePath)
        {
            try
            {
                ParseFile2(filePath);
                AddElementsToDataGrid();
                view.ShowSubmitButton(true);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ParseFile(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            int lineIndex = 0;
            string line = data[lineIndex];
            if(line == "")
            {
                //ParseICAPFile(filePath);
            }
            else if(line.Contains("Run,Time"))
            {
                //ParseICPMSFile(filePath);
            }      
        }

        private void ParseFile2(string filePath)
        {
            BQCResultFile resultFile = new BQCResultFile(filePath);
            resultFile.Parse();

            this.LCSResult = resultFile.LCSSampleResult;
            LCSResult.BatchID = dataSheet.BatchCode.ID;
        }

       
      /* private void ParseICAPFile(string filePath)
        {
            ICAPResultFile resultFile = new ICAPResultFile(filePath);
            resultFile.Parse();
            LCSResult = resultFile.SearchSampleByName("LCS");
            LCSResult.SampleType = "LCS";
            LCSResult.BatchID = dataSheet.BatchCode.ID;
        }

        private void ParseICPMSFile(string filePath)
        {
            ICPMSResultFile resultFile = new ICPMSResultFile(filePath);
            resultFile.Parse();
            LCSResult = resultFile.SearchSampleByName("LCS");
            LCSResult.SampleType = "LCS";
            LCSResult.BatchID = dataSheet.BatchCode.ID;
        }*/

        private void AddElementsToDataGrid()
        {
            view.ClearDataGrid();
            foreach(Element element in LCSResult.Elements)
            {
                view.AddElementToDataGrid(element);
            }
        }

        public void SetElementIsActive(int index, bool value)
        {   
            Element element = LCSResult.ElementDictionary.ElementAt(index).Value;
            element.IsActive = value;
        }

        public void SubmitButtonClicked()
        {
            try
            {
                Int32 dbInsertResult = 0;
                if(LCSResult.InstrumentID == Instruments.ICP_2995)
                {
                    dbInsertResult = BATCHQC_INSERT.InsertICAPResults(LCSResult);
                }
                else if(LCSResult.InstrumentID == Instruments.ICP_2224)
                {
                    dbInsertResult = BATCHQC_INSERT.InsertICPMSResults(LCSResult);
                }
                else if (LCSResult.InstrumentID == Instruments.ICP_3180)
                {
                    dbInsertResult = BATCHQC_INSERT.InsertICPMSQResults(LCSResult);
                }
                else if (LCSResult.InstrumentID == Instruments.ICP_3666)
                {
                    dbInsertResult = BATCHQC_INSERT.InsertICAPRQResults(LCSResult);
                }
                view.ClearDataGrid();
                this.LoadView();
                MessageBox.Show("LCS result is submitted.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
