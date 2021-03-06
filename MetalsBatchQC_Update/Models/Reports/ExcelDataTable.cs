﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Reports
{
    public class ExcelDataTable
    {
        private DataTable dataTable;
        public int StartRowIndex { get; set; }
        public string TopLeft { get; set; }
        public string BottomRight { get; private set; } 
        public string TableName {get; set;}
        public string TableStyleName { get; set; }

        public ExcelDataTable()
        {
            this.dataTable = new DataTable();
            this.TopLeft = "A1";
            this.StartRowIndex = 1;
            this.SetBottomRight();
            this.TableName = "ReportDataTable";
            this.TableStyleName = "TableStyleLight21";
        }

        public void SetDataTable(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }

        public void SetBottomRight()
        {
            string lastColumnName = ExcelTemplate.GetExcelColumnName(dataTable.Columns.Count);
            int lastRowNumber = this.StartRowIndex + (dataTable.Rows.Count - 1);
            this.BottomRight = lastColumnName + lastRowNumber;
        }

        public int ColumnCount
        {
            get { return dataTable.Columns.Count; }
        }

        public int RowCount
        {
            get { return dataTable.Rows.Count; }
        }

        public string GetColumnName(int columnIndex)
        {
            string result = "";
            if(!IsIndexOutOfRange(columnIndex, dataTable.Columns))
            {
                result = dataTable.Columns[columnIndex].ColumnName;
            }
            return result;
        }

        public string GetCellValueAt(int rowIndex, int columnIndex)
        {
            string result = "";
            if(!IsIndexOutOfRange(rowIndex, dataTable.Rows) && 
               !IsIndexOutOfRange(columnIndex, dataTable.Columns))
            {
                result = dataTable.Rows[rowIndex][columnIndex].ToString();
            }
            return result;
        }

        public DataRow[] SelectDataRowByQuery(string query)
        {
            DataRow[] dataSet = this.dataTable.Select(query);
            return dataSet;
        }

        private bool IsIndexOutOfRange(int index, InternalDataCollectionBase collection)
        {
            bool result = true ;
            if(index >= 0 && index < collection.Count)
            {
                result = false;
            }
            return result;
        }
    }
}
