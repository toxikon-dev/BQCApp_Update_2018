using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISampleGroupAddView
    {
        void SetController(SampleGroupAddController controller);
        void AddItemToComboBox(string item);
        void SetComboBoxSelectedIndex(int index);
        void SetDialogResult(DialogResult dialogResult);

        string GroupCode { get; set; }
        string ProjectNumber { get; }

        string SampleAmount { get; set; }
        string SampleUnit { get; set; }

        string InitialDigestionAmount { get; set; }
        string InitialDigestionUnit { get; set; }

        string FinalAmount { get; set; }
        string FinalUnit { get; set; }

        string Description { get; set; }
        string NumberOfSamples { get; set; }
    }
}
