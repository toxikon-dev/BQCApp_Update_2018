using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Reports;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Interfaces.Reports
{
    public interface IControlChartReportView
    {
        void SetController(ControlChartReportViewController controller);
        void AddReportToListView(ControlChartReport report);
        void ShowProgressBar(bool value);
        void ShowProgress(int progressPercentage, string message);
    }
}
