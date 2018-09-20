using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISpikeSolutionOptionsView
    {
        void SetController(SpikeSolutionOptionsController controller);
        void AddItemCodeToListBox(string itemCode);
        void SetDialogResult(DialogResult dialogResult);

        string SelectedItemCode { get; set; }
    }
}
