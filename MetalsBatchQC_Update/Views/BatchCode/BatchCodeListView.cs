using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using System.Diagnostics;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class BatchCodeListView : UserControl, IBatchCodeListView
    {
        BatchCodeListController controller;

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public BatchCodeListView()
        {
            InitializeComponent();
        }

        public void SetController(BatchCodeListController controller)
        {
            this.controller = controller;
        }

        public void AddBatchCodeToListView(BatchCode batchCode)
        {
            ListViewItem item = this.BQCListView.Items.Add(batchCode.FullCode);
            item.SubItems.Add(batchCode.MethodCode);
            item.SubItems.Add(batchCode.SequenceNumber.ToString());
            item.SubItems.Add(batchCode.UpdatedDate);
            item.SubItems.Add(batchCode.UpdatedBy);
        }

        public void ClearListView()
        {
            this.BQCListView.Items.Clear();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenButtonClicked();
        }

        private void BQCListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.BQCListView.SelectedIndices.Count > 0)
            {
                this.controller.BatchCodeListViewSelectedIndexChanged(this.BQCListView.SelectedIndices[0]);
            }
        }

        private void AddNewBatchButton_Click(object sender, EventArgs e)
        {
            this.controller.AddNewBatchButtonClicked();
        }

        private void BQCListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.BQCListView.SelectedIndices.Count > 0)
            {
                this.controller.BatchCodeListViewSelectedIndexChanged(this.BQCListView.SelectedIndices[0]);
                this.controller.OpenButtonClicked();
            }
        }
    }
}
