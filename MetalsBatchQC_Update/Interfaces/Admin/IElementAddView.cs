using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Interfaces.Admin
{
    public interface IElementAddView
    {
        void SetController(ElementAddViewController controller);

        string Symbol { get; set; }
        string ElementName { get; set; }
        string MassValue {get; set; }
        string TrueValue { get; set; }
        string TrueValueUnit { get; set; }
        string ReportingLimitValue { get; set; }
        string ReportingLimitUnit { get; set; }
        string InstrumentID { get; set; }
    }
}
