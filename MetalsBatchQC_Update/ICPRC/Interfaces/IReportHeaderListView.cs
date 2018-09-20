using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IReportHeaderListView
    {
        void SetController(ReportHeaderListViewController controller);
        void AddReportHeaderToListView(ReportHeader reportHeader);

        Control ParentControl { get; }
    }
}
