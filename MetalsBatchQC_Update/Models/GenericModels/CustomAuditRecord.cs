using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.GenericModels
{
    public class CustomAuditRecord
    {
        public string TableName { get; set; }
        public string Type { get; set; }
        public string PK { get; set; }
        public string PKValue { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Reason { get; set; }

        public CustomAuditRecord()
        {
            this.TableName = "";
            this.Type = "";
            this.PK = "";
            this.PKValue = "";
            this.FieldName = "";
            this.OldValue = "";
            this.NewValue = "";
            this.UpdatedBy = "";
            this.UpdatedDate = DateTime.Now;
            this.Reason = "";
        }
    }
}
