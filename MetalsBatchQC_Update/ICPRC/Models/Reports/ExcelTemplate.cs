﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.ICPRC.Models
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
            if (this.worksheetDictionary.ContainsKey(worksheetName))
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
            Style excelStyle = workbook.Styles.Add("StandardStyle");
            excelStyle.Font.Name = "Segoe UI";
            excelStyle.Font.Size = 14;
            
        }

        public void AddNewWorksheet(string worksheetName)
        {
            if (WorksheetNameExists(worksheetName))
            {
                Debug.WriteLine("Worksheet name already exists.");
            }
            else
            {
                Worksheet worksheet = CreateNewWorksheet(worksheetName);
                AddNewWorksheetToDictionary(worksheet);
            }
        }

        public bool WorksheetNameExists(string worksheetName)
        {
            bool result = this.worksheetDictionary.ContainsKey(worksheetName) ? true : false;
            return result;
        }

        private Worksheet CreateNewWorksheet(string worksheetName)
        {
            Worksheet worksheet = null;
            int lastWorksheetIndex = this.workbook.Worksheets.Count;
            if (lastWorksheetIndex == 0)
            {
                worksheet = this.workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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
            int startRowIndex = excelDataTable.StartRowIndex;
            
            int colIndex;
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {
                for (colIndex = 0; colIndex < 2; colIndex++)
                {
                    string result = excelDataTable.GetCellValueAt(rowIndex - 1, colIndex);
                    double number;
                    if(Double.TryParse(result, out number))
                    {
                        Range numberRange1 = worksheet.Cells[startRowIndex + rowIndex, colIndex + 1];
                     
                        numberRange1.NumberFormat = "0.0000";
                    }
                    worksheet.Cells[startRowIndex + rowIndex, colIndex + 1] = result != "" ? result : "=NA()";
                }

                for (colIndex = 2; colIndex < colCount; colIndex++)
                {
                    string result = excelDataTable.GetCellValueAt(rowIndex - 1, colIndex);
                    double number;
                    if (Double.TryParse(result, out number))
                    {
                        Range numberRange2 = worksheet.Cells[startRowIndex + rowIndex, colIndex + 1];

                        numberRange2.NumberFormat = "0.000";
                    }
                    worksheet.Cells[startRowIndex + rowIndex, colIndex + 1] = result != "" ? result : "=NA()";
                }
            }
        }

        public void SetDataTableColumnAutoFit(Worksheet worksheet, ExcelDataTable excelDataTable)
        {
            Range dataTableRange = worksheet.get_Range(excelDataTable.TopLeft + ":" + excelDataTable.BottomRight);
            dataTableRange.EntireColumn.AutoFit();
        }

        public void SetDataTableColumnWidth(Worksheet worksheet, ExcelDataTable excelDataTable, int width)
        {
            Range dataTableRange = worksheet.get_Range(excelDataTable.TopLeft + ":" + excelDataTable.BottomRight);
            dataTableRange.ColumnWidth = width;
        }

        public static void SetFontSize(Worksheet worksheet, string startCell, string endCell, int fontSize)
        {
            Range dataTableRange = worksheet.get_Range(startCell + ":" + endCell);
            dataTableRange.Font.Size = fontSize;
        }

        public static void SetWrapText(Worksheet worksheet, string startCell, string endCell)
        {
            Range dataTableRange = worksheet.get_Range(startCell + ":" + endCell);
            dataTableRange.WrapText = true;
        }

        public static void SetTopAlignCenter(Worksheet worksheet, string startCell, string endCell)
        {
            Range dataTableRange = worksheet.get_Range(startCell + ":" + endCell);
            dataTableRange.VerticalAlignment = XlVAlign.xlVAlignTop;
            dataTableRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }

        public static void SetTopAlignLeft(Worksheet worksheet, string startCell, string endCell)
        {
            Range dataTableRange = worksheet.get_Range(startCell + ":" + endCell);
            dataTableRange.VerticalAlignment = XlVAlign.xlVAlignTop;
            dataTableRange.HorizontalAlignment = XlHAlign.xlHAlignLeft;
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
            excelApp.ActiveWorkbook.SaveAs(this.filePath + this.fileName, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlLocalSessionChanges,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        public void SaveAtServer(string serverPath, string runID, string projectNumber)
        {
            if (!Directory.Exists(serverPath + runID + "\\"))
            {
                Directory.CreateDirectory(serverPath + runID + "\\");
            }
            excelApp.ActiveWorkbook.SaveAs(serverPath + runID + "\\" + projectNumber + ".xlsx", 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
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
