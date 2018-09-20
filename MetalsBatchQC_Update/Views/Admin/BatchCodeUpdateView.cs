using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Views.Admin
{
    public partial class BatchCodeUpdateView : UserControl, IBatchCodeUpdateView
    {
        BatchCodeUpdateViewController controller;

        public BatchCodeUpdateView()
        {
            InitializeComponent();
        }

        public void SetController(BatchCodeUpdateViewController controller)
        {
            this.controller = controller;
        }

        public void AddMethodCodeToComboBox(string methodCode)
        {
            this.MethodCodeComboBox.Items.Add(methodCode);
        }

        public string Month
        {
            get { return this.MonthTextBox.Text; }
            set { this.MonthTextBox.Text = value; }
        }
        public string Year
        {
            get { return this.YearTextBox.Text; }
            set { this.YearTextBox.Text = value; }
        }
        public string SequenceNumber
        {
            get { return this.SequenceNumberTextBox.Text; }
            set { this.SequenceNumberTextBox.Text = value; }
        }
        public string BatchCode
        {
            get { return this.BatchCodeLabel.Text; }
            set { this.BatchCodeLabel.Text = value; }
        }
        public string MethodCode
        {
            get { return this.MethodCodeComboBox.SelectedItem.ToString(); }
            set { this.MethodCodeComboBox.SelectedItem = value; }
        }
        public bool IsComplete
        {
            get { return this.CompleteTrueRadioButton.Checked; }
            set
            {
                this.CompleteTrueRadioButton.Checked = value == true ? true : false;
                this.CompleteFalseRadioButton.Checked = value == true ? false : true;
            }
        }
        public Control ParentControl
        {
            get { return this.Parent; }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }

        public void ClearView()
        {
            this.SequenceNumberTextBox.Text = "";
            this.BatchCodeLabel.Text = "Batch Code";
            this.MethodCodeComboBox.SelectedIndex = -1;
            this.CompleteTrueRadioButton.Checked = false;
            this.CompleteFalseRadioButton.Checked = false;
        }
    }
}
