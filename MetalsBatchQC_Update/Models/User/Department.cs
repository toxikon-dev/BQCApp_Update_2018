using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Department
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public Department()
        {
            DepartmentCode = "";
            DepartmentName = "";
        }
    }
}
