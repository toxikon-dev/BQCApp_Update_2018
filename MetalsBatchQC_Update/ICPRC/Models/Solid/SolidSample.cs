using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class SolidSample
    {
        public string SampleName { get; private set; }
        public string WeightDigestedUnit { get; set; }
        public string FinalVolumeUnit { get; set; }
        public string ReportingLimitUnit { get; set; }
        public string CalculatedReportingLimitUnit { get; set; }
        public string RawFileResultUnit { get; set; }
        public string CorrectedResultUnit { get; set; }
        public string CalculatedResultUnit { get; set; }
        public string CorrectedRLUnit { get; set; }
        public string RunDate { get; set; }
        public string RunID { get; set; }
        public int SampleResultIndex { get; set; }

        public IList SolidResultList { get; private set; }


        public SolidSample(SampleResult sampleResult, IList<Element> elements)
        {
            //this.SampleResultIndex = sampleIndex;
            this.SampleName = sampleResult.SampleName;
            this.RunDate = sampleResult.RunDate.ToString("MM/dd/yyyy");
            this.RunID = sampleResult.RunID;

            this.SetSampleUnits(sampleResult.InstrumentUnit);
            this.SetSampleResults(sampleResult, elements);
        }

        private void SetSampleUnits(string resultUnit)
        {
            this.RawFileResultUnit = resultUnit == Units.PPM ? Units.MG_PER_L : Units.MCG_PER_L;
            this.CalculatedResultUnit = resultUnit == Units.PPM ? Units.MG_PER_KG : Units.MCG_PER_G;

            this.ReportingLimitUnit = this.RawFileResultUnit;
            this.CalculatedReportingLimitUnit = this.CalculatedResultUnit;

            this.CorrectedResultUnit = this.RawFileResultUnit;
            this.CorrectedRLUnit = this.CalculatedResultUnit;

            this.WeightDigestedUnit = Units.G;
            this.FinalVolumeUnit = Units.L;
        }

        private void SetSampleResults(SampleResult sampleResult, IList<Element> elements)
        {
            SolidResultList = new ArrayList();
            foreach (Element element in elements)
            {
                if (element.IsActive)
                {
                    Element sampleResultElement = sampleResult.ElementDictionary[element.Symbol];
                    SolidResult newResult = new SolidResult();
                    SetValues(newResult, sampleResult, sampleResultElement);
                    this.SolidResultList.Add(newResult);
                }
            }
        }

        private void SetValues(SolidResult solidResult, SampleResult sampleResult, Element element)
        {
            solidResult.ElementName = element.Name;
            solidResult.ElementSymbol = element.Symbol;
            solidResult.WeightDigested = sampleResult.InitialDigestedAmount;
            solidResult.FinalVolume = ResultNumber.Convert(sampleResult.FinalAmount, Units.ML, Units.L);
            solidResult.ReportingLimit = element.ReportingLimitValue;
            solidResult.RawFileResult = element.ResultValue;
            solidResult.BlankCorrection = 0;
            solidResult.DilutionFactor = element.DilutionFactor;
            solidResult.CorrectedResult = CalculateCorrectedResult(element.ResultValue, 
                                          solidResult.BlankCorrection, solidResult.DilutionFactor);

            this.SetCalculatedResult(solidResult);
            this.SetCalculatedReportingLimit(solidResult);
        }

        private void SetCalculatedResult(SolidResult solidResult)
        {
            double value = CalculateResult2(solidResult.CorrectedResult, solidResult.WeightDigested, 
                           solidResult.FinalVolume);
            solidResult.CalculatedResult = value;
            if(this.RawFileResultUnit == Units.MCG_PER_L && this.WeightDigestedUnit == Units.G)
            {
               solidResult.CalculatedResult = ResultNumber.Convert(value, Units.MCG_PER_L, Units.MCG_PER_G);
                //solidResult.CalculatedResult = value;
            }
        }

        private void SetCalculatedReportingLimit(SolidResult solidResult)
        {
            double value = CalculateReportingLimit2(solidResult.ReportingLimit, solidResult.WeightDigested, 
                            solidResult.FinalVolume, solidResult.DilutionFactor);
            solidResult.CalculatedReportingLimit = value;
            if (this.RawFileResultUnit == Units.MCG_PER_L && this.WeightDigestedUnit == Units.G)
            {
                solidResult.CalculatedReportingLimit = ResultNumber.Convert(
                           value, Units.MCG_PER_L, Units.MCG_PER_G);

                //solidResult.CalculatedReportingLimit = value;
            }
        }

        public void AddRunID(string runID)
        {
            if (!this.RunID.Contains(runID))
            {
                this.RunID += "," + runID;
            }
        }

        public void UpdateResult(SolidResult solidResult, double newResult, double dilutionFactor)
        {
            solidResult.RawFileResult = newResult;
            solidResult.DilutionFactor = dilutionFactor;
            solidResult.CorrectedResult = CalculateCorrectedResult(solidResult.RawFileResult, 
                                          solidResult.BlankCorrection, solidResult.DilutionFactor);
            this.SetCalculatedResult(solidResult);
            this.SetCalculatedReportingLimit(solidResult);
        }

        public static double CalculateCorrectedResult(double result, double blankCorrection, double dilutionFactor)
        {
            double value = (result - blankCorrection) * dilutionFactor;
            return value;
        }

        public static double CalculateResult2(double correctedResult, double digestedAmt, double finalAmt)
        {
            double value = (correctedResult * finalAmt) / digestedAmt;
            return value;
        }

        public static double CalculateReportingLimit2(double reportingLimit, double digestedAmt, 
                                                      double finalAmt, double dilutionFactor)
        {
            double value = (reportingLimit * finalAmt / digestedAmt) * dilutionFactor;
            return value;
        }
    }
}
