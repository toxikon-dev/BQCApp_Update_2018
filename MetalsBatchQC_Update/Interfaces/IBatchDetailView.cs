using Toxikon.BatchQC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IBatchDetailView
    {
        void SetController(BatchDetailController controller);

        string BatchQCNumber { get; set; }
        string PrepDate { get; set; }
        string PreparedBy { get; set; }
        string SampleType { get; set; }
        string InstrumentID { get; set; }
        string BalanceID { get; set; }
        string Method { get; set; }
        string MethodID { get; set; }
        string MethodTemp { get; set; }
        string Analyte { get; set; }
        string PrepType { get; set; }
        string PurifiedWater { get; set; }

        Control ParentControl { get; }
    }
}
