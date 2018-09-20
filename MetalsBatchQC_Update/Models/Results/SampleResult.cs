using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Results
{
    public class SampleResult
    {
        public string SampleName { get; set; }
        public bool IsControlSample { get; set; }
        public string GroupCode { get; set; }
        public string BatchSampleName { get; set; }
        public Int32 BatchID { get; set; }
        public string RunID { get; set; }
        public string SampleType { get; set; }
        public DateTime RunDate { get; set; }
        public string InstrumentUnit { get; set; }
        public string InstrumentID { get; set; }

        public double InitialDigestedAmount { get; set; }
        public string InitialUnit { get; set; }
        public double FinalAmount { get; set; }
        public string FinalUnit { get; set; }
        public Dictionary<string, Element> ElementDictionary { get; private set; }

        public SampleResult()
        {
            SampleName = "";
            this.IsControlSample = false;
            this.BatchID = 0;
            this.RunID = "";
            this.SampleType = "";
            this.RunDate = new DateTime();
            this.InitialDigestedAmount = 1;

            ElementDictionary = new Dictionary<string, Element>() { };
        }

        public void UpdateResult(string elementSymbol, double result, double dilutionFactor)
        {
            Element element = ElementDictionary[elementSymbol];
            element.ResultValue = result;  
            //element.ResultValue = Math.Round(result, 3);
            element.DilutionFactor = dilutionFactor;
        }

        public void SetElementDictionary(IList<Element> elements)
        {
            foreach (Element element in elements)
            {
                
                Element sampleElement = new Element(element);
                ElementDictionary.Add(sampleElement.Symbol, sampleElement);
            }
        }
    }
}
