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
    public partial class SpikeSolutionOptionsView : Form, ISpikeSolutionOptionsView
    {
        private SpikeSolutionOptionsController _controller;
        public string SelectedItemCode { get; set; }
        public Control ParentControl;

        public SpikeSolutionOptionsView()
        {
            InitializeComponent();
            ParentControl = this.Parent;
        }

        public void SetController(SpikeSolutionOptionsController controller)
        {
            _controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void AddItemCodeToListBox(string itemCode)
        {
            this.ItemCodeListBox.Items.Add(itemCode);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _controller.AddButtonClicked();
        }

        private void SpikeSolutionOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        private void ItemCodeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedItemCode = this.ItemCodeListBox.SelectedItem.ToString();
            this._controller.SelectedIndexChanged();
        }

    }
}
