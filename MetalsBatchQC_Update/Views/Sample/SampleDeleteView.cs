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

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class SampleDeleteView : Form, ISampleDeleteView
    {
        SampleDeleteViewController controller;

        public SampleDeleteView()
        {
            InitializeComponent();
        }

        public string SampleCode
        {
            get { return this.SampleCodeLabel.Text; }
            set { this.SampleCodeLabel.Text = value; }
        }

        public string Reason
        {
            get { return this.ReasonTextBox.Text; }
        }

        public void SetController(SampleDeleteViewController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void SampleDeleteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
