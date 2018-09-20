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
    public class ICPMS_RawFile
    {
        private string fileName;
        private string[] data;
        private int lineIndex;
        public List<SampleResult> SampleResults { get; private set; }
        private List<string> units;
        private List<string> elementSymbols;
        private IList<Element> elements;

        public ICPMS_RawFile(string filePath, IList<Element> elements)
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
                lineIndex = 0;
                if (data.Length > 0)
                {
                    ParseElementLine(data[0]);
                    lineIndex += 1;
                    ParseUnitLine(data[1]);
                    lineIndex += 1;
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
            sampleResult.InstrumentID = GetInstrument(line);
            sampleResult.InstrumentUnit = Units.PPB;
            sampleResult.RunID = this.fileName.Split('.')[0];
            sampleResult.SampleName = GetSampleName();
            sampleResult.RunDate = GetRunDate(line);
            
            sampleResult.SetElementDictionary(elements);
            lineIndex += 1;
            line = data[lineIndex];
            while (line.Substring(0, 1) != "x")
            {
                lineIndex += 1;
                line = data[lineIndex];
            }
            ParseResultLine(sampleResult, line);
            SampleResults.Add(sampleResult);
            lineIndex += 4;
        }

        private void ParseElementLine(string line)
        {
            try
            {
                string[] splits = line.Split(new Char[] { ',' }, StringSplitOptions.None);
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

        private void ParseUnitLine(string line)
        {
            string[] splits = line.Split(new Char[] { ',' }, StringSplitOptions.None);
            for (int i = 0; i < splits.Count(); i++)
            {
                units.Add(splits[i]);
            }
        }

        private string GetSampleName()
        {
            string result = "";
            string line = data[lineIndex];
            string[] split = line.Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Count() != 0)
            {
                for (var i = 0; i < split.Count(); i++)
                {
                    if (split[i] != "method")
                    {
                        result = result + split[i] + ' ';
                    }
                    else
                    {
                        result = result.Remove(result.Length - 1);
                        break;
                    }
                }
            }
            return result;
        }

        private string GetInstrument(string line)
        {
            string pattern = @"instrument\s\d+";
            Match result = Regex.Match(line, pattern);
            string resultString = result.ToString().Replace("instrument ", "");
            return resultString;
        }

        public static DateTime GetRunDate(string line)
        {
            string dateFormat = @"\d+\/\d+\/\d{4} \d+:\d{2}:\d{2} (AM|PM)";
            Match result = Regex.Match(line.Trim(), dateFormat);
            string pattern = "M/d/yyyy h:mm:ss tt";
            DateTime parsedDate = DateTime.ParseExact(result.ToString(), pattern, null, DateTimeStyles.None);
            return parsedDate;
        }

        private void ParseResultLine(SampleResult sampleResult, string line)
        {
            string[] splits = line.Split(new char[] { ',' }, StringSplitOptions.None);
            for(int i = 0; i < splits.Count(); i++)
            {
                double number;
                if(Double.TryParse(splits[i], out number))
                {
                    string elementSymbol = elementSymbols[i];
                    if(sampleResult.ElementDictionary.ContainsKey(elementSymbol))
                    {
                        Element element = sampleResult.ElementDictionary[elementSymbol];
                        double result = Convert.ToDouble(number);
                        string unit = units[i];
                        if(unit == Units.PPM)
                        {
                            result = Convert_PPM_To_PPB(result);
                            unit = Units.PPB;
                        }
                        element.ResultValue = result;
                        element.ResultUnit = unit;
                    }
                }
            }
        }

        private double Convert_PPM_To_PPB(double number)
        {
            return number * 1000;
        }

        public SampleResult SearchSampleByName(string name)
        {
            SampleResult sample = new SampleResult();
            foreach(SampleResult item in this.SampleResults)
            {
                if(item.SampleName.Contains(name))
                {
                    sample = item;
                    break;
                }
            }
            return sample;
        }
    }
}
