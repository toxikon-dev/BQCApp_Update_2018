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
    public class RawFileSamplesViewController
    {
        IRawFileSamplesView view;
        IList RawFileSamples;
        Report report;

        public RawFileSamplesViewController(IRawFileSamplesView view)
        {
            this.view = view;
            this.view.SetController(this);
            report = Report.GetInstance();
            RawFileSamples = new ArrayList();
        }

        public void BrowseFileButtonClicked(string filePath)
        {
            try
            {
                RawFileSamples.Clear();
                view.ClearRawFileSamplesList();
                RawFileSamples = ReportUtility.ParseFile(report.ReportHeader.MethodCode, filePath, 
                                 report.Elements);
                AddRawFileSamplesToView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void RefreshButtonClicked()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to restart?", "Confirmation",
                                            MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RawFileSamples.Clear();
                report.Clear();
                view.ClearRawFileSamplesList();
                view.ClearReportSamplesList();
            }
        }

        private void AddRawFileSamplesToView()
        {
           foreach (SampleResult sampleResult in RawFileSamples)
            {
                sampleResult.BatchID = report.ReportHeader.BatchID;
                view.AddSampleNameToRawFileSamplesList(sampleResult.SampleName);
                
            }

       
        }

        public void AddSelectedSampleToReport(int selectedIndex)
        {
            SampleResult selectedSample = (SampleResult)RawFileSamples[selectedIndex];
            if (!report.Samples.Contains(selectedSample))
            {
                report.Samples.Add(selectedSample);
                view.AddSampleNameToReportSamplesList(selectedSample.SampleName);
            }
        }

        public void RemoveSelectedSampleFromReport(int selectedIndex)
        {
            report.Samples.RemoveAt(selectedIndex);
        }
    }
}
