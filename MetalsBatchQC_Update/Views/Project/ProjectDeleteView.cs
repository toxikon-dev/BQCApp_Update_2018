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
    public partial class ProjectDeleteView : Form, IProjectDeleteView
    {
        ProjectDeleteController controller;
        public string ProjectNumber
        {
            get { return this.ProjectNumberTextBox.Text; }
            set { this.ProjectNumberTextBox.Text = value; }
        }

        public string SponsorName
        {
            get { return this.SponsorNameTextBox.Text; }
            set { this.SponsorNameTextBox.Text = value; }
        }

        public string Reason
        {
            get { return this.ReasonTextBox.Text; }
        }

        public ProjectDeleteView()
        {
            InitializeComponent();
        }

        public void SetController(ProjectDeleteController controller)
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

        private void ProjectDeleteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
