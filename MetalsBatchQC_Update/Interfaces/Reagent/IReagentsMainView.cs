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
    public interface IReagentsMainView
    {
        void SetController(ReagentsMainViewController controller);
        void AddChemicalToListView(Chemical item);

        Control ParentControl { get; }
    }
}
