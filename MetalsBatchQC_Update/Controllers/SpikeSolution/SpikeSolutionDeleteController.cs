using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models.GenericModels;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class SpikeSolutionDeleteController
    {
        ISpikeSolutionDeleteView _view;
        SpikeSolution _selectedSpikeSolution;
        LoginInfo loginInfo;

        public SpikeSolutionDeleteController(ISpikeSolutionDeleteView view, SpikeSolution selectedSpikeSolution)
        {
            _view = view;
            _selectedSpikeSolution = selectedSpikeSolution;

            _view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            _view.ID = _selectedSpikeSolution.ProductCode;
            _view.SpikeSolutionName = _selectedSpikeSolution.ProductName;
        }

        public void SubmitButtonClicked()
        {
            if (_view.Reason.Trim() == "")
            {
                ShowInvalidValueMessageBox("Reason is required.");
            }
            else
            {
                this._selectedSpikeSolution.IsActive = false;
                UpdateSpikeSolutionIsActive(this._selectedSpikeSolution, loginInfo.UserName);
                CustomAuditRecord auditRecord = CreateCustomAuditRecord(
                                     this._selectedSpikeSolution.ItemID, _view.Reason, loginInfo.UserName);
                InsertAuditRecord(auditRecord);
            }
        }

        public void UpdateSpikeSolutionIsActive(SpikeSolution item, string userName)
        {
            Int32 dbResult = BATCHQC_UPDATE.UpdateBatchSpikeSolutions_IsActive(item, userName);
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
            auditRecord.TableName = "BatchSpikeSolutions";
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
