using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Results
{
    public class BQCResultFile
    {
        private string fileName;
        private string filePath;
        public BQCSampleResult LCSSampleResult { get; private set; }
        Microsoft.Office.Interop.Excel.Application excelApp;
        Worksheet worksheet;

        public BQCResultFile(string filePath)
        {
            this.filePath = filePath;
            this.fileName = Path.GetFileName(filePath);
            LCSSampleResult = new BQCSampleResult();
        }

        public void Parse()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;
            Workbook workbook = excelApp.Workbooks.Open(this.filePath,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing);
            worksheet = workbook.Sheets[1];
            worksheet.Select(Type.Missing);

            LCSSampleResult.SampleType = "LCS";
            LCSSampleResult.InstrumentID = GetRangeStringValue("C4", Type.Missing);
            string runDate = GetRangeStringValue("C7", Type.Missing);
            LCSSampleResult.RunDate = GetRunDate(runDate);
            LCSSampleResult.SetRunID();
            LCSSampleResult.SetResultUnit();
            LCSSampleResult.LoadElements();
            GetLCSElementResults();

            workbook.Close();
            excelApp.Quit();
        }

        public void GetLCSElementResults()
        {
            int rowIndex = 17;
            string colA_val = GetRangeStringValue("A" + rowIndex, Type.Missing);
            double colC_val = GetRangeNumberValue("C" + rowIndex, Type.Missing);
            while(colA_val != "")
            {
                Element element;
                if (LCSSampleResult.ElementDictionary.TryGetValue(colA_val, out element))
                {
                    element.RunID = LCSSampleResult.RunID;
                    element.InstrumentID = LCSSampleResult.InstrumentID;
                    element.ResultValue = colC_val;
                    element.ResultUnit = LCSSampleResult.ResultUnit;
                    element.IsActive = true;
                    LCSSampleResult.Elements.Add(element);
                }
                rowIndex += 1;
                colA_val = GetRangeStringValue("A" + rowIndex, Type.Missing);
                colC_val = GetRangeNumberValue("C" + rowIndex, Type.Missing);
            }
        }

        public string GetRangeStringValue(object cell1, object cell2)
        {
            string value = "";
            Range range = worksheet.get_Range(cell1, Type.Missing);
            if (range != null)
            {
                value = Convert.ToString(range.Text);
            }
            return value;
        }

        public double GetRangeNumberValue(object cell1, object cell2)
        {
            double value = 0;
            Range range = worksheet.get_Range(cell1, Type.Missing);
            if (range.Text != "")
            {
                value = range.Value2;
            }
            return value;
        }

        public static DateTime GetRunDate(string runDate)
        {
            string pattern = "M/d/yyyy";
            DateTime parsedDate = DateTime.ParseExact(runDate, pattern, null, DateTimeStyles.None);
            return parsedDate;
        }

    }
}
