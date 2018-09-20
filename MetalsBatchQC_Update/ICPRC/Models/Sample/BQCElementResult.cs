using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class BQCElementResult
    {
        public string ElementSymbol { get; set; }
        public double Low { get; set; }
        public double High { get; set; }

        public double TrueValue { get; set; }
        public double MBResult { get; set; }
        public double LCSResult { get; set; }
        public double LCSDResult { get; set; }
        public double LCSRecovery { get; private set; }
        public double LCSDRecovery { get; private set; }
        public double RPD { get; private set; }

        public string ResultUnit { get; set; }

        public BQCElementResult()
        {
            this.ElementSymbol = "";
            this.TrueValue = 0;
            this.MBResult = 0;
            this.LCSResult = 0;
            this.LCSDResult = 0;
            this.LCSRecovery = 0;
            this.LCSDRecovery = 0;
            this.RPD = 0;
        }

        public BQCElementResult(Element element)
        {
            this.ElementSymbol = element.Symbol;
            this.ResultUnit = element.ResultUnit;
            this.Low = element.LowValue;
            this.High = element.HighValue;

            this.TrueValue = element.TrueValue;
            this.MBResult = 0;
            this.LCSResult = 0;
            this.LCSDResult = 0;
            this.LCSRecovery = 0;
            this.LCSDRecovery = 0;
            this.RPD = 0;
        }

        public void SetResult(string batchSampleName, double value)
        {
            switch(batchSampleName)
            {
                case "G01-MB":
                    this.MBResult = value;
                    break;
                case "G01-LCS":
                    this.LCSResult = value;
                    break;
                case "G01-LCSD":
                    this.LCSDResult = value;
                    break;
                default:
                    break;
            }
        }

        public void SetLCSRecovery()
        {
            this.LCSRecovery = (this.LCSResult / TrueValue) * 100;
        }

        public void SetLCSDRecovery()
        {
            this.LCSDRecovery = (this.LCSDResult / TrueValue) * 100;
        }

        public void SetRPDRecovery()
        {
            double avg = (this.LCSResult + this.LCSDResult) / 2; 
            this.RPD = ((this.LCSResult - this.LCSDResult) / avg) * 100;
        }
    }
}
