using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class ReportHeader
    {
        public int BatchID { get; set; }
        public string BatchCode { get; set; }
        public int SequenceNumber { get; set; }
        public string MethodCode { get; set; }
        public string SampleType { get; set; }
        public string AnalyticalMethod { get; private set; }
        public string ProjectNumber { get; set; }
        public string SponsorName { get; set; }
        public string PrepDate { get; set; }
        public string Analyst { get; private set; }
        public string InstrumentID { get; set; }
        public string InstrumentResultUnit { get; private set; }

        public ReportHeader()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.Analyst = loginInfo.FullName;
        }

        public void SetAnalyticalMethod()
        {
            switch (this.MethodCode)
            {
                case MethodCodes.MEMS:
                    this.AnalyticalMethod = "ICPMS";
                    break;
                case MethodCodes.MEOE:
                    this.AnalyticalMethod = "ICAP";
                    break;
                case MethodCodes.MEPQ:
                    this.AnalyticalMethod = "ICPMSQ";
                    break;
                case MethodCodes.MERQ:
                    this.AnalyticalMethod = "ICAPRQ";
                    break;
                default:
                    break;
            }
        }

        public void SetInstrumentResultUnit()
        {
            switch(this.MethodCode)
            {
                case MethodCodes.MEMS:
                    this.InstrumentResultUnit = Units.ICPMS_RESULT_UNIT;
                    break;
                case MethodCodes.MEOE:
                    this.InstrumentResultUnit = Units.ICAP_RESULT_UNIT;
                    break;
                case MethodCodes.MEPQ:
                   this.InstrumentResultUnit = Units.ICPMSQ_RESULT_UNIT;
                    break;
                case MethodCodes.MERQ:
                    this.InstrumentResultUnit = Units.ICAPRQ_RESULT_UNIT;
                    break;
                default:
                    this.InstrumentResultUnit = Units.ICPMS_RESULT_UNIT;
                    break;
            }
        }
    }
}
