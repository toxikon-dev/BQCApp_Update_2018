using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Reports;
using Toxikon.BatchQC.Controllers.Reports;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class BQCReportView : UserControl, IBQCReportView
    {
        BQCReportViewController controller;
        private string selectedBQCStatus;

        public BQCReportView()
        {
            InitializeComponent();
        }

        public void SetController(BQCReportViewController controller)
        {
            this.controller = controller;
        }

        public string Method 
        {
            get { return this.MethodLabel.Text; }
            set { this.MethodLabel.Text = value; }
        }
        public string Matrix 
        {
            get { return this.MatrixTextBox.Text; }
            set { this.MatrixTextBox.Text = value; } 
        }
        public string AnalyticalInstrument 
        {
            get { return this.InstrumentTextBox.Text; }
            set { this.InstrumentTextBox.Text = value; }
        }
        
        public string BQCComment 
        {
            get { return this.BQCCommentTextBox.Text; }
            set { this.BQCCommentTextBox.Text = value; }
        }
        public string ProjectNumber 
        {
            get { return this.ProjectNumberLabel.Text; }
            set { this.ProjectNumberLabel.Text = value; }
        }
        public string SampleID 
        {
            get { return this.SampleIDTextBox.Text; }
            set { this.SampleIDTextBox.Text = value; }
        }
        public string RunID 
        {
            get { return this.RunIDTextBox.Text; }
            set { this.RunIDTextBox.Text = value; }
        }
        public string Exceptions 
        {
            get { return this.ExceptionsTextBox.Text; }
            set { this.ExceptionsTextBox.Text = value; }
        }
        public string BQCStatus 
        {
            get { return this.selectedBQCStatus; }
            set { this.selectedBQCStatus = value; SetBQCStatusRadioButton(); }
        }
        public string RunComment 
        {
            get { return this.RunCommentTextBox.Text; }
            set { this.RunCommentTextBox.Text = value; }
        }
        public string ApproverTitle
        {
            get { return this.UserTitleLabel.Text; }
            set { this.UserTitleLabel.Text = value; }
        }
        public string Analyst
        {
            get { return this.AnalystLabel.Text; }
            set { this.AnalystLabel.Text = value; }
        }
        public string AnalystSignature 
        {
            get { return this.AnalystSignatureTextBox.Text; }
            set { this.AnalystSignatureTextBox.Text = value; }
        }
        public string BQCSampleTypes
        {
            get { return this.BQCSampleTypesTextBox.Text; }
            set { this.BQCSampleTypesTextBox.Text = value; }
        }

        public string QA
        {
            get { return this.QALabel.Text; }
            set { this.QALabel.Text = value; }
        }

        public string QASignature
        {
            get { return this.QASignatureTextBox.Text; }
            set { this.QASignatureTextBox.Text = value; }
        }

        public string StudyDirector
        {
            get { return this.StudyDirectorLabel.Text; }
            set { this.StudyDirectorLabel.Text = value; }
        }

        public string SDSignature
        {
            get{ return this.SDSignatureTextBox.Text; }
            set { this.SDSignatureTextBox.Text = value; }
        }

        public bool IsPrintOnly { get; set; }

        public void AddBatchNumberToListBox(string batchNumber)
        {
            this.BatchNumberListBox.Items.Add(batchNumber);
        }

        private void SetBQCStatusRadioButton()
        {
            if (this.selectedBQCStatus == "Accept")
            {
                this.AcceptRadioButton.Checked = true;
            }
            else if (this.selectedBQCStatus == "Reject")
            {
                this.RejectRadioButton.Checked = true;
            }
        }

        public void ShowAnalystView()
        {
            this.QASignatureTextBox.Enabled = false;
            this.SDSignatureTextBox.Enabled = false;
            CheckPrintOnly();
        }

        public void ShowQAView()
        {
            this.TopLeftTable.Enabled = false;
            this.AnalystSignatureTextBox.Enabled = false;
            this.SDSignatureTextBox.Enabled = false;
            CheckPrintOnly();
        }

        public void ShowStudyDirectorView()
        {
            this.TopLeftTable.Enabled = false;
            this.AnalystSignatureTextBox.Enabled = false;
            this.QASignatureTextBox.Enabled = false;
            CheckPrintOnly();
        }

        private void CheckPrintOnly()
        {
            if(IsPrintOnly)
            {
                this.SaveChangesButton.Enabled = false;
                this.ApprovedButton.Enabled = false;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                this.selectedBQCStatus = rb.Text;
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.controller.SaveChangesButtonClicked();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            this.controller.PrintButtonClicked();
        }
    }
}
