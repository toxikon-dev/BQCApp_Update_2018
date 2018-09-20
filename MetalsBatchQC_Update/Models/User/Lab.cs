using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Lab
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PrimaryLocation { get; set; }
        public string SecondaryLocation { get; set; }
        public string TertiaryLocation { get; set; }

        public Lab()
        {
            this.ID = "ME";
            this.Name = "ME";
            this.PrimaryLocation = "15 Wiggins";
            this.SecondaryLocation = "605-ANALYTICAL CHEMISTRY";
            this.TertiaryLocation = "ME";
        }
    }
}
