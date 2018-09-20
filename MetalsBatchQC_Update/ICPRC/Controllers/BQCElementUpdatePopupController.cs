using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.Controllers
{
    public class BQCElementUpdatePopupController
    {
        IBQCElementUpdatePopup view;
        BQCElementResult element;

        public BQCElementUpdatePopupController(IBQCElementUpdatePopup view, BQCElementResult element)
        {
            this.view = view;
            this.view.SetController(this);
            this.element = element;
        }

        public void LoadView()
        {
            this.view.ElementSymbol = element.ElementSymbol;
            this.view.MBResult = element.MBResult.ToString();
            this.view.LCSResult = element.LCSResult.ToString();
            this.view.LCSDResult = element.LCSDResult.ToString();
        }

        public void SubmitButtonClicked()
        {
            double MBNumber;
            double LCSNumber;
            double LCSDNumber;

            if(Double.TryParse(this.view.MBResult, out MBNumber) &&
               Double.TryParse(this.view.LCSResult, out LCSNumber) &&
               Double.TryParse(this.view.LCSDResult, out LCSDNumber))
            {
                this.element.MBResult = MBNumber;
                this.element.LCSResult = LCSNumber;
                this.element.LCSDResult = LCSDNumber;
                this.element.SetLCSRecovery();
                this.element.SetLCSDRecovery();
                this.element.SetRPDRecovery();

                view.SetDialogResult(DialogResult.OK);
            }
            else
            {
                MessageBox.Show("Invalid number format.");
                view.SetDialogResult(DialogResult.Retry);
            }
        }
    }
}
