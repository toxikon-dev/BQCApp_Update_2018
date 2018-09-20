using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IBatchReportView
    {
        void SetController(BatchReportViewController controller);
        Control ParentControl { get; }

        void AddBQCElementResultToView(BQCElementResult result);
        void UpdateElementResult(int selectedIndex, BQCElementResult result);

        DataTable GetCurrentDataTable();
    }
}
