using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISpikeSolutionView
    {
        void SetController(SpikeSolutionController controller);

        void AddSpikeSolutionToListView(SpikeSolution item);
        void RemoveSelectedItemFromListView(int selectedIndex);

        void AddChemicalToComboBox(Chemical item);
        void SetComboBoxSelectedIndex(int selectedIndex);

        void ShowDeleteButton(bool value);

        Control ParentControl { get; }
    }
}
