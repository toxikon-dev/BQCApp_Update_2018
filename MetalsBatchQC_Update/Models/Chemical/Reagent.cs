using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Reagent : Chemical
    {
        public Int32 ItemID { get; set; }
        public string ItemCode { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }

        public Reagent()
        {
            ProductName = "N/A";
            ProductCode = "N/A";
            Amount = 0.0;
            Unit = "N/A";
            ItemCode = "N/A";
        }

        public Reagent(Chemical item)
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
            Amount = 0.0;
            Unit = Units.ML;
        }
    }
}
