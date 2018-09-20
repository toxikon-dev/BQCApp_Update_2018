using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Interfaces;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class DilutedSampleView : Form, IDilutedSampleView
    {
        DilutedSampleViewController controller;
        private int selectedSampleIndex;

        public DilutedSampleView()
        {
            InitializeComponent();
        }

        public void SetController(DilutedSampleViewController controller)
        {
            this.controller = controller;
        }

        public double DilutionFactor
        {
            get { return Convert.ToDouble(this.DilutionFactorTextBox.Text); }
            set { this.DilutionFactorTextBox.Text = value.ToString(); }
        }

        public void AddSampleNameToList(string sampleName)
        {
            this.SampleListView.Items.Add(sampleName);
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public int SelectedSampleIndex 
        {
            get { return this.selectedSampleIndex; }
            set { this.selectedSampleIndex = value; }
        }

        private void BrowseFileButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.SampleListView.Items.Clear();
                controller.BrowseFileButtonClicked(openFileDialog.FileName);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void SampleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.SampleListView.SelectedIndices.Count > 0)
            {
                this.selectedSampleIndex = this.SampleListView.SelectedIndices[0];
                this.controller.DilutedSampleList_SelectedIndexChanged(this.selectedSampleIndex);
            }
        }
    }
}
