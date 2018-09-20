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
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class LiquidSampleResultsView : UserControl, ILiquidSampleResultView
    {
        LiquidSampleResultViewController controller;

        public LiquidSampleResultsView()
        {
            InitializeComponent();
        }

        public void SetController(LiquidSampleResultViewController controller)
        {
            this.controller = controller;
        }

        public Control ParentControl
        {
            get { return this.Parent; }
        }

        public void AddSampleNameToListBox(string sampleName)
        {
            this.SampleNameListBox.Items.Add(sampleName);
        }

        public void ClearSampleNameListBox()
        {
            this.SampleNameListBox.Items.Clear();
        }

        public void AddDataGridViewToView(LiquidDataGridView dataGrid)
        {
            this.DataGridViewPanel.Controls.Clear();
            dataGrid.Dock = DockStyle.Fill;
            this.DataGridViewPanel.Controls.Add(dataGrid);
        }

        private void SampleNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.SampleNameListBoxSelectedIndexChanged(this.SampleNameListBox.SelectedIndex);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            this.controller.DownloadReportButtonClicked();
        }
    }
}
