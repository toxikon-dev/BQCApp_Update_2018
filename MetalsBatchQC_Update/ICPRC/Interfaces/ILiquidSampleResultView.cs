using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface ILiquidSampleResultView
    {
        void SetController(LiquidSampleResultViewController controller);

        void AddSampleNameToListBox(string sampleName);
        void ClearSampleNameListBox();

        void AddDataGridViewToView(LiquidDataGridView dataGrid);

        Control ParentControl { get; }
    }
}
