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
    public interface IProjectsView
    {
        void SetController(ProjectsController controller);
        void AddItemToListView(Project project);
        void RemoveItemFromListViewAt(int itemIndex);
        void ShowDeleteButton(bool value);

        Control ParentControl { get; }
    }
}
