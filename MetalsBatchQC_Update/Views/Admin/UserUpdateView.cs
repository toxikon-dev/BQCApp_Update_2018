using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Controllers.Admin;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Views.Admin
{
    public partial class UserUpdateView : UserControl, IUserUpdateView
    {
        UserUpdateViewController controller;
        public UserUpdateView()
        {
            InitializeComponent();
        }

        public void SetController(UserUpdateViewController controller)
        {
            this.controller = controller;
        }

        public void AddRoleToRoleListBox(Role role)
        {
            string displayString = role.RoleID + " - " + role.RoleName;
            this.RoleListBox.Items.Add(displayString);
        }
        
        public void ClearView()
        {
            this.UsernameLabel.Text = "";
            this.FullNameLabel.Text = "";
            this.EmailAddressLabel.Text = "";
            this.DepartmentCodeLabel.Text = "";
            this.RoleIDTextBox.Text = "";
            this.TrueRadioButton.Checked = false;
            this.FalseRadioButton.Checked = false;
        }

        public string SearchString 
        {
            get { return this.SearchTextBox.Text; }
            set { this.SearchTextBox.Text = value; }
        }
        public string UserName
        {
            get { return this.UsernameLabel.Text; }
            set { this.UsernameLabel.Text = value; }
        }

        public string FullName
        {
            get { return this.FullNameLabel.Text; }
            set { this.FullNameLabel.Text = value; }
        }
        public string EmailAddress
        {
            get { return this.EmailAddressLabel.Text; }
            set { this.EmailAddressLabel.Text = value; }
        }
        public string DepartmentCode
        {
            get { return this.DepartmentCodeLabel.Text; }
            set { this.DepartmentCodeLabel.Text = value; }
        }
        public string RoleID
        {
            get { return this.RoleIDTextBox.Text; }
            set { this.RoleIDTextBox.Text = value; }
        }
        public bool IsActive
        {
            get { return this.TrueRadioButton.Checked; }
            set 
            {
                this.TrueRadioButton.Checked = value == true ? true : false;
                this.FalseRadioButton.Checked = value == true ? false : true;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.controller.SaveChangesButtonClicked();
        }
    }
}
