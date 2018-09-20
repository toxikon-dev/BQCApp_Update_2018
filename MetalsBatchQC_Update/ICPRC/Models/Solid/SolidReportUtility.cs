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
    public static class SolidReportUtility
    {
        public static IList CreateSolidSamples(IList<Element> elements, IList sampleResults)
        {
            IList result = new ArrayList();
            foreach (SampleResult sampleResult in sampleResults)
            {
                if (sampleResult.GroupCode != "G01")
                {
                    SolidSample sample = new SolidSample(sampleResult, elements);
                    result.Add(sample);
                }
            }
            return result;
        }

        public static IList CreateDataGridViews(IList solidSampleList)
        {
            IList result = new ArrayList();
            foreach (SolidSample sample in solidSampleList)
            {
                SolidDataGridView grid = new SolidDataGridView();
                grid.CreateGridForSample(sample);
                result.Add(grid);
            }
            return result;
        }

        public static IList ConvertToDataTables(IList dataGridViewList)
        {
            IList results = new ArrayList();
            foreach (SolidDataGridView grid in dataGridViewList)
            {
                results.Add(grid.GetCurrentDataTable());
            }
            return results;
        }
    }
}
