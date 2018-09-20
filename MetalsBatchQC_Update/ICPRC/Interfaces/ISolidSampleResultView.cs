using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface ISolidSampleResultView
    {
        void SetController(SolidSampleResultViewController controller);
        void AddSampleNameToListBox(string sampleName);
        void ClearSampleNameListBox();
        void AddDataGridViewToView(SolidDataGridView dataGrid);
        Control ParentControl { get; }
    }
}
