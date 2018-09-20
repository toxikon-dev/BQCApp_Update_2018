using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Role
    {
        public Int16 RoleID { get; set; }
        public string RoleName { get; set; }

        public Role()
        {
            this.RoleID = 0;
            this.RoleName = "";
        }
    }
}
