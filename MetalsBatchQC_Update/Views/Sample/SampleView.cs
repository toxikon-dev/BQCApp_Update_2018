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

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class SampleView : UserControl, ISampleView
    {
        SampleController controller;
        public Control ParentControl { get; private set; }

        public SampleView()
        {
            InitializeComponent();
            this.ParentControl = this.Parent;
        }

        public void SetController(SampleController controller)
        {
            this.controller = controller;
        }

        public void AddItemToListView(Sample sample)
        {
            ListViewItem item = this.samplesListView.Items.Add(sample.GroupCode);
            item.SubItems.Add(sample.SampleCode);
            item.SubItems.Add(sample.SampleAmount + " " + sample.SampleUnit);
            item.SubItems.Add(sample.InitialDigestionAmount + " " + sample.InitialDigestionUnit);
            item.SubItems.Add(sample.FinalAmount + " " + sample.FinalUnit);
            item.SubItems.Add(sample.Description);
            item.SubItems.Add(sample.Comment);
        }

        private void AddSampleGroupButton_Click(object sender, EventArgs e)
        {
            controller.AddSampleGroupButtonClicked();
        }

        private void AddMBToolStripButton_Click(object sender, EventArgs e)
        {
            controller.G01_AddSampleButtonClicked("MB");
        }

        private void AddLCSToolStripButton_Click(object sender, EventArgs e)
        {
            controller.G01_AddSampleButtonClicked("LCS");
        }

        private void AddLCSDToolStripButton_Click(object sender, EventArgs e)
        {
            controller.G01_AddSampleButtonClicked("LCSD");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            controller.UpdateButtonClicked();
        }

        private void samplesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.samplesListView.SelectedIndices.Count != 0)
            {
                controller.SampleListViewSelectedIndexChanged(this.samplesListView.SelectedItems[0]);
            }
        }

        public void UpdateItemFromListView(Sample sample)
        {
            ListViewItem item = this.samplesListView.SelectedItems[0];
            item.SubItems[2].Text = sample.SampleAmount + " " + sample.SampleUnit;
            item.SubItems[3].Text = sample.InitialDigestionAmount + " " + sample.InitialDigestionUnit;
            item.SubItems[4].Text = sample.FinalAmount + " " + sample.FinalUnit;
            item.SubItems[5].Text = sample.Description;
            item.SubItems[6].Text = sample.Comment;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.controller.DeleteButtonClicked();
        }

        public void RemoveItemFromListViewAt(int itemIndex)
        {
            this.samplesListView.Items.RemoveAt(itemIndex);
        }
    }
}
