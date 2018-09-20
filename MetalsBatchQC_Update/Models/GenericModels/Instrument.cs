using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Instrument
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Instrument()
        {
            this.ID = "";
            this.Name = "";
        }
        
        public Instrument(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
