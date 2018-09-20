using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IUserAddView
    {
        void SetController(UserAddController controller);
        void SetDepartmentComboBoxSelectedIndex(int index);
        void SetRoleComboBoxSelectedIndex(int index);
        void ClearUserListView();
        void AddUserToListView(User user);
        void AddDepartmentToDepartmentComboBox(Department item);
        void AddRoleToRoleComboBox(Role item);

        string SearchString { get; set; }
    }
}
