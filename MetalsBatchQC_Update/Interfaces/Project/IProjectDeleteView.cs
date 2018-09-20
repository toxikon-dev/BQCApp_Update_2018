using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IProjectDeleteView
    {
        void SetController(ProjectDeleteController controller);
        void SetDialogResult(DialogResult dialogResult);

        string ProjectNumber { get; set; }
        string SponsorName { get; set; }
        string Reason { get; }
    }
}
