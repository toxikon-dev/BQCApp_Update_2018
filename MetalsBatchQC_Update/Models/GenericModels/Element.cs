using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Element
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double MassValue { get; set; }
        public double TrueValue { get; set; }
        public string TrueValueUnit { get; set; }
        public double ReportingLimitValue { get; set; }
        public string ReportingLimitUnit { get; set; }
        public double LowValue { get; set; }
        public double HighValue { get; set; }
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; }
        public double DilutionFactor { get; set; }
        public bool IsActive { get; set; }
        public string InstrumentID { get; set; }
        public string RunID { get; set; }

        public Element()
        {

        }

        public Element(Element copy)
        {
            this.Symbol = copy.Symbol;
            this.Name = copy.Name;
            this.MassValue = copy.MassValue;
            this.TrueValue = copy.TrueValue;
            this.TrueValueUnit = copy.TrueValueUnit;
            this.ReportingLimitValue = copy.ReportingLimitValue;
            this.ReportingLimitUnit = copy.ReportingLimitUnit;
            this.ResultValue = copy.ResultValue;
            this.ResultUnit = copy.ResultUnit;
            this.IsActive = copy.IsActive;
            this.DilutionFactor = 1;
            this.LowValue = copy.LowValue;
            this.HighValue = copy.HighValue;
        }

        public void SetLowValue(double percentage)
        {
            this.LowValue = this.TrueValue - (this.TrueValue * percentage);
        }

        public void SetHighValue(double percentage)
        {
            this.HighValue = this.TrueValue + (this.TrueValue * percentage);
        }
    }
}
