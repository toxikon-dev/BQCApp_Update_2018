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
    public interface IBatchCodeListView
    {
        void SetController(BatchCodeListController controller);
        void AddBatchCodeToListView(BatchCode batchCode);
        void ClearListView();

        Control ParentControl { get; }
    }
}
