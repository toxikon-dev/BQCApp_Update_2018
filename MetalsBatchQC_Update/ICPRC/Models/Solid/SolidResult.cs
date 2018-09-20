using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class SolidResult
    {
        public double WeightDigested { get; set; }
        public double FinalVolume { get; set; }
        public double ReportingLimit { get; set; }
        public string ElementName { get; set; }
        public string ElementSymbol { get; set; }
        public double RawFileResult { get; set; }
        public double BlankCorrection { get; set; }
        public double DilutionFactor { get; set; }

        public double CorrectedResult { get; set; }
        public double CalculatedResult { get; set; }
        public double CalculatedReportingLimit { get; set; }
    }
}
