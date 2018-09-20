using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Views;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;
using Toxikon.BatchQC.Views.ICPRC;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public static class ReportUtility
    {
        public static IList ParseFile(string methodCode, string filePath, IList<Element> elements)
        {
            IList results = new ArrayList();
            switch (methodCode)
            {
                case MethodCodes.MEMS:
                    results = ReportUtility.ParseICPMSFile(filePath, elements);
                    break;
                case MethodCodes.MEOE:
                    results = ReportUtility.ParseICAPFile(filePath, elements);
                    break;
                case MethodCodes.MEPQ:
                    results = ReportUtility.ParseICPMSQFile(filePath, elements);
                    break;
                case MethodCodes.MERQ:
                    results = ReportUtility.ParseICAPRQFile(filePath, elements);
                    break;
                default:
                    break;
            }
            return results;
        }

        public static IList ParseICAPFile(string filePath, IList<Element> elements)
        {
            ICAP_RawFile resultFile = new ICAP_RawFile(filePath, elements);
            resultFile.Parse();
            return resultFile.SampleResults;
        }

        public static IList ParseICPMSFile(string filePath, IList<Element> elements)
        {
            ICPMS_RawFile resultFile = new ICPMS_RawFile(filePath, elements);
            resultFile.Parse();
            return resultFile.SampleResults;
        }

        public static IList ParseICPMSQFile(string filePath, IList<Element> elements)
        {
            ICPMSQ_RawFile resultFile = new ICPMSQ_RawFile(filePath, elements);
            resultFile.Parse();
            return resultFile.SampleResults;
        }

        public static IList ParseICAPRQFile(string filePath, IList<Element> elements)
        {
            ICAPRQ_RawFile resultFile = new ICAPRQ_RawFile(filePath, elements);
            resultFile.Parse();
            return resultFile.SampleResults;
        }

       

        public static void UpdateSampleResultFromBatchSample(SampleResult sampleResult, BatchSample batchSample)
        {
            sampleResult.GroupCode = batchSample.GroupCode;
            sampleResult.BatchSampleName = batchSample.SampleCode;
            sampleResult.InitialDigestedAmount = batchSample.InitialAmount;
            sampleResult.InitialUnit = batchSample.InitialUnit;
            sampleResult.FinalAmount = batchSample.FinalAmount;
            sampleResult.FinalUnit = batchSample.FinalUnit;
        }

        public static void ShowDilutedSampleViewPopup(Control ParentControl, string elementSymbol,
                            out double dilutedResult, out double dilutionFactor)
        {
            dilutedResult = 0;
            dilutionFactor = 0;

            DilutedSampleView subView = new DilutedSampleView();
            DilutedSampleViewController subViewController =
                new DilutedSampleViewController(subView, elementSymbol);
            subViewController.LoadView();

            DialogResult dialogResult = subView.ShowDialog(ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                dilutedResult = subViewController.DilutedElementResult;
                dilutionFactor = subViewController.DilutionFactor;
            }
            subView.Dispose();
        }
    }
}
