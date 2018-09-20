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
    public interface IReagentsView
    {
        void SetController(ReagentsController controller);

        void AddReagentToListView(Reagent reagent);
        void UpdateItemAmountFromListViewAt(int selectedIndex, double amount);
        void RemoveItemFromListViewAt(int selectedIndex);

        void AddChemicalToComboBox(Chemical item);
        void SetComboBoxSelectedIndex(int selectedIndex);

        void ShowDeleteButton(bool value);

        Control ParentControl { get; }
    }
}
