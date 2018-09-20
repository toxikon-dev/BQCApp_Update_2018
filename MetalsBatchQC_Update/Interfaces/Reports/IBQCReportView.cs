using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers.Reports;

namespace Toxikon.BatchQC.Interfaces.Reports
{
    public interface IBQCReportView
    {
        void SetController(BQCReportViewController controller);

        string Method { get; set; }
        string Matrix { get; set; }
        string AnalyticalInstrument { get; set; }
        string BQCSampleTypes { get; set; }
        string BQCComment { get; set; }
        string ProjectNumber { get; set; }
        string SampleID { get; set; }
        string RunID { get; set; }
        string Exceptions { get; set; }
        string BQCStatus { get; set; }
        string RunComment { get; set; }

        string Analyst { get; set; }
        string AnalystSignature { get; set; }

        string QA { get; set; }
        string QASignature { get; set; }

        string StudyDirector { get; set; }
        string SDSignature { get; set; }

        bool IsPrintOnly { get; set; }

        void AddBatchNumberToListBox(string batchNumbers);
        void ShowAnalystView();
        void ShowQAView();
        void ShowStudyDirectorView();
    }
}
