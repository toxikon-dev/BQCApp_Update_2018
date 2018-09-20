using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class LiquidResult
    {
        public double VolumeDigested { get; set; }
        public double FinalVolume { get; set; }
        public double ReportingLimit { get; set; }
        public string ElementName { get; set; }
        public string ElementSymbol { get; set; }
        public double Result { get; set; }
        public double BlankCorrection { get; set; }
        public double DilutionFactor { get; set; }
        public double CorrectedResult { get; set; }
        public double ControlCorrectedResult { get; set; }
        public double CorrectedRL { get; set; }
    }
}
