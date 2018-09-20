using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Views.UserControls;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IMainView
    {
        void SetController(MainController controller);
        void AddControlToMainPanel(Control control);
        void ShowAdminMenuItems(bool value);
    }
}
