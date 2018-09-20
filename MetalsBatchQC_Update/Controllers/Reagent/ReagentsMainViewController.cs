using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class ReagentsMainViewController
    {
        IReagentsMainView view;
        IList chemicals;

        public ReagentsMainViewController(IReagentsMainView view)
        {
            this.view = view;
            this.view.SetController(this);
            chemicals = new ArrayList();
        }

        public void LoadView()
        {
            chemicals = BATCHQC_SELECT.SelectAllActiveReagents();
            foreach(Chemical item in chemicals)
            {
                view.AddChemicalToListView(item);
            }
        }

        public void AddNewReagentButtonClicked()
        {
            MainView mainView = (MainView)view.ParentControl;
            mainView.Invoke(mainView.loadReagentAddViewDelegate);
        }
    }
}
