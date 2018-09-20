using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Interfaces
{
    public interface ISampleView
    {
        void SetController(SampleController controller);
        void AddItemToListView(Sample sample);
        void UpdateItemFromListView(Sample sample);
        void RemoveItemFromListViewAt(int itemIndex);

        Control ParentControl { get; }
    }
}
