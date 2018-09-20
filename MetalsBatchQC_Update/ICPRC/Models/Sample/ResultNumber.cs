using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public class ResultNumber
    {
        public static double Convert(double value, string fromUnit, string toUnit)
        {
            double result = value;
            if (fromUnit == Units.MG_PER_G && toUnit == Units.MG_PER_KG)
            {
                result = value * 1000;
            }
            else if (fromUnit == Units.MG_PER_L && toUnit == Units.MCG_PER_L)
            {
                result = value / 1000;
            }
            else if (fromUnit == Units.PPM && toUnit == Units.PPB)
            {
                result = value * 1000;
            }
            else if(fromUnit == Units.ML && toUnit == Units.L)
            {
                result = value / 1000;
            }
            else if (fromUnit == Units.MCG_PER_L && toUnit == Units.MCG_PER_G)
            {
                result = value / 1000;
            }
            return result;
        }
    }
}
