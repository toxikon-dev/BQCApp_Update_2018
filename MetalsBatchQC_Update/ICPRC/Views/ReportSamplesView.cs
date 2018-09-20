using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class ReportSamplesView : UserControl, IReportSamplesView
    {
        ReportSamplesViewController controller;

        public ReportSamplesView()
        {
            InitializeComponent();
        }

        public void SetController(ReportSamplesViewController controller)
        {
            this.controller = controller;
        }

        public void AddBatchSampleToView(BatchSample batchSample)
        {
            this.MainDataGridView.Rows.Add(new object[] 
                { batchSample.SampleCode,
                  batchSample.InitialAmount + batchSample.InitialUnit,
                  batchSample.FinalAmount + batchSample.FinalUnit,
                  batchSample.SampleDescription, "N/A"});
        }

        public void ClearBatchSampleList()
        {
            this.MainDataGridView.Rows.Clear();
        }

        public void SetRawFileSampleComboBox(IList items)
        {
            int lastColIndex = this.MainDataGridView.Columns.Count - 1;
            DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)this.MainDataGridView.Columns[lastColIndex];
            cb.Items.Clear();
            foreach (string item in items)
            {
                cb.Items.Add(item);
            }
        }

        private void MainDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {           
            if (e.Control != null && e.Control is ComboBox)
            {
                var cb = e.Control as ComboBox;
                cb.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            int dataGridSelectedRowIndex = this.MainDataGridView.SelectedRows[0].Index;
            int cbSelectedIndex = cb.SelectedIndex;
            this.controller.UpdateSampleResultValuesFromBatchSample(dataGridSelectedRowIndex, cbSelectedIndex);
        }
    }
}
