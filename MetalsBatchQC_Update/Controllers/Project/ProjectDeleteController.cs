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
    public class ProjectDeleteController
    {
        IProjectDeleteView _view;
        Project selectedProject;

        public ProjectDeleteController(IProjectDeleteView view, Project project)
        {
            this._view = view;
            this.selectedProject = project;

            _view.SetController(this);
        }

        public void LoadView()
        {
            _view.ProjectNumber = selectedProject.ProjectNumber;
            _view.SponsorName = selectedProject.SponsorName;
        }

        public void SubmitButtonClicked()
        {
            if(_view.Reason.Trim() == "")
            {
                ShowInvalidValueMessageBox("Reason is required.");
            }
            else
            {
                this.selectedProject.IsActive = false;
                LoginInfo loginInfo = LoginInfo.GetInstance();
                DataSheet dataSheet = DataSheet.GetInstance();
                string userName = loginInfo.UserName;
                int batchID = dataSheet.BatchCode.ID;
                string projectNumber = this.selectedProject.ProjectNumber;

                UpdateProjectIsActive(batchID, this.selectedProject, userName);

                CustomAuditRecord auditRecord = CreateCustomAuditRecord(batchID, projectNumber, 
                                  _view.Reason, loginInfo.UserName);
                InsertAuditRecord(auditRecord);
            }
        }

        public void UpdateProjectIsActive(int batchID, Project project, string userName)
        {
            Int32 dbResult = BATCHQC_UPDATE.UpdateBatchProject_IsActive(batchID, project, userName);
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

        public CustomAuditRecord CreateCustomAuditRecord(int batchID, string projectNumber, 
                                                         string reason, string userName)
        {
            CustomAuditRecord auditRecord = new CustomAuditRecord();
            auditRecord.TableName = "BatchProjects";
            auditRecord.Type = "U";
            auditRecord.PK = "BatchID,ProjectNumber";
            auditRecord.PKValue = batchID.ToString() + "," + projectNumber;
            auditRecord.FieldName = "IsActive";
            auditRecord.OldValue = "True";
            auditRecord.NewValue = "False";
            auditRecord.UpdatedBy = userName;
            auditRecord.Reason = reason;

            return auditRecord;
        }
    }
}
