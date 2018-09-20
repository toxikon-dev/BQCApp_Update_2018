using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Reports
{
    public class ExcelTemplate
    {
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Workbook workbook;
        private Dictionary<string, Worksheet> worksheetDictionary;
        private string filePath;
        private string fileName;

        public ExcelTemplate()
        {
            fileName = "";
            filePath = "";
        }

        public ExcelTemplate(string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
            worksheetDictionary = new Dictionary<string, Worksheet>() { };
        }

        public Worksheet GetWorksheet(string worksheetName)
        {
            Worksheet result = null;
            if(this.worksheetDictionary.ContainsKey(worksheetName))
            {
                result = this.worksheetDictionary[worksheetName];
            }
            return result;
        }

        public void Open()
        {
            excelApp = new Application();
        }

        public void AddNewWorkbook()
        {
            workbook = excelApp.Workbooks.Add(Type.Missing);
        }

        public void AddNewWorksheet(string worksheetName)
        {
            if(WorksheetNameExists(worksheetName))
            {
                Debug.WriteLine("Worksheet name already exists.");
            }
            else
            {
                Worksheet worksheet = CreateNewWorksheet(worksheetName);
                AddNewWorksheetToDictionary(worksheet);
            }
        }

        private bool WorksheetNameExists(string worksheetName)
        {
            bool result = this.worksheetDictionary.ContainsKey(worksheetName) ? true : false;
            return result;
        }

        private Worksheet CreateNewWorksheet(string worksheetName)
        {
            Worksheet worksheet = null;
            int lastWorksheetIndex = this.workbook.Worksheets.Count;
            if (this.worksheetDictionary.Count == 0)
            {
                worksheet = this.workbook.Worksheets[lastWorksheetIndex];
            }
            else
            {
                object afterWorksheet = this.workbook.Worksheets[lastWorksheetIndex];
                worksheet = this.workbook.Worksheets.Add(Type.Missing, afterWorksheet, Type.Missing, Type.Missing);
            }
            worksheet.Name = worksheetName;
            return worksheet;
        }

        private void AddNewWorksheetToDictionary(Worksheet worksheet)
        {
            this.worksheetDictionary.Add(worksheet.Name, worksheet);
        }

        public void InsertDataTable(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            SetDataTableRange(worksheet, excelDataTable);
            InsertDataTableColumns(worksheet, excelDataTable);
            InsertDataTableRows(worksheet, excelDataTable);
            SetDataTableColumnAutoFit(worksheet, excelDataTable);
        }

        private void SetDataTableRange(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            Range dataTableRange = worksheet.get_Range(excelDataTable.TopLeft + ":" + excelDataTable.BottomRight);
            worksheet.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, dataTableRange, Type.Missing,
                                        XlYesNoGuess.xlNo, Type.Missing).Name = excelDataTable.TableName;
            worksheet.ListObjects.get_Item(excelDataTable.TableName).TableStyle = excelDataTable.TableStyleName;
            worksheet.ListObjects.get_Item(excelDataTable.TableName).ShowAutoFilterDropDown = false;
        }

        private void InsertDataTableColumns(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            int rowIndex = excelDataTable.StartRowIndex;
            int colCount = excelDataTable.ColumnCount;
            for (int i = 0; i < colCount; i++)
            {
                worksheet.Cells[rowIndex, i + 1] = excelDataTable.GetColumnName(i);
            }
        }

        private void InsertDataTableRows(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            int rowCount = excelDataTable.RowCount;
            int colCount = excelDataTable.ColumnCount;
            int rowIndex;
            int colIndex;
            for (rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {
                for (colIndex = 0; colIndex < colCount; colIndex++)
                {
                    string result = excelDataTable.GetCellValueAt(rowIndex - 1, colIndex);
                    worksheet.Cells[rowIndex + 1, colIndex + 1] = result != "" ? result : "=NA()";
                }
            }
        }

        private void SetDataTableColumnAutoFit(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            Range dataTableRange = worksheet.get_Range(excelDataTable.TopLeft + ":" + excelDataTable.BottomRight);
            dataTableRange.EntireColumn.AutoFit();
        }

        public void InsertChart(Worksheet worksheet, ExcelDataTable excelDataTable, 
                                ExcelChartProperties chartProperties)
        {
            Range dataTableRange = worksheet.get_Range(excelDataTable.TopLeft + ":" + excelDataTable.BottomRight);
            chartProperties.Top = (float)(double)dataTableRange.Top + 
                                  (float)(double)dataTableRange.Height + 100;

            ChartObjects charts = worksheet.ChartObjects();
            ChartObject chartObject = charts.Add(chartProperties.Left, chartProperties.Top, 
                                      chartProperties.Width, chartProperties.Height);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartProperties.ChartType;
            chart.ChartStyle = chartProperties.ChartStyle;
            chart.ChartColor = chartProperties.ChartColor;

            InsertSeries(worksheet, excelDataTable, chartProperties, chart);
        }

        private void InsertSeries(Worksheet worksheet, ExcelDataTable excelDataTable, 
                                  ExcelChartProperties chartProperties, Chart chart)
        {
            SeriesCollection seriesCollection = chart.SeriesCollection(Type.Missing);
            IList chartSeriesPropertiesList = chartProperties.ChartSeriesPropDictionary.Values.ToList();
            foreach(ChartSeriesProperties seriesProperties in chartSeriesPropertiesList)
            {
                Range seriesRange = worksheet.get_Range(seriesProperties.RangeName);
                Range XValuesRange = worksheet.get_Range(seriesProperties.XValuesRangeName);
                Series series = seriesCollection.Add(seriesRange, XlRowCol.xlColumns, Type.Missing,
                                Type.Missing, Type.Missing);
                series.Values = seriesRange;
                series.Name = seriesProperties.SeriesName;
                series.XValues = XValuesRange;
            }
        }

        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public void Save()
        {
            excelApp.ActiveWorkbook.SaveAs(filePath + fileName, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlLocalSessionChanges,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        public void ShowExcelApp(bool value)
        {
            this.excelApp.Visible = value;
        }

        public void Close()
        {
            excelApp = null;
        }
    }
}
