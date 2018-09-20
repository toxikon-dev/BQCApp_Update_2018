using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers.Admin
{
    public class UserUpdateViewController
    {
        IUserUpdateView view;
        IList roles;
        User selectedUser;

        public UserUpdateViewController(IUserUpdateView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.roles = new ArrayList();
        }

        public void LoadView()
        {
            roles = BATCHQC_SELECT.GetAllActiveRoles();
            foreach(Role role in roles)
            {
                view.AddRoleToRoleListBox(role);
            }
        }

        public void SearchButtonClicked()
        {
            try
            {
                if (view.SearchString.Trim() == "")
                {
                    MessageBox.Show("Username is required.");
                }
                else
                {
                    this.selectedUser = BATCHQC_SEARCH.SearchUserByUserName(view.SearchString);
                    UpdateViewWithSelectedUser();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateViewWithSelectedUser()
        {
            view.UserName = this.selectedUser.UserName;
            view.FullName = this.selectedUser.FullName;
            view.EmailAddress = this.selectedUser.EmailAddress;
            view.DepartmentCode = this.selectedUser.DepartmentCode;
            view.RoleID = this.selectedUser.RoleID.ToString();
            view.IsActive = this.selectedUser.IsActive;
        }

        public void SaveChangesButtonClicked()
        {
            try
            {
                UpdateSelectedUserWithViewValues();
                LoginInfo loginInfo = LoginInfo.GetInstance();
                BQC_ADMIN_UPDATE.UpdateUser(this.selectedUser, loginInfo.UserName);
                view.ClearView();
                MessageBox.Show("Updated!");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateSelectedUserWithViewValues()
        {
            this.selectedUser.RoleID = Convert.ToInt16(view.RoleID);
            this.selectedUser.IsActive = view.IsActive;
        }
    }
}
