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
using Toxikon.BatchQC.ICPRC.Interfaces;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class BQCElementUpdatePopup : Form, IBQCElementUpdatePopup
    {
        BQCElementUpdatePopupController controller;

        public string ElementSymbol
        {
            get { return this.ElementLabel.Text; }
            set { this.ElementLabel.Text = value; }
        }

        public string MBResult 
        {
            get { return this.MBTextBox.Text; }
            set { this.MBTextBox.Text = value; }
        }

        public string LCSResult
        {
            get { return this.LCSTextBox.Text; }
            set { this.LCSTextBox.Text = value; }
        }

        public string LCSDResult
        {
            get { return this.LCSDTextBox.Text; }
            set { this.LCSDTextBox.Text = value; }
        }

        public BQCElementUpdatePopup()
        {
            InitializeComponent();
        }

        public void SetController(BQCElementUpdatePopupController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void BQCElementUpdatePopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

    }
}
