using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Views.UserControls;
using Toxikon.BatchQC.Views.Results;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IDataSheetView
    {
        void SetController(DataSheetController controller);
        void AddToBatchDetailTabPage(BatchDetailView view);
        void AddToProjectsTabPage(ProjectsView view);
        void AddToSpikeSolutionTabPage(SpikeSolutionView view);
        void AddToReagentsTabPage(ReagentsView view);
        void AddToSamplesTabPage(SampleView view);
        void AddToUploadLCSResultTabPage(UploadResultView view);
        void RefreshUploadResultView();

        bool IsBatchDetailViewLoaded { get; set; }
        bool IsProjectsViewLoaded { get; set; }
        bool IsSpikeSolutionViewLoaded { get; set; }
        bool IsReagentsViewLoaded { get; set; }
        bool IsSampleViewLoaded { get; set; }
        bool IsUploadLCSResultLoaded { get; set; }
    }
}
