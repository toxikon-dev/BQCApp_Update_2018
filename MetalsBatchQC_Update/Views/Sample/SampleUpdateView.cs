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
    public partial class SampleUpdateView : Form, ISampleUpdateView
    {
        SampleUpdateController controller;

        public SampleUpdateView()
        {
            InitializeComponent();
        }

        public void SetController(SampleUpdateController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string SampleCode 
        {
            get { return this.SampleCodeLabel.Text; }
            set { this.SampleCodeLabel.Text = value; }
        }
        public string SampleAmount 
        {
            get { return this.SampleAmountTextBox.Text; }
            set { this.SampleAmountTextBox.Text = value; } 
        }
        public string SampleUnit 
        {
            get { return this.InitialUnitLabel.Text; }
            set { this.InitialUnitLabel.Text = value; }
        }

        public string InitialDigestionAmount
        {
            get { return this.InitialDigestionAmountTextBox.Text; }
            set { this.InitialDigestionAmountTextBox.Text = value; }
        }

        public string InitialDigestionUnit
        {
            get { return this.BeforeDigestionUnitLabel.Text; }
            set { this.BeforeDigestionUnitLabel.Text = value; }
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
        public string Comment 
        {
            get { return this.CommentTextBox.Text; }
            set { this.CommentTextBox.Text = value; }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }
    }
}
