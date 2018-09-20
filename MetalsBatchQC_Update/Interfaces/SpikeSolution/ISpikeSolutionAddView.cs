using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISpikeSolutionAddView
    {
        void SetController(SpikeSolutionAddController controller);
        void AddItemToListView(Chemical item);
        void ClearView();
        void ClearListView();

        int SelectedItemIndex { get; set; }
        Control ParentControl { get; }
    }
}
