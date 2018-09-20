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
    public class BQCReportTemplate
    {
        private Report report;
        private string filePath;
        private string fileName;
        private System.Data.DataTable dataTable;
        private string runDate;

        public BQCReportTemplate(System.Data.DataTable dataTable, string runDate)
        {
            report = Report.GetInstance();
            this.filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            "\\ResearchReports\\";
            this.dataTable = dataTable;
            this.runDate = runDate;
            string dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            fileName = dateString + "_" + report.ReportHeader.ProjectNumber + "_MB,LCS,LCSD.xlsx";
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

            Worksheet worksheet = CreateNewWorksheet(excelTemplate);
            InsertReportHeader(worksheet, report.ReportHeader);
            
            ExcelDataTable excelDataTable = CreateNewExcelDataTable(this.dataTable, 16);
            InsertResultsTable(excelTemplate, worksheet, excelDataTable);
            FormatResultsTable(worksheet, excelDataTable);

            excelTemplate.Save();
            excelTemplate.ShowExcelApp(true);
            excelTemplate.Close();
        }

        private void InsertReportHeader(Worksheet worksheet, ReportHeader reportHeader)
        {
            int rowIndex = 1;

            InsertReportHeaderRow(worksheet, "A" + rowIndex, "I" + rowIndex,
                "TOXIKON METALS DEPT BATCH QC REPORT", true, true);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "BATCH CODE", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, reportHeader.BatchCode,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "INSTRUMENT ID", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, reportHeader.InstrumentID,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "ANALYST", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, reportHeader.Analyst,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "PREP DATE", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, reportHeader.PrepDate,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "RUN DATE", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, runDate,
                                  false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "B" + rowIndex, "PROJECT #", true, false);
            InsertReportHeaderRow(worksheet, "C" + rowIndex, "I" + rowIndex, reportHeader.ProjectNumber,
                                  false, false);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "I" + rowIndex,
                "LCS % recovery=(LCS/true value) x 100", false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "I" + rowIndex,
                "MS % recovery=(MS-sample /true value) x 100", false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "I" + rowIndex,
                "RPD=((sample-dup) / AVG(sample+dup)) x 100", false, false);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "I" + rowIndex,
                "RESULTS IN " + reportHeader.InstrumentResultUnit, false, false);
        }

        private void InsertReportHeaderRow(Worksheet worksheet, string startCell, string endCell,
                                            string value, bool isBold, bool isCenter)
        {
            Range range = worksheet.get_Range(startCell + ":" + endCell);
            range.Merge();
            range.Value = value;
            range.Font.Bold = isBold;
            if (isCenter)
            {
                ExcelTemplate.SetTopAlignCenter(worksheet, startCell, endCell);
            }
            else
            {
                ExcelTemplate.SetTopAlignLeft(worksheet, startCell, endCell);
            }
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

        private Worksheet CreateNewWorksheet(ExcelTemplate excelTemplate)
        {
            string sheetName = "BQCSOILJ";
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
