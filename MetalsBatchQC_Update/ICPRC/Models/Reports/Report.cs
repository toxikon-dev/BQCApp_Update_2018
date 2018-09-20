using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Queries;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class Report
    {
        private static Report instance;
        public ReportHeader ReportHeader { get; set; }
        public IList RunIDs { get; set; }
        public IList<Element> Elements { get; set; }
        public IList Samples { get; set; }

        private Report()
        {
            RunIDs = new ArrayList();
            Elements = new List<Element>() { };
            Samples = new ArrayList();
        }

        public static Report GetInstance()
        {
            if(instance == null)
            {
                instance = new Report();
            }
            return instance;
        }

        public void Load(ReportHeader reportHeader)
        {
            this.ReportHeader = reportHeader;
            LoadElements();
        }

        private void LoadElements()
        {
            Elements.Clear();
            IList<Element> results = BQCDB_SELECT.LoadElementsByInstrumentID(this.ReportHeader.InstrumentID);
           
                IEnumerable<Element> sortedEnum = results.OrderBy(f => f.MassValue);

                Elements = sortedEnum.ToList();
            
        }

        public Element GetElementByName(string elementName)
        {
            Element result = new Element();
            foreach(Element element in Elements)
            {
                if(element.Name == elementName)
                {
                    result = element;
                }
            }
            return result;
        }

        public void Clear()
        {
            RunIDs.Clear();
            Samples.Clear();
        }
    }
}
