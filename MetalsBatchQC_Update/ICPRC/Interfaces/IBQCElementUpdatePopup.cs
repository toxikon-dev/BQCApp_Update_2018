using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IBQCElementUpdatePopup
    {
        void SetController(BQCElementUpdatePopupController controller);
        void SetDialogResult(DialogResult dialogResult);

        string ElementSymbol { get; set; }
        string MBResult { get; set; }
        string LCSResult { get; set; }
        string LCSDResult { get; set; }
    }
}
