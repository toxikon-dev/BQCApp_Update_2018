using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IReportBuilderView
    {
        void SetController(ReportBuilderViewController controller);
        void SetProjectInfoLabel(ReportHeader reportHeader);

        void AddControlToRawFileSamplesTabPage(Control view);
        void AddControlToElementsTabPage(Control view);
        void AddControlToReportSamplesTabPage(Control view);
        void AddControlToSampleResultsTabPage(Control view);
     
        void AddControlToBQCReportTabPage(Control view);

        string RunID { get; }
    }
}
