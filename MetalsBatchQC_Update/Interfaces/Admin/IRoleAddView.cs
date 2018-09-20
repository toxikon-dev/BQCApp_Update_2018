using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IRoleAddView
    {
        void SetController(RoleAddController controller);

        string RoleName { get; set; }
    }
}
