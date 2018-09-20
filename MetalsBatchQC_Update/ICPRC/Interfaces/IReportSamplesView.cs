using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Controllers;
using Toxikon.BatchQC.ICPRC.Models;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IReportSamplesView
    {
        void SetController(ReportSamplesViewController controller);

        void AddBatchSampleToView(BatchSample sample);
        void ClearBatchSampleList();

        void SetRawFileSampleComboBox(IList items);
    }
}
