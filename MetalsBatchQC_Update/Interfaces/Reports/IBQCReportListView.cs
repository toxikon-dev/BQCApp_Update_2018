using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Reports;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces.Reports
{
    public interface IBQCReportListView
    {
        void SetController(BQCReportListViewController controller);
        void AddProjectToListView(Project project);
        void ClearProjectListView();

        Control ParentControl { get; }
    }
}
