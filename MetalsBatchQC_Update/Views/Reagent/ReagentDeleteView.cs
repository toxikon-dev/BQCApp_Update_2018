using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class ReagentDeleteView : Form, IReagentDeleteView
    {
        private ReagentDeleteController _controller;

        public ReagentDeleteView()
        {
            InitializeComponent();
        }

        public void SetController(ReagentDeleteController controller)
        {
            _controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string ReagentID
        {
            get { return this.reagentIDTextBox.Text; }
            set { this.reagentIDTextBox.Text = value; }
        }

        public string ReagentName
        {
            get { return this.reagentNameTextBox.Text; }
            set { this.reagentNameTextBox.Text = value; }
        }

        public string Amount
        {
            get { return this.amountTextBox.Text; }
            set { this.amountTextBox.Text = value; }
        }

        public string Reason
        {
            get { return this.reasonTextBox.Text; }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            _controller.SubmitButtonClicked();
        }

        private void ReagentDeleteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
