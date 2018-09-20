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
    public class LiquidDataGridView : DataGridView
    {
        private LiquidSample sample;

        public LiquidDataGridView()
        {
            this.ReadOnly = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeight = 100;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = Color.White;
            this.MouseDoubleClick += LiquidDataGridView_MouseDoubleClick;
        }

        public void CreateGridForSample(LiquidSample sample)
        {
            this.sample = sample;
            SetDataGridColumns();
            SetDataGridViewRows();
        }

        public void SetDataGridColumns()
        {
            AddNewDataGridColumn("Element");
            AddNewDataGridColumn("Volume Digested (" + sample.VolumeDigestedUnit + ")");
            AddNewDataGridColumn("Final Volume (" + sample.FinalVolumeUnit + ")");
            AddNewDataGridColumn("Reporting Limit (" + sample.ReportingLimitUnit + ")");
            AddNewDataGridColumn("Result (" + sample.ResultUnit + ")");
            AddNewDataGridColumn("Blank Correction");
            AddNewDataGridColumn("Analytical Dilution Factor");
            AddNewDataGridColumn("Corrected Result (" + sample.CorrectedResultUnit + ")");
            if (!sample.IsControlSample)
            {
                AddNewDataGridColumn("Control Corrected Result (" + sample.ControlCorrectedResultUnit + ")");
            }
            AddNewDataGridColumn("Corrected RL (" + sample.CorrectedRLUnit + ")");
            this.AutoResizeColumnHeadersHeight();
        }

        private void AddNewDataGridColumn(string headerText)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = headerText;
            this.Columns.Add(column);
        }

        private void SetDataGridViewRows()
        {
            foreach(LiquidResult result in sample.LiquidResultList)
            {
                AddRow(result);
            }
        }

        public void AddRow(LiquidResult result)
        {
            if (sample.IsControlSample)
            {
                AddControlSampleRowData(result);
            }
            else
            {
                AddSampleRowData(result);
            }
        }

        private void AddControlSampleRowData(LiquidResult result)
        {
            string[] controlRowData = new string[]{
                result.ElementSymbol,
                result.VolumeDigested.ToString("#.0000"),
                result.FinalVolume.ToString("#.000"),
                result.ReportingLimit.ToString("#.000"),
                result.Result.ToString("#.000"), 
                result.BlankCorrection.ToString("#.000"), 
                result.DilutionFactor.ToString("#.000"), 
                result.CorrectedResult.ToString("#.000"),
                result.CorrectedRL.ToString("#.000")};

            this.Rows.Add(controlRowData);
        }

        private void AddSampleRowData(LiquidResult result)
        {
            string[] sampleRowData = new string[]{
                result.ElementSymbol,
                result.VolumeDigested.ToString("#.0000"),
                result.FinalVolume.ToString("#.000"),
                result.ReportingLimit.ToString("#.000"),
                result.Result.ToString("#.000"), 
                result.BlankCorrection.ToString("#.000"), 
                result.DilutionFactor.ToString("#.000"), 
                result.CorrectedResult.ToString("#.000"),
                result.ControlCorrectedResult.ToString("#.000"),
                result.CorrectedRL.ToString("#.000")};

            this.Rows.Add(sampleRowData);
        }

        private void LiquidDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = this.SelectedCells[0];
                if(LiquidSampleResultViewController.UpdateSelectedElementDelegate != null)
                {
                    this.Invoke(LiquidSampleResultViewController.UpdateSelectedElementDelegate,
                        new object[] { cell.RowIndex });
                }
            }
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
    }
}
