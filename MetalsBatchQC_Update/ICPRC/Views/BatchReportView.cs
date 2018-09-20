using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.ICPRC.Controllers;
using System.Collections;

namespace Toxikon.BatchQC.Views.ICPRC
{
    public partial class BatchReportView : UserControl, IBatchReportView
    {
        BatchReportViewController controller;

        public BatchReportView()
        {
            InitializeComponent();
        }

        public Control ParentControl
        {
            get { return this.Parent; }
        }

        public void SetController(BatchReportViewController controller)
        {
            this.controller = controller;
        }

        public void AddBQCElementResultToView(BQCElementResult result)
        {
            ListViewItem item = this.ResultListView.Items.Add(result.ElementSymbol);
            item.SubItems.Add(result.TrueValue.ToString());
            item.SubItems.Add(result.MBResult.ToString());
            item.SubItems.Add(result.LCSResult.ToString());
            item.SubItems.Add(result.LCSDResult.ToString());
            item.SubItems.Add(result.LCSRecovery.ToString());
            item.SubItems.Add(result.LCSDRecovery.ToString());
            item.SubItems.Add(result.RPD.ToString());
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            this.controller.DownloadReportButtonClicked();
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
            for (int i = 0; i < this.ResultListView.Columns.Count; i++ )
            {
                dataTable.Columns.Add(this.ResultListView.Columns[i].Text);
            }
        }

        private void AddDataTableRows(DataTable dataTable)
        {
            for(int i = 0; i < this.ResultListView.Items.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int j = 0; j < this.ResultListView.Columns.Count; j++)
                {
                    dataRow[j] = this.ResultListView.Items[i].SubItems[j].Text;
                }
                dataTable.Rows.Add(dataRow);
            }
        }

        private void ResultListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.ResultListView.SelectedIndices.Count > 0)
            {
                this.controller.ShowBQCElementUpdatePopup(this.ResultListView.SelectedIndices[0]);
            }
        }

        public void UpdateElementResult(int selectedIndex, BQCElementResult result)
        {
            ListViewItem item = this.ResultListView.Items[selectedIndex];
            System.Windows.Forms.ListViewItem.ListViewSubItemCollection subItems = item.SubItems;
            subItems[2].Text = result.MBResult.ToString();
            subItems[3].Text = result.LCSResult.ToString();
            subItems[4].Text = result.LCSDResult.ToString();
            subItems[5].Text = result.LCSRecovery.ToString();
            subItems[6].Text = result.LCSDRecovery.ToString();
            subItems[7].Text = result.RPD.ToString();
        }

        private void SubmitLCSResultsButton_Click(object sender, EventArgs e)
        {
            this.controller.Submit_LCSResult_ForControlChartReport();
        }
    }
}
