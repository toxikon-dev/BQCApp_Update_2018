using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Reports
{
    public class ChartSeriesProperties
    {
        public string RangeName { get; private set; }
        public string SeriesName { get; set; }
        public string XValuesRangeName { get; private set; }

        public ChartSeriesProperties()
        {

        }

        public void SetRangeName(string columnName, int startRowIndex, int lastRowIndex)
        {
            this.RangeName = columnName + startRowIndex + ":" +
                             columnName + lastRowIndex;
        }

        public void SetXValuesRangeName(string columnName, int startRowIndex, int lastRowIndex)
        {
            this.XValuesRangeName = columnName + startRowIndex + ":" +
                             columnName + lastRowIndex;
        }
    }
}
