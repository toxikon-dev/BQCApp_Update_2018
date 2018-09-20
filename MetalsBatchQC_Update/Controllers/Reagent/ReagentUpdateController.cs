using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class ReagentUpdateController
    {
        IReagentUpdateView _view;
        Reagent _selectedReagent;

        public ReagentUpdateController(IReagentUpdateView view, Reagent selectedReagent)
        {
            _view = view;
            _selectedReagent = selectedReagent;

            _view.SetController(this);
        }

        public double NewAmountValue
        {
            get
            {
                return this._selectedReagent.Amount;
            }
        }

        public void LoadView()
        {
            _view.ReagentID = _selectedReagent.ItemCode;
            _view.ReagentName = _selectedReagent.ProductName;
            _view.Amount = _selectedReagent.Amount.ToString();
        }

        public void UpdateReagentAmount()
        {
            if(IsValidAmountValue())
            {
                _selectedReagent.Amount = Convert.ToDouble(_view.Amount);
            }
            else
            {
                ShowInvalidValueMessageBox("Invalid amount value. Please try again.");
            }
        }

        private bool IsValidAmountValue()
        {
            bool result = true;
            double number;
            if (!Double.TryParse(_view.Amount, out number))
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
