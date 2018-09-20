using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Views.UserControls;
using Toxikon.BatchQC.Views.Results;
using Toxikon.BatchQC.Controllers.Results;

namespace Toxikon.BatchQC.Controllers
{
    public class DataSheetController
    {
        IDataSheetView _view;
        DataSheet dataSheet;

        public DataSheetController(IDataSheetView view)
        {
            _view = view;
            _view.IsBatchDetailViewLoaded = false;
            _view.IsProjectsViewLoaded = false;
            _view.IsSpikeSolutionViewLoaded = false;
            _view.IsReagentsViewLoaded = false;
            _view.IsUploadLCSResultLoaded = false;

            dataSheet = DataSheet.GetInstance();

            _view.SetController(this);
        }

        public void TabControlSelectedIndexChanged(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    LoadBatchDetailView();
                    break;
                case 1:
                    LoadProjectsView();
                    break;
                case 2:
                    LoadSpikeSolutionView();
                    break;
                case 3:
                    LoadReagentsView();
                    break;
                case 4:
                    LoadSampleView();
                    break;
                case 5:
                    LoadUploadResultView();
                    break;
                default:
                    break;
            }
        }

        public void LoadBatchDetailView()
        {
            if(!_view.IsBatchDetailViewLoaded)
            {
                BatchDetailView batchDetailView = new BatchDetailView();
                BatchDetailController batchDetailController = new BatchDetailController(batchDetailView);
                batchDetailController.LoadView();

                _view.AddToBatchDetailTabPage(batchDetailView);
                _view.IsBatchDetailViewLoaded = true;
            }
        }

        public void LoadProjectsView()
        {
            if(!_view.IsProjectsViewLoaded)
            {
                ProjectsView projectsView = new ProjectsView();
                ProjectsController projectsController = new ProjectsController(projectsView);
                projectsController.LoadView();

                _view.AddToProjectsTabPage(projectsView);
                _view.IsProjectsViewLoaded = true;
            }
        }

        public void LoadSpikeSolutionView()
        {
            if(!_view.IsSpikeSolutionViewLoaded)
            {
                SpikeSolutionView spikeSolutionView = new SpikeSolutionView();
                SpikeSolutionController spikeSolutionController = new SpikeSolutionController(spikeSolutionView);
                spikeSolutionController.LoadView();

                _view.AddToSpikeSolutionTabPage(spikeSolutionView);
                _view.IsSpikeSolutionViewLoaded = true;
            }
        }

        public void LoadReagentsView()
        {
            if(!_view.IsReagentsViewLoaded)
            {
                ReagentsView reagentsView = new ReagentsView();
                ReagentsController reagentsController = new ReagentsController(reagentsView);
                reagentsController.LoadView();

                _view.AddToReagentsTabPage(reagentsView);
                _view.IsReagentsViewLoaded = true;
            }
        }

        private void LoadSampleView()
        {
            if(!_view.IsSampleViewLoaded)
            {
                SampleView sampleView = new SampleView();
                SampleController controller = new SampleController(sampleView);
                controller.LoadView();

                _view.AddToSamplesTabPage(sampleView);
                _view.IsSampleViewLoaded = true;
            }
        }

        private void LoadUploadResultView()
        {
            if(!_view.IsUploadLCSResultLoaded)
            {
                UploadResultView subView = new UploadResultView();
                UploadResultViewController subviewController = new UploadResultViewController(subView);
                subviewController.LoadView();

                _view.AddToUploadLCSResultTabPage(subView);
                _view.IsUploadLCSResultLoaded = true;
            }
            else
            {
                _view.RefreshUploadResultView();
            }
        }
    }
}
