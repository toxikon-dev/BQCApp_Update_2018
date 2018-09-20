using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;

namespace Toxikon.BatchQC.Controllers.Admin
{
    public class ReasonViewController
    {
        IReasonView view;

        public ReasonViewController(IReasonView view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public string Reason
        {
            get { return this.view.Reason; }
        }

        public void SubmitButtonClicked()
        {
            if(view.Reason.Trim() == "")
            {
                ShowInvalidValueMessageBox("Reason is required.");
            }
            else
            {
                view.SetDialogResult(DialogResult.OK);
            }
        }

        private void ShowInvalidValueMessageBox(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                view.SetDialogResult(DialogResult.Retry);
            }
        }
    }
}
