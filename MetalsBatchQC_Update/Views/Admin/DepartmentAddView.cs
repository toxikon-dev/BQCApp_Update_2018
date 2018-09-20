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
    public partial class DepartmentAddView : UserControl, IDepartmentAddView
    {
        DepartmentAddController controller;

        public DepartmentAddView()
        {
            InitializeComponent();
        }

        public void SetController(DepartmentAddController controller)
        {
            this.controller = controller;
        }

        public void AddDepartmentToListBox(string departmentName)
        {
            this.DepartmentListBox.Items.Add(departmentName);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void DepartmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ListBoxSelectedIndexChanged(this.DepartmentListBox.SelectedIndex);
        }
    }
}
