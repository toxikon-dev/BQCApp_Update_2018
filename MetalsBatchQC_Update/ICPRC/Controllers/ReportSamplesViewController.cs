using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.ICPRC.Queries;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class ReportSamplesViewController
    {
        IReportSamplesView view;
        IList BatchSamples;
        Report report;

        public ReportSamplesViewController(IReportSamplesView view)
        {
            this.view = view;
            this.view.SetController(this);
            report = Report.GetInstance();

            BatchSamples = new ArrayList();
        }

        public void LoadView()
        {
            view.ClearBatchSampleList();
            LoadBatchSamples();
            AddBatchSamplesToView();
            LoadRawFileSampleComboBox();
        }

        private void LoadBatchSamples()
        {
            BatchSamples.Clear();
            BatchSamples = BQCDB_SELECT.LoadBatchSamples(report.ReportHeader.BatchID);
        }

        private void AddBatchSamplesToView()
        {
            foreach (BatchSample batchSample in BatchSamples)
            {
                view.AddBatchSampleToView(batchSample);
            }
        }

        private void LoadRawFileSampleComboBox()
        {
            IList items = new ArrayList();
            items.Add("N/A");
            foreach (SampleResult sampleResult in report.Samples)
            {
                items.Add(sampleResult.SampleName);
            }
            view.SetRawFileSampleComboBox(items);
        }

        public void UpdateSampleResultValuesFromBatchSample(int rowIndex, int sampleIndex)
        {
            if (sampleIndex != 0)
            {
                BatchSample batchSample = (BatchSample)BatchSamples[rowIndex];
                SampleResult sampleResult = (SampleResult)report.Samples[sampleIndex - 1];
                ReportUtility.UpdateSampleResultFromBatchSample(sampleResult, batchSample);
            }
        }
    }
}
