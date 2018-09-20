using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class SolidReportTemplate
    {
        private ReportHeader reportHeader;
        private string runID;
        private string filePath;
        private string fileName;
        private IList samples;
        private IList dataTables;

        public SolidReportTemplate(ReportHeader reportHeader, IList samples, IList dataTables)
        {
            this.runID = "";
            this.reportHeader = reportHeader;
            this.filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            "\\ResearchReports\\";
            this.dataTables = new ArrayList(dataTables);
            this.samples = new ArrayList(samples);
            string dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            fileName = dateString + "_" + reportHeader.ProjectNumber + ".xlsx";
        }

        public void Create()
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            ExcelTemplate excelTemplate = new ExcelTemplate(filePath, fileName);
            excelTemplate.Open();
            excelTemplate.AddNewWorkbook();

            for (int i = 0; i < samples.Count; i++)
            {
                SolidSample sample = (SolidSample)samples[i];
                if(i == 0)
                {
                    this.runID = sample.RunID;
                }
                Worksheet worksheet = CreateNewWorksheet(excelTemplate, i);

                InsertReportHeader(worksheet, sample);
                InsertSampleName(worksheet, sample.SampleName);

                System.Data.DataTable dataTable = (System.Data.DataTable)dataTables[i];
                ExcelDataTable excelDataTable = CreateNewExcelDataTable(dataTable, 18);
                InsertResultsTable(excelTemplate, worksheet, excelDataTable);
                FormatResultsTable(worksheet, excelDataTable);
            }
            excelTemplate.SaveAtServer(FileLocations.ServerPath, this.runID, this.reportHeader.ProjectNumber);
            excelTemplate.Save();
            excelTemplate.ShowExcelApp(true);
            excelTemplate.Close();
        }

        private void InsertReportHeader(Worksheet worksheet, SolidSample sample)
        {
            int rowIndex = 1;
            string resultUnit = reportHeader.InstrumentResultUnit;

            InsertReportHeaderRow(worksheet, "A" + rowIndex, "K" + rowIndex, "TOXIKON METALS DEPT.", true, true);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "K" + rowIndex, "DATA REPORT", true, true);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "SPONSOR", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.SponsorName, 
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "PROJECT #", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.ProjectNumber, 
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "ANALYTICAL METHOD", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.AnalyticalMethod, 
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "INSTRUMENT", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.InstrumentID,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "ANALYST", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.Analyst, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "PREP DATE", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, reportHeader.PrepDate, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "ANALYSIS DATE", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, sample.RunDate, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "ANALYTICAL RUN ID", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "K" + rowIndex, sample.RunID, false, false);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "K" + rowIndex,
                @"CORRECTED RESULT(" + resultUnit + ")= result(" + resultUnit +") - (blk correction) " +
                  "x analytical dilution factor", false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "K" + rowIndex,
            "RESULT(" + sample.CalculatedResultUnit + ")= (Result(" + sample.RawFileResultUnit + ") x " +
            "Final Vol(" + sample.FinalVolumeUnit + ")) / Weight Digested(" + sample.WeightDigestedUnit +
            ")", false, false);
        }

        private void InsertReportHeaderRow(Worksheet worksheet, string startCell, string endCell,
                                            string value, bool isBold, bool isCenter)
        {
            Range range = worksheet.get_Range(startCell + ":" + endCell);
            range.Merge();
            range.Value = value;
            range.Font.Bold = isBold;
            if(isCenter)
            {
                ExcelTemplate.SetTopAlignCenter(worksheet, startCell, endCell);
            }
            else
            {
                ExcelTemplate.SetTopAlignLeft(worksheet, startCell, endCell);
            }
        }

        private void InsertSampleName(Worksheet worksheet, string sampleName)
        {
            Range range = worksheet.get_Range("A16:K16");
            range.Merge();
            range.Value = "Sample: " + sampleName;
            range.Font.Bold = true;
        }

        private ExcelDataTable CreateNewExcelDataTable(System.Data.DataTable dataTable, int startRowIndex)
        {
            ExcelDataTable excelDataTable = new ExcelDataTable();
            excelDataTable.SetDataTable(dataTable);
            excelDataTable.StartRowIndex = startRowIndex;
            excelDataTable.TopLeft = "A" + startRowIndex;
            excelDataTable.SetBottomRight();
            excelDataTable.TableName = "ReportDataTable";
            excelDataTable.TableStyleName = "TableStyleLight18";

            return excelDataTable;
        }

        private Worksheet CreateNewWorksheet(ExcelTemplate excelTemplate, int sheetIndex)
        {
            string sheetName = "sample" + (sheetIndex + 1);
            excelTemplate.AddNewWorksheet(sheetName);
            Worksheet worksheet = excelTemplate.GetWorksheet(sheetName);
            return worksheet;
        }

        private void InsertResultsTable(ExcelTemplate excelTemplate, Worksheet worksheet, 
                                        ExcelDataTable excelDataTable)
        {
            excelTemplate.InsertDataTable(worksheet, excelDataTable);
            excelTemplate.SetDataTableColumnWidth(worksheet, excelDataTable, 13);
        }

        private void FormatResultsTable(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            ExcelTemplate.SetWrapText(worksheet, excelDataTable.TopLeft, excelDataTable.BottomRight);
            ExcelTemplate.SetTopAlignCenter(worksheet, excelDataTable.TopLeft, excelDataTable.BottomRight);
        }
    }
}
