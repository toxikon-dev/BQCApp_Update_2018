using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISampleAddView
    {
        void SetController(SampleAddController controller);
        void SetDialogResult(DialogResult dialogResult);

        string GroupCode { get; set; }
        string SampleCode { get; set; }

        string SampleAmount { get; set; }
        string SampleUnit { get; set; }

        string InitialDigestionAmount { get; set; }
        string InitialDigestionUnit { get; set; }

        string FinalAmount { get; set; }
        string FinalUnit { get; set; }

        string Description { get; set; }
    }
}
