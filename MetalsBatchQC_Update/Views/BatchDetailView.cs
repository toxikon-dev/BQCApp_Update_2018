using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class BatchDetailView : UserControl, IBatchDetailView
    {
        private BatchDetailController _controller;
        private string selectedSampleType;

        public BatchDetailView()
        {
            InitializeComponent();
            this.selectedSampleType = "";
        }

        public void SetController(BatchDetailController controller)
        {
            this._controller = controller;
        }

        public string BatchQCNumber
        {
            get { return this.tbBQC.Text; }
            set { this.tbBQC.Text = value; }
        }

        public string PrepDate
        {
            get { return this.tbPrepDate.Text; }
            set { this.tbPrepDate.Text = value; }
        }

        public string PreparedBy
        {
            get { return this.tbPreparedBy.Text; }
            set { this.tbPreparedBy.Text = value; }
        }

        public string SampleType
        {
            get { return this.selectedSampleType; }
            set { this.selectedSampleType = value; this.SetSelectedSampleTypeRadioButton(); }
        }

        public string InstrumentID
        {
            get { return this.InstrumentIDTextBox.Text; }
            set { this.InstrumentIDTextBox.Text = value; }
        }

        public string BalanceID
        {
            get { return this.tbBalanceID.Text; }
            set { this.tbBalanceID.Text = value; }
        }

        public string Method
        {
            get { return this.MethodTextBox.Text; }
            set { this.MethodTextBox.Text = value; }
        }

        public string MethodID
        {
            get { return this.tbMethodNumber.Text; }
            set { this.tbMethodNumber.Text = value; }
        }

        public string MethodTemp
        {
            get { return this.tbMethodTemp.Text; }
            set { this.tbMethodTemp.Text = value; }
        }

        public string Analyte
        {
            get { return this.tbAnalyte.Text; }
            set { this.tbAnalyte.Text = value; }
        }

        public string PrepType
        {
            get { return this.tbPrepType.Text; }
            set { this.tbPrepType.Text = value; }
        }

        public string PurifiedWater
        {
            get { return this.tbPurifiedWater.Text; }
            set { this.tbPurifiedWater.Text = value; }
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                e.Handled = true;
                TextBox textBox = (TextBox)sender;
                textBox.SelectionLength = 0;
            }
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                e.Handled = true;
                ComboBox comboBox = (ComboBox)sender;
                comboBox.SelectionLength = 0;
            }
        }

        private void SetSelectedSampleTypeRadioButton()
        {
            if(this.selectedSampleType == SampleTypes.LIQUID)
            {
                this.LiquidRadioButton.Checked = true;
            }
            else if(this.selectedSampleType == SampleTypes.SOLID)
            {
                this.SolidRadioButton.Checked = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this._controller.SaveButtonClicked();
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            this._controller.CompleteButtonClicked();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Checked)
            {
                this.selectedSampleType = rb.Text;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            this._controller.PrintButtonClicked();
        }
    }
}
