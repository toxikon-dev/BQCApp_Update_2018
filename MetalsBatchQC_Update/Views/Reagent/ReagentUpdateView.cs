using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
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
    public partial class ReagentUpdateView : Form, IReagentUpdateView
    {
        private ReagentUpdateController _controller;

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

        public ReagentUpdateView()
        {
            InitializeComponent();
        }

        public void SetController(ReagentUpdateController controller)
        {
            _controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateReagentAmount();
        }

        private void ReagentUpdateView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
