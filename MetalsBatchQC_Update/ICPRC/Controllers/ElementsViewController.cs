using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Controllers
{
    public class ElementsViewController
    {
        IElementsView view;
        Report report;

        public ElementsViewController(IElementsView view)
        {
            this.view = view;
            this.view.SetController(this);
            report = Report.GetInstance();
        }

        public void LoadView()
        {
            LoadElements();
        }

        private void LoadElements()
        {
            foreach (Element element in report.Elements)
            {
                element.IsActive = false;
                view.AddInstrumentElementToView(element.Name);
            }
        }

        public void AddSelectedElementToReport(int selectedIndex)
        {
            Element element = (Element)report.Elements[selectedIndex];
            if(!element.IsActive)
            {
                element.IsActive = true;
                view.AddReportElementToView(element.Name);
            }
        }

        public void RemoveSelectedElementFromReport(string elementName)
        {
            foreach(Element element in report.Elements)
            {
                if(element.Name == elementName)
                {
                    element.IsActive = false;
                    break;
                }
            }
        }

        public void SelectAllButtonClicked()
        {
            view.ClearReportElementList();
            for(int i = 0; i < report.Elements.Count; i++ )
            {
                this.AddSelectedElementToReport(i);
            }
        }

        public void RefreshButtonClicked()
        {
            view.ClearView();
            LoadElements();
        }
    }
}
