using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Interfaces.Admin
{
    public interface IReasonView
    {
        void SetController(ReasonViewController controller);
        void SetDialogResult(DialogResult dialogResult);

        string Reason { get; set; }
    }
}
