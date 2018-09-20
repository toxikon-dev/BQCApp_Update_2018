using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers.Admin;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces.Admin
{
    public interface IUserUpdateView
    {
        void SetController(UserUpdateViewController controller);
        void AddRoleToRoleListBox(Role role);
        void ClearView();

        string SearchString { get; set; }
        string UserName { get; set; }
        string FullName { get; set; }
        string EmailAddress { get; set; }
        string DepartmentCode { get; set; }
        string RoleID { get; set; }
        bool IsActive { get; set; }
    }
}
