using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class SimpleListItem
    {
        public string ID { get; set; }
        public string Value { get; set; }

        public SimpleListItem()
        {
            this.ID = "";
            this.Value = "";
        }
    }
}
