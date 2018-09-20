using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IProjectOptionsView
    {
        void SetController(ProjectOptionsController controller);
        void AddProjectToListView(Project project);
        void SetDialogResult(DialogResult dialogResult);

        string SelectedProjectNumber { get; set; }
    }
}
