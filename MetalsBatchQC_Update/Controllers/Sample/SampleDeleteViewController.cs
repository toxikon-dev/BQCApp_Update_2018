using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.GenericModels;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class SampleDeleteViewController
    {
        ISampleDeleteView view;
        Sample selectedSample;

        public SampleDeleteViewController(ISampleDeleteView view, Sample sample)
        {
            this.view = view;
            this.selectedSample = sample;
            this.view.SetController(this);
        }

        public void LoadView()
        {
            this.view.SampleCode = this.selectedSample.SampleCode;
        }

        public void SubmitButtonClicked()
        {
            if (view.Reason.Trim() == "")
            {
                ShowInvalidValueMessageBox("Reason is required.");
            }
            else
            {
                this.selectedSample.IsActive = false;
                LoginInfo loginInfo = LoginInfo.GetInstance();
                DataSheet dataSheet = DataSheet.GetInstance();
                string userName = loginInfo.UserName;
                int batchID = dataSheet.BatchCode.ID;
                string sampleCode = this.selectedSample.SampleCode;

                UpdateSampleIsActive(batchID, this.selectedSample, userName);

                CustomAuditRecord auditRecord = CreateCustomAuditRecord(batchID, sampleCode,
                                  view.Reason, loginInfo.UserName);
                InsertAuditRecord(auditRecord);
            }
        }

        public void UpdateSampleIsActive(int batchID, Sample item, string userName)
        {
            Int32 dbResult = BATCHQC_UPDATE.UpdateBatchSample_IsActive(batchID, item, userName);
        }

        public void InsertAuditRecord(CustomAuditRecord auditRecord)
        {
            BQC_CUSTOM_AUDIT.InsertCustomAudit(auditRecord);
        }

        private void ShowInvalidValueMessageBox(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                view.SetDialogResult(DialogResult.Retry);
            }
        }

        public CustomAuditRecord CreateCustomAuditRecord(int batchID, string sampleCode,
                                                         string reason, string userName)
        {
            CustomAuditRecord auditRecord = new CustomAuditRecord();
            auditRecord.TableName = "BatchSamples";
            auditRecord.Type = "U";
            auditRecord.PK = "BatchID,SampleCode";
            auditRecord.PKValue = batchID.ToString() + "," + sampleCode;
            auditRecord.FieldName = "IsActive";
            auditRecord.OldValue = "True";
            auditRecord.NewValue = "False";
            auditRecord.UpdatedBy = userName;
            auditRecord.Reason = reason;

            return auditRecord;
        }
    }
}
