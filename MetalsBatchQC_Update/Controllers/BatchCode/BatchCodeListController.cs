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
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class BatchCodeListController
    {
        IBatchCodeListView view;

        IList methodCodes;
        IList batchCodes;
        BatchCode selectedBatchCode;

        public BatchCodeListController(IBatchCodeListView view)
        {
            this.view = view;
            this.view.SetController(this);

            batchCodes = new ArrayList();
            methodCodes = new ArrayList();
        }

        public void LoadView()
        {
            LoadBatchCodes();
        }

        private void LoadBatchCodes()
        {
            batchCodes.Clear();
            view.ClearListView();

            batchCodes = BATCHQC_SELECT.GetActiveBatchCodes();
            foreach (BatchCode batchCode in batchCodes)
            {
                view.AddBatchCodeToListView(batchCode);
            }
        }

        public void BatchCodeListViewSelectedIndexChanged(int index)
        {
            this.selectedBatchCode = (BatchCode)batchCodes[index];
        }

        public void OpenButtonClicked()
        {
            if(this.selectedBatchCode == null)
            {
                MessageBox.Show("Please select one batch code and try it again.");
            }
            else
            {
                UpdateDataSheet();
                LoadDataSheet();
            }
        }

        private void UpdateDataSheet()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            dataSheet.Clear();
            dataSheet.SetBatchCode(selectedBatchCode);
            dataSheet.Load();
        }

        private void LoadDataSheet()
        {
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.loadDataSheetDelegate);
        }

        public void AddNewBatchButtonClicked()
        {
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.loadBatchCodeAddViewDelegate);
        }
    }
}
