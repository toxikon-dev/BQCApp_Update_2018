using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Models.Results
{
    public class BQCSampleResult
    {
        public string SampleName { get; set; }
        public Int32 BatchID { get; set; }
        public string RunID { get; private set; }
        public string InstrumentID { get; set; }
        public string SampleType { get; set; }
        public string ResultUnit { get; private set; }
        public DateTime RunDate { get; set; }
        public List<Element> Elements { get; set; }
        public Dictionary<string, Element> ElementDictionary { get; private set; }

        public BQCSampleResult()
        {
            SampleName = "";
            this.BatchID = 0;
            this.RunID = "";
            this.InstrumentID = "";
            this.SampleType = "";
            this.RunDate = new DateTime();
            ElementDictionary = new Dictionary<string, Element>() { };
            Elements = new List<Element>() { };
        }

        public void SetResultUnit()
        {
            switch(this.InstrumentID)
            {
                case Instruments.ICP_2224:
                    this.ResultUnit = Units.PPB;
                    break;
                case Instruments.ICP_2995:
                    this.ResultUnit = Units.PPM;
                    break;
                case Instruments.ICP_3180:
                    this.ResultUnit = Units.PPB;
                    break;
                case Instruments.ICP_3666:
                    this.ResultUnit = Units.PPB;
                    break;
                default:
                    this.ResultUnit = "";
                    break;
            }
        }

        public void SetRunID()
        {
            this.RunID = this.RunDate.ToString("MMddyy");
        }

        public void LoadElements()
        {
            IList dbResults = BATCHQC_SELECT.GetElementsForInstrument(this.InstrumentID);
            foreach (Element element in dbResults)
            {
                element.IsActive = false;
                ElementDictionary.Add(element.Symbol, element);
            }
        }
    }
}
