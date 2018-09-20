using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Models.Reports
{
    public class BQCReport
    {
        private static BQCReport instance;
        public string Method { get; private set; }
        public string Matrix { get; private set; }
        public string AnalyticalInstrument { get; private set; }
        public string BQCSampleTypes { get; private set; }
        public string BQCComment { get; private set; }
        public IList BatchNumbers { get; private set; }
        public string ProjectNumber { get; private set; }
        public string SampleID { get; private set; }
        public string RunID { get; private set; }
        public string Exceptions { get; private set; }
        public string BQCStatus { get; private set; }
        public string RunComment { get; private set; }
        public string Analyst { get; private set; }
        public string AnalystSignature { get; private set; }
        public string AnalystSignedDate { get; private set; }
        public string QA { get; private set; }
        public string QASignature { get; private set; }
        public string QASignedDate { get; private set; }
        public string StudyDirector { get; private set; }
        public string SDSignature { get; private set; }
        public string SDSignedDate { get; private set; }
        public bool IsAnalystApproved { get; private set; }
        public bool IsQAApproved { get; private set; }
        public bool IsSDApproved { get; private set; }

        public static BQCReport GetInstance()
        {
            if(instance == null)
            {
                instance = new BQCReport();
            }
            return instance;
        }

        private BQCReport()
        {
            Method = "N/A";
            Matrix = "N/A";
            AnalyticalInstrument = "N/A";
            BQCSampleTypes = "LCS";
            BQCComment = "N/A";
            BatchNumbers = new ArrayList();
            ProjectNumber = "N/A";
            SampleID = "N/A";
            RunID = "N/A";
            Exceptions = "N/A";
            BQCStatus = "N/A";
            RunComment = "N/A";
            Analyst = "N/A";
            AnalystSignature = "N/A";
            QA = "N/A";
            QASignature = "N/A";
            StudyDirector = "N/A";
            SDSignature = "N/A";
        }

        public void Load()
        {
            LoadBatchNumbers();
            Int32 dbResult = BATCHQC_SELECT.GetBQCReportByProjectNumber(this.ProjectNumber);
        }

        public void SetProjectNumber(string projectNumber)
        {
            this.ProjectNumber = projectNumber;
        }

        public void SetMethod(string method)
        {
            this.Method = method;
        }

        public void SetMatrix(string matrix)
        {
            this.Matrix = matrix;
        }

        public void SetAnalyticalInstrument(string instruments)
        {
            this.AnalyticalInstrument = instruments;
        }

        public void SetBQCSampleTypes(string sampleTypes)
        {
            this.BQCSampleTypes = sampleTypes;
        }
        public void SetBQCComment(string comment)
        {
            this.BQCComment = comment;
        }
        public void SetSampleIDs(string sampleIDs)
        {
            this.SampleID = sampleIDs;
        }
        public void SetRunID(string runID)
        {
            this.RunID = runID;
        }
        public void SetExceptions(string exceptions)
        {
            this.Exceptions = exceptions;
        }
        public void SetBQCStatus(string status)
        {
            this.BQCStatus = status;
        }
        public void SetRunComment(string comment)
        {
            this.RunComment = comment;
        }

        public void SetAnalyst(string analyst)
        {
            this.Analyst = analyst;
        }

        public void SetAnalystSignature(string analystSignature)
        {
            this.AnalystSignature = analystSignature;
        }

        public void SetAnalystSignedDate(string signedDate)
        {
            this.AnalystSignedDate = signedDate;
        }

        public void SetQA(string QA)
        {
            this.QA = QA;
        }
        public void SetQASignature(string signature)
        {
            this.QASignature = signature;
        }
        public void SetQASignedDate(string signedDate)
        {
            this.QASignedDate = signedDate;
        }
        public void SetStudyDirector(string SD)
        {
            this.StudyDirector = SD;
        }
        public void SetSDSignature(string signature)
        {
            this.SDSignature = signature;
        }
        public void SetSDSignedDate(string signedDate)
        {
            this.SDSignedDate = signedDate;
        }
        public void SetIsAnalystApproved(bool value)
        {
            this.IsAnalystApproved = value;
        }
        public void SetIsQAApproved(bool value)
        {
            this.IsQAApproved = value;
        }
        public void SetIsSDApproved(bool value)
        {
            this.IsSDApproved = value;
        }

        private void LoadBatchNumbers()
        {
            this.BatchNumbers = BATCHQC_SELECT.GetBatchCodesForProject(this.ProjectNumber);
        }

        public void LoadApproverInfo()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            if(loginInfo.RoleID == 2 || loginInfo.RoleID == 1)
            {
                this.Analyst = loginInfo.FullName;
            }
            else if (loginInfo.RoleID == 3)
            {
                this.QA = loginInfo.FullName;
            }
            else if(loginInfo.RoleID == 4)
            {
                this.StudyDirector = loginInfo.FullName;
            }
        }

        public void Print()
        {
            BQCReportWordTemplate template = new BQCReportWordTemplate();
            template.Create();
        }
    }
}
