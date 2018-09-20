using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Interfaces;

namespace Toxikon.BatchQC.Views.Forms
{
    public partial class ReagentOptionsView : Form, IReagentOptionsView
    {
        private ReagentOptionsController _controller;
        public string SelectedItemCode { get; set; }
        public string AmountValue 
        {
            get { return this.amountTextBox.Text; }
            set { this.amountTextBox.Text = value; }
        }

        public ReagentOptionsView()
        {
            InitializeComponent();
        }

        public void SetController(ReagentOptionsController controller)
        {
            _controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void AddItemCodeToListBox(string itemCode)
        {
            this.reagentListBox.Items.Add(itemCode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controller.AddButtonClicked();
        }

        private void reagentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemCode = this.reagentListBox.SelectedItem.ToString();
            _controller.ReagentListBoxSelectedIndexChanged();
        }

        private void ReagentOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
