using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IBatchCodeAddView
    {
        void SetController(BatchCodeAddController controller);
        void AddMethodCodeToComboBox(MethodCode item);
        void SetMethodCodeComboBoxSelectedIndex(int index);

        Control ParentControl { get; }
    }
}
