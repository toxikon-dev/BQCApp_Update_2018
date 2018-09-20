using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISampleDeleteView
    {
        void SetController(SampleDeleteViewController controller);
        void SetDialogResult(DialogResult dialogResult);

        string SampleCode { get; set; }
        string Reason { get; }
    }
}
