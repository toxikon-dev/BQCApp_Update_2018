using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.GenericModels;

namespace Toxikon.BatchQC.Controllers
{
    public class ReagentDeleteController
    {
        IReagentDeleteView _view;
        Reagent _selectedReagent;

        public ReagentDeleteController(IReagentDeleteView view, Reagent selectedReagent)
        {
            _view = view;
            _selectedReagent = selectedReagent;

            _view.SetController(this);
        }

        public void LoadView()
        {
            _view.ReagentID = _selectedReagent.ItemCode;
            _view.ReagentName = _selectedReagent.ProductName;
            _view.Amount = _selectedReagent.Amount.ToString();
        }

        public void SubmitButtonClicked()
        {
            if(_view.Reason.Trim() == "")
            {
                ShowInvalidValueMessageBox("Reason is required.");
            }
            else
            {
                LoginInfo loginInfo = LoginInfo.GetInstance();
                this._selectedReagent.IsActive = false;
                UpdateReagentIsActive(this._selectedReagent, loginInfo.UserName);

                CustomAuditRecord auditRecord = CreateCustomAuditRecord(
                                     this._selectedReagent.ItemID, _view.Reason, loginInfo.UserName);
                InsertAuditRecord(auditRecord);
            }
        }

        public void UpdateReagentIsActive(Reagent item, string userName)
        {
            Int32 dbResult = BATCHQC_UPDATE.UpdateBatchReagent_IsActive(item, userName);
        }

        public void InsertAuditRecord(CustomAuditRecord auditRecord)
        {
            BQC_CUSTOM_AUDIT.InsertCustomAudit(auditRecord);
        }

        private void ShowInvalidValueMessageBox(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                _view.SetDialogResult(DialogResult.Retry);
            }
        }

        public CustomAuditRecord CreateCustomAuditRecord(int itemID, string reason, string userName)
        {
            CustomAuditRecord auditRecord = new CustomAuditRecord();
            auditRecord.TableName = "BatchReagents";
            auditRecord.Type = "U";
            auditRecord.PK = "ID";
            auditRecord.PKValue = itemID.ToString();
            auditRecord.FieldName = "IsActive";
            auditRecord.OldValue = "True";
            auditRecord.NewValue = "False";
            auditRecord.UpdatedBy = userName;
            auditRecord.Reason = reason;

            return auditRecord;
        }
    }
}
