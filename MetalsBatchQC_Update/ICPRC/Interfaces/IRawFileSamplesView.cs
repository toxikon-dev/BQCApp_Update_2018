using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IRawFileSamplesView
    {
        void SetController(RawFileSamplesViewController controller);

        void AddSampleNameToRawFileSamplesList(string sampleName);
        void ClearRawFileSamplesList();

        void AddSampleNameToReportSamplesList(string sampleName);
        void ClearReportSamplesList();
    }
}
