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
    public partial class ReportHeaderListView : UserControl, IReportHeaderListView
    {
        ReportHeaderListViewController controller;
        public ReportHeaderListView()
        {
            InitializeComponent();
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public void SetController(ReportHeaderListViewController controller)
        {
            this.controller = controller;
        }
        public void AddReportHeaderToListView(ReportHeader reportHeader)
        {
            ListViewItem item = this.BCListView.Items.Add(reportHeader.BatchCode);
            item.SubItems.Add(reportHeader.MethodCode);
            item.SubItems.Add(reportHeader.SequenceNumber.ToString());
            item.SubItems.Add(reportHeader.ProjectNumber);
            item.SubItems.Add(reportHeader.SponsorName);
            item.SubItems.Add(reportHeader.PrepDate);
            item.SubItems.Add(reportHeader.InstrumentID);
        }

        private void BCListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.BCListView.SelectedIndices.Count != 0)
            {
                this.controller.ReportHeaderListViewSelectedIndexChanged(this.BCListView.SelectedIndices[0]);
            }
        }

        private void BCListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.BCListView.SelectedIndices.Count != 0)
            {
                this.controller.ReportHeaderListViewSelectedIndexChanged(this.BCListView.SelectedIndices[0]);
                this.controller.OpenButtonClicked();
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenButtonClicked();
        }
    }
}
