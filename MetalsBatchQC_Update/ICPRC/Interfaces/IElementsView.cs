using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Interfaces
{
    public interface IElementsView
    {
        void SetController(ElementsViewController controller);

        void AddInstrumentElementToView(string elementName);
        void AddReportElementToView(string elementName);
        void ClearReportElementList();

        void ClearView();
    }
}
