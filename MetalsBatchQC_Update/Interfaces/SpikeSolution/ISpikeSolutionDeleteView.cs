using Toxikon.BatchQC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISpikeSolutionDeleteView
    {
        void SetController(SpikeSolutionDeleteController controller);
        void SetDialogResult(DialogResult dialogResult);

        string ID { get; set; }
        string SpikeSolutionName { get; set; }
        string Reason { get; }
    }
}
