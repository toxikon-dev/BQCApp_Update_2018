using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class UserAddView : UserControl, IUserAddView
    {
        UserAddController controller;
        public string SearchString
        {
            get { return this.SearchTextBox.Text; }
            set { this.SearchTextBox.Text = value; }
        }

        public UserAddView()
        {
            InitializeComponent();
            this.RoleComboBox.DisplayMember = "RoleName";
            this.DepartmentComboBox.DisplayMember = "DepartmentName";
        }

        public void SetController(UserAddController controller)
        {
            this.controller = controller;
        }

        public void SetDepartmentComboBoxSelectedIndex(int index)
        {
            this.DepartmentComboBox.SelectedIndex = index;
        }

        public void SetRoleComboBoxSelectedIndex(int index)
        {
            this.RoleComboBox.SelectedIndex = index;
        }

        public void ClearUserListView()
        {
            this.UserListView.Items.Clear();
        }

        public void AddUserToListView(User user)
        {
            ListViewItem item = this.UserListView.Items.Add(user.UserName);
            item.SubItems.Add(user.FullName);
            item.SubItems.Add(user.PositionTitle);
        }

        public void AddDepartmentToDepartmentComboBox(Department item)
        {
            this.DepartmentComboBox.Items.Add(item);
        }

        public void AddRoleToRoleComboBox(Role item)
        {
            this.RoleComboBox.Items.Add(item);
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.DepartmentComboBoxSelectedIndexChanged(this.DepartmentComboBox.SelectedIndex);
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.RoleComboBoxSelectedIndexChanged(this.RoleComboBox.SelectedIndex);
        }

        private void UserListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.UserListView.SelectedIndices.Count != 0)
            {
                this.controller.UserListViewSelectedIndexChanged(this.UserListView.SelectedIndices[0]);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
