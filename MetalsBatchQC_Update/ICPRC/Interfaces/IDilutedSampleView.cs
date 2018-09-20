using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IDilutedSampleView
    {
        void SetController(DilutedSampleViewController controller);
        void AddSampleNameToList(string sampleName);

        void SetDialogResult(DialogResult dialogResult);
        int SelectedSampleIndex { get; set; }
        double DilutionFactor { get; set; }
    }
}
