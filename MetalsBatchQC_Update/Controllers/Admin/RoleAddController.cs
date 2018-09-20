using System;
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
    public class RoleAddController
    {
        IRoleAddView view;

        public RoleAddController(IRoleAddView view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public void SubmitButtonClicked()
        {
            try
            {
                Int32 result = BATCHQC_INSERT.InsertRole(view.RoleName);
                MessageBox.Show(view.RoleName + " role is created.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
