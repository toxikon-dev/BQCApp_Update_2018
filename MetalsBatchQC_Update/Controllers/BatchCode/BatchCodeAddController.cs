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
    public class BatchCodeAddController
    {
        IBatchCodeAddView view;
        IList methodCodes;
        MethodCode selectedMethodCode;
       
        public BatchCodeAddController(IBatchCodeAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            methodCodes = new ArrayList();
        }

        public void LoadView()
        {
            MethodCode m1 = new MethodCode();
            m1.Code = "MEMS";
            m1.DepartmentCode = "605";
            MethodCode m2 = new MethodCode();
            m2.Code = "MEOE";
            m2.DepartmentCode = "605";
            MethodCode m3 = new MethodCode();
            m3.Code = "MEPQ";
            m3.DepartmentCode = "605";
            MethodCode m4 = new MethodCode();
            m4.Code = "MERQ";
            m4.DepartmentCode = "605";

            methodCodes.Add(m1);
            methodCodes.Add(m2);
            methodCodes.Add(m3);
            methodCodes.Add(m4);
            
            view.AddMethodCodeToComboBox(m1);
            view.AddMethodCodeToComboBox(m2);
            view.AddMethodCodeToComboBox(m3);
            view.AddMethodCodeToComboBox(m4);

            selectedMethodCode = m1;
            view.SetMethodCodeComboBoxSelectedIndex(0);

            selectedMethodCode = m2;
            view.SetMethodCodeComboBoxSelectedIndex(1);

            selectedMethodCode = m3;
            view.SetMethodCodeComboBoxSelectedIndex(2);

            selectedMethodCode = m4;
            view.SetMethodCodeComboBoxSelectedIndex(3);
        }

        public void MethodCodeComboBoxSelectedIndexChanged(int index)
        {
            this.selectedMethodCode = (MethodCode)methodCodes[index];
        }

        public void SubmitButtonClicked()
        {
            try
            {
                BatchCode batchCode = CreateNewBatchCode();
                UpdateDataSheet(batchCode);
                LoadDataSheet();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private BatchCode CreateNewBatchCode()
        {
            BatchCode batchCode = new BatchCode();
            batchCode.SequenceNumber = BATCHQC_INSERT.InsertLastSequenceNumber();
            batchCode.MethodCode = selectedMethodCode.Code;
            batchCode.DepartmentCode = selectedMethodCode.DepartmentCode;
            batchCode.SetFullCode();
            Int32 batchID = BATCHQC_INSERT.InsertBatchCode(batchCode);
            batchCode.ID = batchID;

            return batchCode;
        }

        private void UpdateDataSheet(BatchCode batchCode)
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            dataSheet.Clear();
            dataSheet.SetBatchCode(batchCode);
            dataSheet.Load();
        }

        private void LoadDataSheet()
        {
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.loadDataSheetDelegate);
        }
    }
}
