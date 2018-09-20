using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers.Admin
{
    public class InstrumentAddViewController
    {
        IInstrumentAddView view;
        Instrument instrument;

        public InstrumentAddViewController(IInstrumentAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            instrument = new Instrument();
        }

        public void SubmitButtonClicked()
        {
            try
            {
                this.instrument.ID = view.InstrumentID;
                this.instrument.Name = view.InstrumentName;
                Int32 dbInsertResult = BQC_ADMIN_INSERT.InsertInstrument(instrument);
                MessageBox.Show("New instrument is added.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
