using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.GenericModels;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Views.Admin;

namespace Toxikon.BatchQC.Controllers.Admin
{
    public class BatchCodeUpdateViewController
    {
        IBatchCodeUpdateView view;
        BatchCode oldBatchCode;
        BatchCode newBatchCode;
        LoginInfo loginInfo;

        public BatchCodeUpdateViewController(IBatchCodeUpdateView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            view.Month = DateTime.Now.Month.ToString();
            view.Year = DateTime.Now.Year.ToString();
            view.SequenceNumber = "";
            view.BatchCode = "";
            view.AddMethodCodeToComboBox(MethodCodes.MEMS);
            view.AddMethodCodeToComboBox(MethodCodes.MEOE);
            view.AddMethodCodeToComboBox(MethodCodes.MEPQ);
            view.AddMethodCodeToComboBox(MethodCodes.MERQ);
        }

        public void SearchButtonClicked()
        {
            SearchBatchCodeFromDB();
            if(oldBatchCode != null)
            {
                UpdateViewWithSearchResult();
            }
            else
            {
                MessageBox.Show("No record found.");
            }          
        }

        private void SearchBatchCodeFromDB()
        {
            int sequenceNumber;
            int createdMonth;
            int createdYear;
            if(Int32.TryParse(view.SequenceNumber, out sequenceNumber) &&
               Int32.TryParse(view.Month, out createdMonth) &&
               Int32.TryParse(view.Year, out createdYear))
            {
                oldBatchCode = BATCHQC_SEARCH.SearchBatchCode(createdMonth, createdYear, sequenceNumber);
            }
            else
            {
                MessageBox.Show("Invalid search inputs.");
            }
        }

        private void UpdateViewWithSearchResult()
        {
            view.BatchCode = oldBatchCode.FullCode;
            view.MethodCode = oldBatchCode.MethodCode;
            view.IsComplete = oldBatchCode.IsComplete;
        }

        public void UpdateButtonClicked()
        {
            if(oldBatchCode != null)
            {
                string reasonOfTheUpdate = GetReasonOfTheUpdate();
                UpdateNewBatchCodeWithViewValues();
                UpdateBatchCode(newBatchCode);
                CustomAuditRecord auditRecord = CreateCustomAuditRecord(
                                this.oldBatchCode.ID, reasonOfTheUpdate, loginInfo.UserName);
                InsertAuditRecord(auditRecord);
                view.ClearView();
                MessageBox.Show("Updated!");
            }
            else
            {
                MessageBox.Show("Invalid batch code.");
            }
        }

        private string GetReasonOfTheUpdate()
        {
            string reason = "";
            ReasonView popup = new ReasonView();
            ReasonViewController popupController = new ReasonViewController(popup);

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                reason = popupController.Reason.Trim();
            }
            popup.Dispose();
            return reason;
        }

        private void UpdateNewBatchCodeWithViewValues()
        {
            newBatchCode = new BatchCode();
            newBatchCode.ID = oldBatchCode.ID;
            newBatchCode.MethodCode = view.MethodCode;
            newBatchCode.FullCode = oldBatchCode.FullCode.Replace(oldBatchCode.MethodCode, newBatchCode.MethodCode);
            newBatchCode.IsActive = view.IsComplete == true ? false : true;
            newBatchCode.IsComplete = view.IsComplete;
        }

        private void UpdateBatchCode(BatchCode newBatchCode)
        {
            BATCHQC_UPDATE.UpdateBatchCode(newBatchCode, loginInfo.UserName);
        }

        public CustomAuditRecord CreateCustomAuditRecord(int itemID, string reason, string userName)
        {
            CustomAuditRecord auditRecord = new CustomAuditRecord();
            auditRecord.TableName = "BatchCodes";
            auditRecord.Type = "U";
            auditRecord.PK = "ID";
            auditRecord.PKValue = itemID.ToString();
            auditRecord.FieldName = "BatchCode,MethodCode,IsActive,IsComplete";
            auditRecord.OldValue = oldBatchCode.FullCode + "," + oldBatchCode.MethodCode + "," + 
                                   oldBatchCode.IsActive + "," + oldBatchCode.IsComplete;
            auditRecord.NewValue = newBatchCode.FullCode + "," + newBatchCode.MethodCode + "," + 
                                   newBatchCode.IsActive + "," + newBatchCode.IsComplete;
            auditRecord.UpdatedBy = userName;
            auditRecord.Reason = reason;

            return auditRecord;
        }

        public void InsertAuditRecord(CustomAuditRecord auditRecord)
        {
            BQC_CUSTOM_AUDIT.InsertCustomAudit(auditRecord);
        }
    }
}
