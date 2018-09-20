using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Interfaces;

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class SampleGroupAddView : Form, ISampleGroupAddView
    {
        SampleGroupAddController controller;
        public Control ParentControl;
        public string GroupCode 
        {
            get { return this.groupCodeLabel.Text; }
            set { this.groupCodeLabel.Text = value; } 
        }
        public string ProjectNumber 
        {
            get { return this.projectNumberComboBox.SelectedItem.ToString(); }
        }

        public string SampleAmount 
        {
            get { return this.SampleAmountTextBox.Text; }
            set { this.SampleAmountTextBox.Text = value; }
        }
        public string SampleUnit
        {
            get { return this.SampleUnitLabel.Text; }
            set { this.SampleUnitLabel.Text = value; }
        }

        public string InitialDigestionAmount
        {
            get { return this.InitialDigestionAmountTextBox.Text; }
            set { this.InitialDigestionAmountTextBox.Text = value; }
        }

        public string InitialDigestionUnit
        {
            get { return this.InitialDigestionUnitLabel.Text; }
            set { this.InitialDigestionUnitLabel.Text = value; }
        }

        public string FinalAmount 
        {
            get { return this.FinalAmountTextBox.Text; }
            set { this.FinalAmountTextBox.Text = value; }
        }
        public string FinalUnit
        {
            get { return this.FinalUnitLabel.Text; }
            set { this.FinalUnitLabel.Text = value; }
        }

        public string Description 
        {
            get { return this.DescriptionTextBox.Text; }
            set { this.DescriptionTextBox.Text = value; }
        }
        public string NumberOfSamples 
        {
            get { return this.SampleQuantityTextBox.Text; }
            set { this.SampleQuantityTextBox.Text = value; }
        }

        public SampleGroupAddView()
        {
            InitializeComponent();
            this.ParentControl = this.Parent;
        }

        public void SetController(SampleGroupAddController controller)
        {
            this.controller = controller;
        }

        public void AddItemToComboBox(string item)
        {
            this.projectNumberComboBox.Items.Add(item);
        }

        public void SetComboBoxSelectedIndex(int index)
        {
            this.projectNumberComboBox.SelectedIndex = index;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            controller.AddButtonClicked();
        }

        private void SampleGroupAddView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
