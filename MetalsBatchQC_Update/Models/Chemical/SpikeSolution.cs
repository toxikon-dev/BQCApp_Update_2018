using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class SpikeSolution : Chemical
    {
        public Int32 ItemID { get; set; }
        public string ItemCode { get; set; }
        
        public SpikeSolution()
        {
            ItemCode = "";
        }

        public SpikeSolution(Chemical item)
        {
            this.ProductCode = item.ProductCode;
            this.ProductName = item.ProductName;
            this.TypeNumber = item.TypeNumber;
            this.TypeName = item.TypeName;
            this.CreatedBy = item.CreatedBy;
            this.CreatedDate = item.CreatedDate;
            this.UpdatedBy = item.UpdatedBy;
            this.UpdatedDate = item.UpdatedDate;
            this.ItemCode = "";
        }
    }
}
