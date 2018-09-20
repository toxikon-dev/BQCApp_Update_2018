using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class SpikeSolutionOptionsController
    {
        ISpikeSolutionOptionsView _view;
        IList options;
        string selectedItemCode;

        public SpikeSolutionOptionsController(ISpikeSolutionOptionsView view, IList optionList)
        {
            _view = view;
            _view.SelectedItemCode = "";
            this.options = optionList;

            _view.SetController(this);
        }

        public string ItemCode
        {
            get
            {
                return this.selectedItemCode;
            }
        }

        public void LoadView()
        {
            foreach(string itemCode in options)
            {
                _view.AddItemCodeToListBox(itemCode);
            }
        }

        public void SelectedIndexChanged()
        {
            this.selectedItemCode = _view.SelectedItemCode;
        }

        public void AddButtonClicked()
        {
            if(IsValidSelectedID())
            {
                _view.SetDialogResult(DialogResult.OK);
            }
            else
            {
                ShowInvalidValueMessageBox("Please select one ID.");
            }
        }

        private bool IsValidSelectedID()
        {
            bool result = true;
            if(_view.SelectedItemCode == "")
            {
                result = false;
            }
            return result;
        }

        private void ShowInvalidValueMessageBox(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                _view.SetDialogResult(DialogResult.Retry);
            }
        }
    }
}
