using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Reports;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Controllers.Reports
{
    public class BQCReportViewController
    {
        IBQCReportView view;
        BQCReport report;
        LoginInfo loginInfo;

        public BQCReportViewController(IBQCReportView view)
        {
            this.view = view;
            this.view.SetController(this);

            report = BQCReport.GetInstance();
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            report.LoadApproverInfo();
            view.Method = report.Method;
            view.Matrix = report.Matrix;
            view.AnalyticalInstrument = report.AnalyticalInstrument;
            view.BQCSampleTypes = report.BQCSampleTypes;
            view.BQCComment = report.BQCComment;
            LoadBatchNumbers();
            view.ProjectNumber = report.ProjectNumber;
            view.SampleID = report.SampleID;
            view.RunID = report.RunID;
            view.Exceptions = report.Exceptions;
            view.BQCStatus = report.BQCStatus;
            view.RunComment = report.RunComment;
            view.Analyst = report.Analyst;
            view.AnalystSignature = report.AnalystSignature;
            view.QA = report.QA;
            view.QASignature = report.QASignature;
            view.StudyDirector = report.StudyDirector;
            view.SDSignature = report.SDSignature;
            SetViewByRoleID();
            SetPrintOnly();
        }

        private void LoadBatchNumbers()
        {
            foreach(string batchNumber in report.BatchNumbers)
            {
                view.AddBatchNumberToListBox(batchNumber);
            }
        }

        private void SetViewByRoleID()
        {
            switch(loginInfo.RoleID)
            {
                case 1:
                    view.ShowAnalystView();
                    break;
                case 2:
                    view.ShowAnalystView();
                    break;
                case 3:
                    view.ShowQAView();
                    break;
                case 4:
                    view.ShowStudyDirectorView();
                    break;
                default:
                    break;
            }
        }

        private void SetPrintOnly()
        {
            view.IsPrintOnly = false;
            if((loginInfo.RoleID == 2 && report.IsAnalystApproved) || 
                (loginInfo.RoleID == 3 && report.IsQAApproved) ||
                (loginInfo.RoleID == 4 && report.IsSDApproved))
            {
                view.IsPrintOnly = true;
            }
        }

        public void SaveChangesButtonClicked()
        {
            try
            {
                UpdateReportWithViewValues();
                Int32 dbUpdateResult = BATCHQC_UPDATE.UpdateBQCReport();
                MessageBox.Show("Report is updated.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateReportWithViewValues()
        {
            report.SetMatrix(view.Matrix);
            report.SetAnalyticalInstrument(view.AnalyticalInstrument);
            report.SetBQCSampleTypes(view.BQCSampleTypes);
            report.SetBQCComment(view.BQCComment);

            report.SetSampleIDs(view.SampleID);
            report.SetRunID(view.RunID);
            report.SetExceptions(view.Exceptions);
            report.SetBQCStatus(view.BQCStatus);
            report.SetRunComment(view.RunComment);
            report.SetAnalyst(view.Analyst);
            report.SetAnalystSignature(view.AnalystSignature);
        }

        public void PrintButtonClicked()
        {
            report.Print();
        }
    }
}
