using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class BatchDetail
    {
        public string PrepDate { get; set; }
        public string PreparedBy { get; set; }
        public string SampleType { get; set; }
        public string InstrumentID { get; set; }
        public string BalanceID { get; set; }
        public string Method { get; set; }
        public string MethodID { get; set; }
        public string MethodTemp { get; set; }
        public string Analyte { get; set; }
        public string PrepType { get; set; }
        public string PurifiedWater { get; set; }

        public BatchDetail()
        {
            Init();
        }

        private void Init()
        {
            PrepDate = DateTime.Today.ToString("MM/dd/yyyy");
            PreparedBy = "";
            SampleType = SampleTypes.LIQUID;
            Method = "";
            MethodID = "";
            MethodTemp = "N/A";
            InstrumentID = "";
            BalanceID = "";
            Analyte = "";
            PurifiedWater = "528" + DateTime.Today.ToString("MMddyy");
        }

        public void Clear()
        {
            Init();
        }
    }
}
