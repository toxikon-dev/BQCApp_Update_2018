using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class DilutedSampleViewController
    {
        IDilutedSampleView view;
        IList RawFileSampleResults;
        Report report;
        string DilutedElementSymbol;
        public double DilutedElementResult { get; private set; }
        public double DilutionFactor { get; private set; }
        public string RunID { get; private set; }

        public DilutedSampleViewController(IDilutedSampleView view, string elementSymbol)
        {
            this.view = view;
            this.view.SetController(this);
            this.DilutedElementSymbol = elementSymbol;
            this.DilutedElementResult = 0;
            this.DilutionFactor = 10;
            this.RunID = "";

            report = Report.GetInstance();
            RawFileSampleResults = new ArrayList();
        }

        public void LoadView()
        {
            view.SelectedSampleIndex = -1;
            view.DilutionFactor = this.DilutionFactor;
        }

        public void BrowseFileButtonClicked(string filePath)
        {
            try
            {
                RawFileSampleResults.Clear();
                RawFileSampleResults = ReportUtility.ParseFile(report.ReportHeader.MethodCode, 
                                       filePath, report.Elements);
                AddRawFileSampleToView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddRawFileSampleToView()
        {
            foreach (SampleResult sampleResult in RawFileSampleResults)
            {
                view.AddSampleNameToList(sampleResult.SampleName);
            }
        }

        public void DilutedSampleList_SelectedIndexChanged(int selectedIndex)
        {
            SampleResult sampleResult = (SampleResult)this.RawFileSampleResults[selectedIndex];
            Element element = sampleResult.ElementDictionary[this.DilutedElementSymbol];
            this.RunID = sampleResult.RunID;
            this.DilutedElementResult = element.ResultValue;
        }

        public void SubmitButtonClicked()
        {
            if(view.SelectedSampleIndex == -1)
            {
                MessageBox.Show("No sample is selected.");
                view.SetDialogResult(DialogResult.Retry);
            }
            else if(view.DilutionFactor.ToString().Trim() == "")
            {
                MessageBox.Show("Dilution Factor is required.");
                view.SetDialogResult(DialogResult.Retry);
            }
            else
            {
                this.DilutionFactor = view.DilutionFactor;
                view.SetDialogResult(DialogResult.OK);
            }
        }
    }
}
