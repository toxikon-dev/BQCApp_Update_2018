using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Controllers.Results;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces.Results
{
    public interface IUploadResultView
    {
        void SetController(UploadResultViewController controller);
        void AddElementToDataGrid(Element element);
        void ClearDataGrid();
        void ShowSubmitButton(bool value);
        void Refresh();

        string RunID { get; }
    }
}
