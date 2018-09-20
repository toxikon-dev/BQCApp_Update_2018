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
    public class LiquidSample
    {
        public string SampleName { get; private set; }
        public bool IsControlSample { get; set; }
        public string VolumeDigestedUnit { get; set; }
        public string FinalVolumeUnit { get; set; }
        public string ReportingLimitUnit { get; set; }
        public string ResultUnit { get; set; }
        public string CorrectedResultUnit { get; set; }
        public string ControlCorrectedResultUnit { get; set; }
        public string CorrectedRLUnit { get; set; }
        public string RunDate { get; set; }
        public string RunID { get; set; }
        public int SampleResultIndex { get; set; }

        public IList LiquidResultList { get; private set; }

        public LiquidSample()
        {
 
        }

        public LiquidSample(int sampleIndex, SampleResult sampleResult, IList<Element> elements)
        {
            this.SampleResultIndex = sampleIndex;
            this.IsControlSample = sampleIndex == 0 ? true : false;
            this.SampleName = sampleResult.SampleName;
            this.RunDate = sampleResult.RunDate.ToString("MM/dd/yyyy");
            this.RunID = sampleResult.RunID;

            this.SetSampleUnits(sampleResult.InstrumentUnit);
            this.SetLiquidResultList(sampleResult, elements);
        }

        private void SetSampleUnits(string instrumentUnit)
        {
            this.ResultUnit = instrumentUnit == Units.PPM ? Units.MG_PER_L : Units.MCG_PER_L;
            this.ReportingLimitUnit = this.ResultUnit;
            this.CorrectedResultUnit = this.ResultUnit;
            this.CorrectedRLUnit = this.ResultUnit;
            this.ControlCorrectedResultUnit = this.ResultUnit;
            this.VolumeDigestedUnit = Units.L;
            this.FinalVolumeUnit = Units.L;
        }

        private void SetLiquidResultList(SampleResult sampleResult, IList<Element> elements)
        {
            LiquidResultList = new ArrayList();
            foreach (Element element in elements)
            {
                if (element.IsActive)
                {
                    Element sampleResultElement = sampleResult.ElementDictionary[element.Symbol];
                    LiquidResult newResult = new LiquidResult();
                    SetValues(newResult, sampleResult, sampleResultElement);
                    this.LiquidResultList.Add(newResult);
                }
            }
        }

        public void AddRunID(string runID)
        {
            if(!this.RunID.Contains(runID))
            {
                this.RunID += "," + runID;
            }
        }

        public void UpdateResult(LiquidResult liquidResult, double result, double dilutionFactor)
        {
            liquidResult.Result = result;
            liquidResult.DilutionFactor = dilutionFactor;
            SetCorrectedResult(liquidResult);
            SetCorrectedRL(liquidResult);
        }

        private void SetValues(LiquidResult newResult, SampleResult sampleResult, Element element)
        {
            newResult.VolumeDigested = ResultNumber.Convert(sampleResult.InitialDigestedAmount,
                                       Units.ML, Units.L);
            newResult.FinalVolume = ResultNumber.Convert(sampleResult.FinalAmount, Units.ML, Units.L);
            newResult.ReportingLimit = element.ReportingLimitValue;
            newResult.ElementName = element.Name;
            newResult.ElementSymbol = element.Symbol;
            newResult.Result = this.IsControlSample && element.ResultValue < 0 ? 0 : element.ResultValue;
            newResult.BlankCorrection = 0;
            newResult.DilutionFactor = element.DilutionFactor;
            SetCorrectedResult(newResult);
            SetCorrectedRL(newResult);
            newResult.ControlCorrectedResult = -1;
        }

        public void SetCorrectedResult(LiquidResult liquidResult)
        {
            if (liquidResult.Result < liquidResult.ReportingLimit && this.IsControlSample == true)
            {
                liquidResult.CorrectedResult = 0;
            }
            else
            {
                liquidResult.CorrectedResult = CalculateCorrectedResult(liquidResult.Result,
                        liquidResult.VolumeDigested, liquidResult.FinalVolume, liquidResult.DilutionFactor);
            }
        }

        public void SetCorrectedRL(LiquidResult liquidResult)
        {
            liquidResult.CorrectedRL = CalculateCorrectedRL(liquidResult.ReportingLimit,
                        liquidResult.VolumeDigested, liquidResult.FinalVolume, liquidResult.DilutionFactor);
        }

        public static double CalculateCorrectedResult(double result, double initialAmount, 
                                               double finalAmount, double dilutionFactor)
        {
            double value = (result * (finalAmount / initialAmount)) * dilutionFactor;
            return Math.Round(value, 3);
            //return value;
        }

        public static double CalculateControlCorrectedResult(double sampleCorrectedResult, 
                                                      double controlCorrectedResult)
        {
            double value = sampleCorrectedResult - controlCorrectedResult;
            return Math.Round(value, 3);
            //return value;
        }

        public static double CalculateCorrectedRL(double reportingLimit, double initialAmount,
                                           double finalAmount, double dilutionFactor)
        {
            double value = (reportingLimit * (finalAmount / initialAmount)) * dilutionFactor;
           return Math.Round(value, 3);
            //return value;
        }

        public void SetControlCorrectedResult(LiquidSample control)
        {
            for(int i = 0; i < LiquidResultList.Count; i++ )
            {
                LiquidResult resultOfControl = (LiquidResult)control.LiquidResultList[i];
                LiquidResult resultOfSample = (LiquidResult)this.LiquidResultList[i];
                resultOfSample.ControlCorrectedResult = CalculateControlCorrectedResult(
                    resultOfSample.CorrectedResult, resultOfControl.CorrectedResult);
            }
        }
    }
}
