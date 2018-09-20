using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Models
{
    public static class LiquidReportUtility
    {
        public static IList CreateLiquidSamples(IList<Element> elements, IList sampleResults)
        {
            IList result = new ArrayList();
            int index = -1;
            foreach (SampleResult sampleResult in sampleResults)
            {
                index += 1;
                if (sampleResult.GroupCode != "G01")
                {
                    LiquidSample sample = new LiquidSample(index, sampleResult, elements);
                    result.Add(sample);
                }
            }
            return result;
        }

        public static void SetControlCorrectedResult(IList liquidSampleList)
        {
            if (liquidSampleList.Count > 0)
            {
                LiquidSample control = (LiquidSample)liquidSampleList[0];
                for (int i = 1; i < liquidSampleList.Count; i++)
                {
                    LiquidSample sample = (LiquidSample)liquidSampleList[i];
                    sample.SetControlCorrectedResult(control);
                }
            }
        }

        public static IList CreateDataGridViews(IList liquidSampleList)
        {
            IList result = new ArrayList();
            foreach (LiquidSample sample in liquidSampleList)
            {
                LiquidDataGridView grid = new LiquidDataGridView();
                grid.CreateGridForSample(sample);
                result.Add(grid);
            }
            return result;
        }

        public static IList ConvertToDataTables(IList dataGridViewList)
        {
            IList results = new ArrayList();
            foreach (LiquidDataGridView grid in dataGridViewList)
            {
                results.Add(grid.GetCurrentDataTable());
            }
            return results;
        }
    }
}
