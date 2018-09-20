using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Admin;
using Toxikon.BatchQC.Interfaces.Admin;

namespace Toxikon.BatchQC.Views.Admin
{
    public partial class ReasonView : Form, IReasonView
    {
        ReasonViewController controller;

        public ReasonView()
        {
            InitializeComponent();
        }

        public void SetController(ReasonViewController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string Reason
        {
            get { return this.ReasonTextBox.Text; }
            set { this.ReasonTextBox.Text = value; }
        }

        private void ReasonView_FormClosing(object sender, FormClosingEventArgs e)
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
