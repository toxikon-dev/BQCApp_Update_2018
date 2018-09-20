using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class ICPMSQ_RawFile
    {
        private string fileName;
        private string[] data;
        public int lineIndex;
        public List<SampleResult> SampleResults { get; private set; }
        private List<string> units;
        private List<string> elementSymbols;
        private IList<Element> elements;

        public ICPMSQ_RawFile(string filePath, IList<Element> elements)
        {
            this.fileName = Path.GetFileName(filePath);
            this.data = File.ReadAllLines(filePath);
            SampleResults = new List<SampleResult>() { };
            units = new List<string>() { };
            elementSymbols = new List<string>() { };
            this.elements = new List<Element>(elements);
        }

        public void Parse()
        {
            try
            {
               lineIndex = 4;

               if (data.Length > 0)
               {
                   ParseElementLine(data[2]);

                   while (lineIndex < data.Length)
                    {
                        ParseSampleResult();
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
            string line = data[lineIndex];
            SampleResult sampleResult = new SampleResult();
            sampleResult.InstrumentID = Instruments.ICP_3180;
            sampleResult.InstrumentUnit = Units.PPB;
            sampleResult.RunID = this.fileName.Split('.')[0];   
            sampleResult.SetElementDictionary(elements);
            sampleResult.RunDate = GetRunDate(fileName);
                  
         
           if (lineIndex < data.Length) { 

            sampleResult.SampleName = GetSampleName(lineIndex);
           // sampleResult.RunDate = GetRunDate(lineIndex); 
            ParseResultLine(sampleResult, lineIndex);
            SampleResults.Add(sampleResult);
            
            lineIndex +=1;
           }
        }

        private void ParseElementLine(string line)
        {
            try
            {
                string[] splits = line.Split(new char[] { ',' }, StringSplitOptions.None);
                for (int i = 0; i < splits.Count(); i++)
                {
                    elementSymbols.Add(splits[i]);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

  

        private string GetSampleName(int lineIndex)
        {
            string result = "";
          //  int index1 = lineIndex+1;

            if (lineIndex < data.Length)
            {
                string line = data[lineIndex];
                string[] splits = line.Split(new char[] { ',' }, StringSplitOptions.None);
                result = splits[1];
            }
       
            return result;
        }

      

        public DateTime GetRunDate(string fileName)
        {
             
               string year = fileName.Substring(0,2);
               string month = fileName.Substring(2,2);
               string date = fileName.Substring(4,2);
               string time = month + date + year;
              string pattern = "MMddyy";
              DateTime parsedDate = DateTime.ParseExact(time, pattern, null, DateTimeStyles.None);
              return parsedDate;
            
        }

        private void ParseResultLine(SampleResult sampleResult, int lineIndex)
        {
            if (lineIndex < data.Length) 
            {
               string line = data[lineIndex];

               string[] splits = line.Split(new char[] { ',' }, StringSplitOptions.None);

                for (int i = 49; i > 1; i--)
                {
                    double number;

                    if (Double.TryParse(splits[i], NumberStyles.Number, CultureInfo.InvariantCulture, out number))
                    {
                        
                        string elementSymbol = elementSymbols[i];
                       
                        if (sampleResult.ElementDictionary.ContainsKey(elementSymbol))
                        {
                               Element element = sampleResult.ElementDictionary[elementSymbol];
                               element.ResultValue = number;
                               element.ResultUnit = Units.ICPMSQ_RESULT_UNIT;
                                                  
                        }
                    }
              
                }
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

