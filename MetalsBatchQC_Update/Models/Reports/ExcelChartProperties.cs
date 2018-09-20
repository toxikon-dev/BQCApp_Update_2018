using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Reports
{
    public class ExcelChartProperties
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public XlChartType ChartType { get; set; }
        public int ChartStyle { get; set; }
        public int ChartColor { get; set; }
        public Range XValuesRange { get; set; }
        public Dictionary<string, ChartSeriesProperties> ChartSeriesPropDictionary { get; private set; }

        public ExcelChartProperties()
        {
            this.Top = 100;
            this.Left = 100;
            this.Width = 600;
            this.Height = 800;
            this.ChartType = XlChartType.xlLineMarkers;
            this.ChartStyle = 232;
            this.ChartColor = 10;
            ChartSeriesPropDictionary = new Dictionary<string, ChartSeriesProperties>() { };
        }

        public void AddNewSeriesProperties(ChartSeriesProperties seriesProp)
        {
            this.ChartSeriesPropDictionary.Add(seriesProp.RangeName, seriesProp);
        }
    }
}
