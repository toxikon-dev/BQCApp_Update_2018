using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Interfaces.Admin
{
    public interface IInstrumentAddView
    {
        void SetController(InstrumentAddViewController controller);

        string InstrumentID { get; set; }
        string InstrumentName { get; set; }
    }
}
