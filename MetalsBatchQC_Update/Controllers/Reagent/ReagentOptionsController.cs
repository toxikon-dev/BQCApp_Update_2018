using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class ReagentOptionsController
    {
        LoginInfo loginInfo;
        IReagentOptionsView _view;
        IList options;
        string itemCode;
        double amountValue;

        public ReagentOptionsController(IReagentOptionsView view, IList items)
        {
            loginInfo = LoginInfo.GetInstance();
            _view = view;
            _view.SelectedItemCode = "";
            _view.AmountValue = "";

            this.options = items;

            _view.SetController(this);
        }

        public string ItemCode
        {
            get 
            {
                return this.itemCode;
            }
        }

        public double AmountValue
        {
            get { return this.amountValue; }
        }

        public void LoadView()
        {
            foreach(string itemCode in options)
            {
                _view.AddItemCodeToListBox(itemCode);
            }
        }

        public void ReagentListBoxSelectedIndexChanged()
        {
            this.itemCode = _view.SelectedItemCode;
        }

        public void AddButtonClicked()
        {
            if(!IsValidSelectedReagentID())
            {
                ShowInvalidValueMessageBox("Please select one reagent code.");
            }
            else if(!IsValidAmountValue())
            {
                ShowInvalidValueMessageBox("Invalid Amount. Please try again.");
            }
            else
            {
                this.amountValue = Convert.ToDouble(_view.AmountValue);
                _view.SetDialogResult(DialogResult.OK);
            }
        }

        private bool IsValidSelectedReagentID()
        {
            bool result = true;
            if(_view.SelectedItemCode == "")
            {
                result = false;
            }
            return result;
        }

        private bool IsValidAmountValue()
        {
            bool result = true;
            double number;
            if(!Double.TryParse(_view.AmountValue, out number))
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
