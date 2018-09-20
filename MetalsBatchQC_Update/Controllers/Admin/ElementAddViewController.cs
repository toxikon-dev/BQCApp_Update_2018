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
    public class ElementAddViewController
    {
        IElementAddView view;
        Element element;

        public ElementAddViewController(IElementAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            element = new Element();
        }

        public void SubmitButtonClicked()
        {
            try
            {   element.InstrumentID = view.InstrumentID;
                element.Symbol = view.Symbol;
                element.Name = view.ElementName;
                element.MassValue = Convert.ToDouble(view.MassValue);
                element.TrueValue = Convert.ToDouble(view.TrueValue);
                element.TrueValueUnit = view.TrueValueUnit;
                element.ReportingLimitValue = Convert.ToDouble(view.ReportingLimitValue);
                element.ReportingLimitUnit = view.ReportingLimitUnit;
               

                Int32 dbInsertResult = BQC_ADMIN_INSERT.InsertElement(element);

                MessageBox.Show("New element is added.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
