using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Queries;
using System.Windows.Forms;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class BatchDetailController
    {
        IBatchDetailView view;
        DataSheet dataSheet;
        BatchDetail batchDetail;

        public BatchDetailController(IBatchDetailView view)
        {
            this.view = view;
            dataSheet = DataSheet.GetInstance();
            batchDetail = dataSheet.BatchDetail;

            this.view.SetController(this);
        }

        private void UpdateViewDetailValues()
        {
            view.BatchQCNumber = dataSheet.BatchCode.FullCode;
            view.PrepDate = batchDetail.PrepDate;
            view.PreparedBy = batchDetail.PreparedBy;
            view.SampleType = batchDetail.SampleType;
            view.InstrumentID = batchDetail.InstrumentID;
            view.BalanceID = batchDetail.BalanceID;
            view.Method = batchDetail.Method;
            view.MethodID = batchDetail.MethodID.Trim();
            view.MethodTemp = batchDetail.MethodTemp;
            view.Analyte = batchDetail.Analyte;
            view.PrepType = batchDetail.PrepType;
            view.PurifiedWater = batchDetail.PurifiedWater;
        }

        private void UpdateBatchDetailWithViewValues()
        {
            batchDetail.PreparedBy = view.PreparedBy;
            batchDetail.SampleType = view.SampleType;
            batchDetail.InstrumentID = view.InstrumentID;
            batchDetail.BalanceID = view.BalanceID;
            batchDetail.Method = view.Method;
            batchDetail.MethodID = view.MethodID;
            batchDetail.MethodTemp = view.MethodTemp;
            batchDetail.Analyte = view.Analyte;
            batchDetail.PrepType = view.PrepType;
        }

        public void LoadView()
        {
            UpdateViewDetailValues();
        }

        public void SaveButtonClicked()
        {
            try
            {
                UpdateBatchDetailWithViewValues();
                if(BATCHQC_SELECT.CheckBatchDetailExists())
                {
                    BATCHQC_UPDATE.UpdateBatchDetail();
                }
                else
                {
                    BATCHQC_INSERT.InsertBatchDetail();
                }
                
                MessageBox.Show("Batch detail is updated.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CompleteButtonClicked()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("This batch is complete?", "Batch QC",
                                        MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BATCHQC_UPDATE.UpdateBatchCodeIsComplete(1);
                    LoadBatchCodeListView();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadBatchCodeListView()
        {
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.loadBatchCodeListViewDelegate);
        }

        public void PrintButtonClicked()
        {
            dataSheet.Print();
        }
    }
}
