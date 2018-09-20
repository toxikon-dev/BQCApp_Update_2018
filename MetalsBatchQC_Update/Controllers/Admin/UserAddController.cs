using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class UserAddController
    {
        IUserAddView view;
        IList searchResults;
        IList departments;
        IList roles;

        User selectedUser;
        Department selectedDepartment;
        Role selectedRole;

        public UserAddController(IUserAddView view)
        {
            this.view = view;
            this.view.SetController(this);

            this.searchResults = new ArrayList();
            this.departments = new ArrayList();
            this.roles = new ArrayList();
            selectedUser = new User();
        }

        public void LoadView()
        {
            LoadDepartments();
            LoadRoles();
            view.SetDepartmentComboBoxSelectedIndex(0);
            view.SetRoleComboBoxSelectedIndex(0);
        }

        private void LoadDepartments()
        {
            departments = BATCHQC_SELECT.GetAllActiveDepartments();
            foreach(Department department in departments)
            {
                view.AddDepartmentToDepartmentComboBox(department);
            }
        }

        private void LoadRoles()
        {
            roles = BATCHQC_SELECT.GetAllActiveRoles();
            foreach(Role role in roles)
            {
                view.AddRoleToRoleComboBox(role);
            }
        }

        public void SearchButtonClicked()
        {
            try
            {
                searchResults = TMSQueries.GetResultsFromSearchEmployee(view.SearchString);
                view.ClearUserListView();
                UpdateUserListViewWithSearchResults();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateUserListViewWithSearchResults()
        {
            foreach(User user in searchResults)
            {
                this.view.AddUserToListView(user);
            }
        }

        public void UserListViewSelectedIndexChanged(int index)
        {
            selectedUser = (User)this.searchResults[index];
        }

        public void DepartmentComboBoxSelectedIndexChanged(int index)
        {
            this.selectedDepartment = (Department)this.departments[index];
        }

        public void RoleComboBoxSelectedIndexChanged(int index)
        {
            this.selectedRole = (Role)this.roles[index];
        }

        public void SubmitButtonClicked()
        {
            try
            {
                if(selectedUser.UserName != "")
                {
                    selectedUser.DepartmentCode = this.selectedDepartment.DepartmentCode;
                    selectedUser.RoleID = this.selectedRole.RoleID;
                    Int32 result = BATCHQC_INSERT.InsertUser(this.selectedUser);
                    MessageBox.Show("New user is added.");
                    view.ClearUserListView();
                    view.SearchString = "";
                }
                else
                {
                    MessageBox.Show("No user is selected.");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
