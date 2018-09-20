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
    public class DepartmentAddController
    {
        IDepartmentAddView view;
        IList departmentListFromTMS;
        string selectedDepartmentName;

        public DepartmentAddController(IDepartmentAddView view)
        {
            this.view = view;
            view.SetController(this);
            selectedDepartmentName = "";
        }

        public void LoadView()
        {
            departmentListFromTMS = TMSQueries.GetAllDepartments();
            foreach(string departmentName in departmentListFromTMS)
            {
                view.AddDepartmentToListBox(departmentName);
            }
        }

        public void ListBoxSelectedIndexChanged(int selectedIndex)
        {
            selectedDepartmentName = departmentListFromTMS[selectedIndex].ToString();
        }

        public void SubmitButtonClicked()
        {
            try
            {
                if (selectedDepartmentName != "")
                {
                    Int32 result = BATCHQC_INSERT.InsertDepartment(selectedDepartmentName);
                    MessageBox.Show("Selected department is added to BatchQC.");
                }
                else
                {
                    MessageBox.Show("No department is selected.");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
