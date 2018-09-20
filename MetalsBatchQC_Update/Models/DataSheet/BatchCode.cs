using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class BatchCode
    {
        public Int32 ID { get; set; }
        public string FullCode { get; set; }
        public string MethodCode { get; set; }
        public Int32 SequenceNumber { get; set; }
        public string DepartmentCode { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }

        public BatchCode()
        {
            this.ID = 0;
            this.FullCode = "";
        }

        public BatchCode(BatchCode bc)
        {
            this.ID = bc.ID;
            this.FullCode = bc.FullCode;
            this.MethodCode = bc.MethodCode;
            this.SequenceNumber = bc.SequenceNumber;
            this.DepartmentCode = bc.DepartmentCode;
        }

        public void SetFullCode()
        {
            String yearMonth = DateTime.Now.ToString("yyMM");
            this.FullCode = "BQC" + this.MethodCode + yearMonth + this.SequenceNumber.ToString("000") + 
                            this.DepartmentCode;
        }
    }
}
