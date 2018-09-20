using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Interfaces.Admin
{
    public interface IBatchCodeUpdateView
    {
        void SetController(BatchCodeUpdateViewController controller);
        void AddMethodCodeToComboBox(string methodCode);
        void ClearView();

        string Month { get; set; }
        string Year { get; set; }
        string SequenceNumber { get; set; }
        string BatchCode { get; set; }
        string MethodCode { get; set; }
        bool IsComplete { get; set; }
        Control ParentControl { get; }
    }
}
