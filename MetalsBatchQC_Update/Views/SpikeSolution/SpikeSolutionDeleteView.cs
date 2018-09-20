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
    public partial class SpikeSolutionDeleteView : Form, ISpikeSolutionDeleteView
    {
        private SpikeSolutionDeleteController _controller;

        public SpikeSolutionDeleteView()
        {
            InitializeComponent();
        }

        public void SetController(SpikeSolutionDeleteController controller)
        {
            _controller = controller;
        }

        public string ID
        {
            get { return this.IDTextBox.Text; }
            set { this.IDTextBox.Text = value; }
        }

        public string SpikeSolutionName
        {
            get { return this.nameTextBox.Text; }
            set { this.nameTextBox.Text = value; }
        }

        public string Reason
        {
            get { return this.reasonTextBox.Text; }
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            _controller.SubmitButtonClicked();
        }

        private void SpikeSolutionDeleteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
