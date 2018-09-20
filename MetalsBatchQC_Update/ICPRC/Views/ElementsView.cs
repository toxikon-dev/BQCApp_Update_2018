using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.ICPRC.Interfaces;
using Toxikon.BatchQC.ICPRC.Controllers;

namespace Toxikon.BatchQC.ICPRC.Views
{
    public partial class ElementsView : UserControl, IElementsView
    {
        ElementsViewController controller;

        public ElementsView()
        {
            InitializeComponent();
        }

        public void SetController(ElementsViewController controller)
        {
            this.controller = controller;
        }

        public void AddInstrumentElementToView(string elementName)
        {
            this.InstrumentElementListView.Items.Add(elementName);
        }

        public void AddReportElementToView(string elementName)
        {
            this.ReportElementListView.Items.Add(elementName);
        }

        public void ClearView()
        {
            this.InstrumentElementListView.Items.Clear();
            this.ReportElementListView.Items.Clear();
        }

        public void ClearReportElementList()
        {
            this.ReportElementListView.Items.Clear();
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            this.controller.SelectAllButtonClicked();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.controller.RefreshButtonClicked();
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            Control sourceControl = this.ElementsContextMenuStrip.SourceControl;
            switch (sourceControl.Name)
            {
                case "ReportElementListView":
                    RemoveReportElement();
                    break;
                default:
                    break;
            }
        }

        private void RemoveReportElement()
        {
            if (this.ReportElementListView.SelectedIndices.Count != 0)
            {
                int selectedIndex = this.ReportElementListView.SelectedIndices[0];
                string value = this.ReportElementListView.SelectedItems[0].Text;
                this.ReportElementListView.Items.RemoveAt(selectedIndex);
                this.controller.RemoveSelectedElementFromReport(value);
            }
        }

        private void ReportElementListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.ElementsContextMenuStrip.Show(this.ReportElementListView, new Point(e.X, e.Y));
            }
        }

        private void InstrumentElementListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.InstrumentElementListView.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.InstrumentElementListView.SelectedIndices[0];
                this.controller.AddSelectedElementToReport(selectedIndex);
            }
        }
    }
}
