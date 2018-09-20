using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Admin;
using Toxikon.BatchQC.Controllers.Admin;

namespace Toxikon.BatchQC.Views.Admin
{
    public partial class ElementAddView : UserControl, IElementAddView
    {
        ElementAddViewController controller;

        public ElementAddView()
        {
            InitializeComponent();
        }

        public void SetController(ElementAddViewController controller)
        {
            this.controller = controller;
        }

        public string Symbol 
        {
            get { return this.SymbolTextBox.Text; }
            set { this.SymbolTextBox.Text = value; }
        }
        public string ElementName 
        {
            get { return this.NameTextBox.Text; }
            set { this.NameTextBox.Text = value; }
        }
        public string MassValue 
        {
            get { return this.MassValueTextBox.Text; }
            set { this.MassValueTextBox.Text = value; }
        }
        public string TrueValue 
        {
            get { return this.TrueValueTextBox.Text; }
            set { this.TrueValueTextBox.Text = value; }
        }
        public string TrueValueUnit 
        {
            get { return this.TrueValueUnitTextBox.Text; }
            set { this.TrueValueUnitTextBox.Text = value; }
        }
        public string ReportingLimitValue 
        {
            get { return this.RLVTextBox.Text; }
            set { this.RLVTextBox.Text = value; }
        }
        public string ReportingLimitUnit 
        {
            get { return this.RLUTextBox.Text; }
            set { this.RLUTextBox.Text = value; }
        }
        public string InstrumentID 
        {
            get { return this.InstrumentIDTextBox.Text; }
            set { this.InstrumentIDTextBox.Text = value; }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
