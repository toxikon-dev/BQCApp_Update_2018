using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class SolidDataGridView : DataGridView
    {
        private SolidSample sample;

        public SolidDataGridView()
        {
            this.ReadOnly = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeight = 100;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = Color.White;
            this.MouseDoubleClick += SolidDataGridView_MouseDoubleClick;
        }

        public void CreateGridForSample(SolidSample sample)
        {
            this.sample = sample;
            SetDataGridViewColumns();
            SetDataGridViewRows();
        }

        public void SetDataGridViewColumns()
        {
            if (this.Columns.Count == 0)
            {
                AddNewDataGridColumn("Element");
                AddNewDataGridColumn("Weight Digested (" + sample.WeightDigestedUnit + ")");
                AddNewDataGridColumn("Final Volume (" + sample.FinalVolumeUnit + ")");
                AddNewDataGridColumn("Reporting Limit (" + sample.ReportingLimitUnit + ")");
                AddNewDataGridColumn("Result (" + sample.RawFileResultUnit + ")");
                AddNewDataGridColumn("Blank Correction");
                AddNewDataGridColumn("Analytical Dilution Factor");
                AddNewDataGridColumn("Corrected Result (" + sample.CorrectedResultUnit + ")");
                AddNewDataGridColumn("Result (" + sample.CalculatedResultUnit + ")");
                AddNewDataGridColumn("Reporting Limit (" + sample.CalculatedReportingLimitUnit + ")");
            }
        }

        private void AddNewDataGridColumn(string headerText)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = headerText;
            this.Columns.Add(column);
        }

        private void SetDataGridViewRows()
        {
            foreach (SolidResult result in sample.SolidResultList)
            {
                AddRow(result);
            }
        }

        public void AddRow(SolidResult result)
        {
            this.Rows.Add(
                new object[] { result.ElementSymbol, 
                    result.WeightDigested.ToString(),
                    result.FinalVolume.ToString(), 
                    result.ReportingLimit.ToString(),
                    result.RawFileResult.ToString(), 
                    result.BlankCorrection.ToString(),
                    result.DilutionFactor.ToString(), 
                    result.CorrectedResult.ToString(),
                    result.CalculatedResult.ToString(), 
                    result.CalculatedReportingLimit.ToString()});
        }

        public void UpdateRows()
        {
            this.Rows.Clear();
            SetDataGridViewRows();
        }

        public DataTable GetCurrentDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Rows.Clear();
            AddDataTableColumns(dataTable);
            AddDataTableRows(dataTable);
            return dataTable;
        }

        private void AddDataTableColumns(DataTable dataTable)
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }
        }

        private void AddDataTableRows(DataTable dataTable)
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }
        }

        private void SolidDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = this.SelectedCells[0];
                if (SolidSampleResultViewController.UpdateSelectedElementDelegate != null)
                {
                    this.Invoke(SolidSampleResultViewController.UpdateSelectedElementDelegate,
                        new object[] { cell.RowIndex });
                }
            }
        }
    }
}
