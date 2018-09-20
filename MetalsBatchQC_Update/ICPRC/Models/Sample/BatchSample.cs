using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class BatchSample
    {
        public string SampleCode { get; set; }
        public string GroupCode { get; set; }
        public string ProjectNumber { get; set; }
        public double InitialAmount { get; set; }
        public string InitialUnit { get; set; }
        public double FinalAmount { get; set; }
        public string FinalUnit { get; set; }
        public string SampleDescription { get; set; }
        public string Comment { get; set; }

        public int ReportSampleIndex { get; set; }

        public BatchSample()
        {
            ReportSampleIndex = 0;
        }
    }
}
