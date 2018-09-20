using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Models.Reports
{
    public class ControlChartReport
    {
        public System.Data.DataTable ReportDataTable { get; private set; }
        private System.Data.DataTable CurrentDataTable;
        public string ReportName { get; private set; }
        public int ReportMonth { get; set; }
        public int ReportYear { get; set; }
        public string InstrumentID { get; set; }
        private string filePath;
        public BackgroundWorker ExcelBackgroundWorker { get; set; }
        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;
        public delegate void DownloadComplete();
        public event DownloadComplete OnDownloadComplete;

        private double progressValue;
        private double worksheetTaskPercentage;

        public ControlChartReport()
        {
            ReportDataTable = new System.Data.DataTable();
            this.ReportMonth = 04 / 1;
            this.ReportYear = 2015;
            this.InstrumentID = "";
            this.filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            "\\BQCApp\\";
            progressValue = 0;
            worksheetTaskPercentage = 0;
        }

        private void InitBackgroundWorker()
        {
            System.Threading.SynchronizationContext.SetSynchronizationContext(new
                            WindowsFormsSynchronizationContext());
            this.ExcelBackgroundWorker = new BackgroundWorker();
            this.ExcelBackgroundWorker.WorkerReportsProgress = true;
            this.ExcelBackgroundWorker.WorkerSupportsCancellation = false;
            this.ExcelBackgroundWorker.DoWork += new DoWorkEventHandler(
                            this.BackgroundWorkder_DoWork);
            this.ExcelBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(
                            this.BackgroundWorkder_ProcessChanged);
            this.ExcelBackgroundWorker.RunWorkerCompleted += new
                            RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
        }

        private void BackgroundWorkder_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportDownloadProgress(0);
            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            Microsoft.Office.Interop.Excel.Application excelApp = new
                                                    Microsoft.Office.Interop.Excel.Application();
            try
            {
                SetReportName();
                ReportDownloadProgress(1);               
                Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                excelApp.Visible = true;
                CreateWorkbook(workbook);
                /*excelApp.ActiveWorkbook.SaveAs(filePath + this.ReportName, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlLocalSessionChanges,
                   Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/
                
                excelApp.ActiveWorkbook.SaveAs(filePath + this.ReportName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, 
                    Type.Missing,Type.Missing,true,false,  
                    XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlLocalSessionChanges,
                    Type.Missing,Type.Missing);
               
               ReportDownloadProgress(1);
               
              
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                excelApp = null;
            }
            finally
            {
                if (excelApp != null)
                {
                    Marshal.ReleaseComObject(excelApp);
                                      
                    excelApp = null;                }
            }
        }

        private void ReportDownloadProgress(double percentage)
        {
            this.progressValue += percentage;
            this.ExcelBackgroundWorker.ReportProgress(Convert.ToInt32(this.progressValue));
        }

        private void BackgroundWorkder_ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.OnProgressUpdate != null)
            {
                this.OnProgressUpdate(e.ProgressPercentage);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                if (this.OnDownloadComplete != null)
                {
                    this.OnDownloadComplete();
                }
                MessageBox.Show("Download complete!");
            }
        }

        public void CreateExcelReport()
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            try
            {
                SetReportDataTable();

                if (this.ReportDataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.");
                }
                else
                {
                    InitBackgroundWorker();
                    ExcelBackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetReportName()
        {
            this.ReportName = this.ReportYear.ToString() + this.ReportMonth.ToString("00") +
                              "_" + this.InstrumentID + "_" + "ControlChartReport.xlsx";
        }

        private void SetReportDataTable()
        {
            switch (this.InstrumentID)
            {
                case Instruments.ICP_2224:
                    this.ReportDataTable = BATCHQC_REPORT.GetControlChartReportForICPMS(
                                           this.InstrumentID, this.ReportMonth, this.ReportYear);
                    break;
                case Instruments.ICP_3180:
                    this.ReportDataTable = BATCHQC_REPORT.GetControlChartReportForICPMSQ(
                                           this.InstrumentID, this.ReportMonth, this.ReportYear);
                    break;
                case Instruments.ICP_2995:
                    this.ReportDataTable = BATCHQC_REPORT.GetControlChartReportForICAP(
                                          this.InstrumentID, this.ReportMonth, this.ReportYear);
                    break;
                case Instruments.ICP_3666:
                    this.ReportDataTable = BATCHQC_REPORT.GetControlChartReportForICAPRQ(
                                          this.InstrumentID, this.ReportMonth, this.ReportYear);
                    break;
                default:
                    break;
            }
        }

        private void CreateWorkbook(Workbook workbook)
        {
            switch (this.InstrumentID)
            {
                case Instruments.ICP_2224:
                    this.worksheetTaskPercentage = 98;
                    this.CreateICPMSWorkBook(workbook);
                    break;
                case Instruments.ICP_3180:
                    this.worksheetTaskPercentage = (98/2);
                    this.CreateICPMSQWorkBook(workbook);
                    break;
                case Instruments.ICP_2995:
                    this.worksheetTaskPercentage = (98 / 2);
                    this.CreateICAPWorkbook(workbook);
                    break;
                case Instruments.ICP_3666:
                    this.worksheetTaskPercentage = (98 / 2);
                    this.CreateICAPRQWorkBook(workbook);
                    break;
                default:
                    break;
            }
        }

        private void CreateICAPWorkbook(Workbook workbook)
        {
            CurrentDataTable = this.ReportDataTable;
            DataRow[] dataSet1 = this.ReportDataTable.Select("Low = 0.85 AND High = 1.15");
            CreateNewWorksheet(workbook.Worksheets[1], dataSet1);

            DataView view = new DataView(this.ReportDataTable);
            System.Data.DataTable dataTable2 = view.ToTable(false, "BatchCode", "SequenceNumber", "RunDate",
                                               "Low", "High", "Ca", "K", "Mg", "Na");
            CurrentDataTable = dataTable2;
            DataRow[] dataSet2 = dataTable2.Select("Low = 4.25 AND High = 5.75");
            object afterObject = workbook.Worksheets[1];
            Worksheet worksheet2 = workbook.Worksheets.Add(Type.Missing, afterObject, Type.Missing,
                                  Type.Missing);
            CreateNewWorksheet(worksheet2, dataSet2);
        }

        private void CreateICPMSWorkBook(Workbook workbook)
        {
            CurrentDataTable = this.ReportDataTable;
            DataRow[] dataSet1 = this.ReportDataTable.Select("Low = 60 AND High = 90");
            CreateNewWorksheet(workbook.Worksheets[1], dataSet1);


        }

        private void CreateICPMSQWorkBook(Workbook workbook)
        {
            DataView view = new DataView(this.ReportDataTable);
            System.Data.DataTable dataTable1 = view.ToTable(false, "BatchCode", "SequenceNumber", "RunDate",
                                               "Low", "High", "Be","B",
                                               "Na","Mg","Al","Si","K","Ca","Sc",
                                               "Ti","V","Cr","Mn","Fe","Co","Ni",
                                               "Cu","Zn","Ga","Ge","As","Se",
                                               "Sr","Zr","Nb","Mo","Ru","Rh","Pd",
                                               "Ag","Cd","Ln","Sn","Sb","Ba","Nd",
                                               "Gd","Tb","Ta","W","Re","Ir","Pt",
                                               "Au","Tl","Pb","Bi");
            CurrentDataTable = dataTable1;
            Worksheet worksheet1 = workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing,
                                                           Type.Missing);
            DataRow[] dataSet1 = this.ReportDataTable.Select("Low =60 AND High = 90");
            CreateNewWorksheet(worksheet1, dataSet1);

            DataView view2 = new DataView(this.ReportDataTable);
            System.Data.DataTable dataTable2 = view2.ToTable(false, "BatchCode", "SequenceNumber", "RunDate",
                                               "Low", "High", "Li");
            CurrentDataTable = dataTable2;
            DataRow[] dataSet2 = dataTable2.Select("Low=40 AND High =60");
            object afterObject = workbook.Worksheets[1];
            Worksheet worksheet2 = workbook.Worksheets.Add(Type.Missing, afterObject, Type.Missing,
                                 Type.Missing);
           
            CreateNewWorksheet(worksheet2, dataSet2);

            DataView view3 = new DataView(this.ReportDataTable);
            System.Data.DataTable dataTable3 = view2.ToTable(false, "BatchCode", "SequenceNumber", "RunDate",
                                               "Low", "High", "Os");
            CurrentDataTable = dataTable3;
            DataRow[] dataSet3 = dataTable3.Select("Low = 1.6 AND High = 2.4");
            object afterObject1 = worksheet2;
            Worksheet worksheet3 = workbook.Worksheets.Add(Type.Missing, afterObject1, Type.Missing,
                                  Type.Missing);
          
            CreateNewWorksheet(worksheet3, dataSet3);
        }

        private void CreateNewWorksheet(Worksheet worksheet, DataRow[] rows)
        {
            FormatReportDataTable(worksheet, rows);
            ReportDownloadProgress(1);
            InsertReportDataTableColumns(worksheet);
            ReportDownloadProgress(1);

            double taskPercentage = (this.worksheetTaskPercentage - 3) / 2;
            InsertReportDataTableRows(worksheet, rows, taskPercentage);

            FormatTableColumnAutoFit(worksheet, rows);
            ReportDownloadProgress(1);

            CreateReportDataTableChart(worksheet, rows, taskPercentage);
        }



        private void CreateICAPRQWorkBook(Workbook workbook)
        {
            CurrentDataTable = this.ReportDataTable;
            DataRow[] dataSet1 = this.ReportDataTable.Select("Low = 1 AND High = 1");
            CreateNewWorksheet(workbook.Worksheets[1], dataSet1);
        }

        private void InsertReportDataTableColumns(Worksheet worksheet)
        {
            int rowIndex = 3;
            int colCount = this.CurrentDataTable.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                worksheet.Cells[rowIndex, i + 1] = this.CurrentDataTable.Columns[i].ColumnName;
            }
        }

        private void InsertReportDataTableRows(Worksheet worksheet, DataRow[] rows, double taskPercentage)
        {
            int rowCount = rows.Count();
            int colCount = this.CurrentDataTable.Columns.Count;

            int rowIndex;
            int colIndex;
            double subTaskPercentage = (taskPercentage) / rowCount;
            for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (colIndex = 1; colIndex < colCount + 1; colIndex++)
                {
                    string result = rows[rowIndex][colIndex - 1].ToString();
                    worksheet.Cells[rowIndex + 4, colIndex] = result != "" ? result : "=NA()";
                }
                ReportDownloadProgress(subTaskPercentage);
            }
        }
        private void FormatReportDataTable(Worksheet worksheet, DataRow[] rows)
        {
            string lastColumnName = GetExcelColumnName(this.CurrentDataTable.Columns.Count);
            int lastRowNumber = 2 + rows.Count();
            Range dataTableRange = worksheet.get_Range("A3:" + lastColumnName + lastRowNumber);
            worksheet.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, dataTableRange, Type.Missing,
                                        XlYesNoGuess.xlNo, Type.Missing).Name = "ReportDataTableStyle";
            worksheet.ListObjects.get_Item("ReportDataTableStyle").TableStyle = "TableStyleLight21";
            worksheet.ListObjects.get_Item("ReportDataTableStyle").ShowAutoFilterDropDown = false;
        }

        private void FormatTableColumnAutoFit(Worksheet worksheet, DataRow[] rows)
        {
            string lastColumnName = GetExcelColumnName(this.CurrentDataTable.Columns.Count);
            int lastRowNumber = 3 + rows.Count();
            Range dataTableRange = worksheet.get_Range("A3:" + lastColumnName + lastRowNumber);
            dataTableRange.EntireColumn.AutoFit();
        }
        private void CreateReportDataTableChart(Worksheet worksheet, DataRow[] rows, double taskPercentage)
        {
            string lastColumnName = GetExcelColumnName(this.CurrentDataTable.Columns.Count);
            Range dataTableRange = worksheet.get_Range("A3:" + lastColumnName + (rows.Count() + 3));
            float top = (float)(double)dataTableRange.Top + (float)(double)dataTableRange.Height + 100;

            ChartObjects charts = worksheet.ChartObjects();
            ChartObject chartObject = charts.Add(100, top, 600, 400);
            Chart chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlLineMarkers;
            chart.ChartStyle = 232;
            chart.ChartColor = 10;

            SeriesCollection seriesCollection = chart.SeriesCollection(Type.Missing);
            int rowCount = 3 + rows.Count();
            Range dateRange = worksheet.get_Range("C4:C" + rowCount);

            //Add element series
            int colCount = this.CurrentDataTable.Columns.Count;
            double subTaskPercentage = (taskPercentage - 2) / (colCount - 5);
            for (int i = 6; i <= colCount; i++)
            {
                string columnName = GetExcelColumnName(i);
                Range seriesRange = worksheet.get_Range(columnName + "4:" + columnName + rowCount);
                Series series = seriesCollection.Add(seriesRange, XlRowCol.xlColumns, Type.Missing,
                                Type.Missing, Type.Missing);
                series.Values = seriesRange;
                series.Name = this.CurrentDataTable.Columns[i - 1].ToString();
                series.XValues = dateRange;
                ReportDownloadProgress(subTaskPercentage);
            }

            //Add LowValue Series
            Range lowValueRange = worksheet.get_Range("D4:D" + rowCount);
            Series lowValueSeries = seriesCollection.Add(lowValueRange, XlRowCol.xlColumns,
                                    Type.Missing, Type.Missing, Type.Missing);
            lowValueSeries.Name = "Low";
            lowValueSeries.XValues = dateRange;
            ReportDownloadProgress(1);

            //Add HighValue Series
            Range highValueRange = worksheet.get_Range("E4:E" + rowCount);
            Series highValueSeries = seriesCollection.Add(highValueRange, XlRowCol.xlColumns,
                                    Type.Missing, Type.Missing, Type.Missing);
            highValueSeries.Name = "High";
            highValueSeries.XValues = dateRange;
            ReportDownloadProgress(1);
        }

        private string GetExcelColumnName(int columnNumber)
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
    }
}
