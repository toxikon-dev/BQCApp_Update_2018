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

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class RoleAddView : UserControl, IRoleAddView
    {
        RoleAddController controller;

        public RoleAddView()
        {
            InitializeComponent();
        }

        public void SetController(RoleAddController controller)
        {
            this.controller = controller;
        }

        public string RoleName
        {
            get { return this.RoleNameTextBox.Text; }
            set { this.RoleNameTextBox.Text = value; }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
