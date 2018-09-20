using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class ICAP_RawFile
    {
        private string fileName;
        private string[] data;
        private int lineIndex;
        public List<SampleResult> SampleResults { get; private set; }
        private IList<Element> elements;

        public ICAP_RawFile(string filePath, IList<Element> elements)
        {
            this.fileName = Path.GetFileName(filePath);
            this.data = File.ReadAllLines(filePath);
            SampleResults = new List<SampleResult>() { };
            this.elements = new List<Element>(elements);
        }

        public void Parse()
        {
            try
            {
                lineIndex = 0;
                while (lineIndex < data.Length)
                {
                    string line = data[lineIndex];
                    if(line.Contains("[Sample Header]"))
                    {
                        ParseSampleResult();
                    }
                    else
                    {
                        lineIndex += 1;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ParseSampleResult()
        {
            lineIndex += 2;
            SampleResult sampleResult = new SampleResult();
            sampleResult.InstrumentID = Instruments.ICP_2995;
            sampleResult.InstrumentUnit = Units.PPM;
            sampleResult.RunID = this.fileName.Split('.')[0];
            sampleResult.SampleName = GetLineValue(data[lineIndex]);
            lineIndex += 2;
            sampleResult.SampleName += " " + GetLineValue(data[lineIndex]).Trim();
            sampleResult.SetElementDictionary(elements);
            lineIndex += 4;
            string runDateValue = GetLineValue(data[lineIndex]);           
            sampleResult.RunDate = GetRunDate(runDateValue.Trim());
            lineIndex += 8;
            ParseElementResults(sampleResult);
            SampleResults.Add(sampleResult);
            lineIndex += 1;
        }

        private string GetLineValue(string line)
        {
            string[] splits = line.Split('=');
            return splits[1];
        }

        public static DateTime GetRunDate(string runDate)
        {
            string pattern = "M/d/yyyy H:mm:ss";
            DateTime parsedDate = DateTime.ParseExact(runDate, pattern, null, DateTimeStyles.None);
            return parsedDate;
        }

        private void ParseElementResults(SampleResult sampleResult)
        {
            string line = data[lineIndex];
            while(line != "")
            {
                string[] splits = line.Split(',');
                string elementSymbol = splits[0].Substring(0, 2).Replace("_", "");
                double number;
                if (Double.TryParse(splits[2], out number))
                {
                    if (sampleResult.ElementDictionary.ContainsKey(elementSymbol))
                    {
                        Element element = sampleResult.ElementDictionary[elementSymbol];
                        double result = Convert.ToDouble(number);
                        element.ResultValue = result;
                        element.ResultUnit = splits[1];
                    }
                }
                lineIndex += 1;
                line = data[lineIndex];
            }
        }

        public SampleResult SearchSampleByName(string name)
        {
            SampleResult sample = new SampleResult();
            foreach (SampleResult item in this.SampleResults)
            {
                if (item.SampleName.Contains(name))
                {
                    sample = item;
                    break;
                }
            }
            return sample;
        }
    }
}
