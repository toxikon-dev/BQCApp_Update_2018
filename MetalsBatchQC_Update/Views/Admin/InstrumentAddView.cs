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
    public partial class InstrumentAddView : UserControl, IInstrumentAddView
    {
        InstrumentAddViewController controller;

        public InstrumentAddView()
        {
            InitializeComponent();
        }

        public void SetController(InstrumentAddViewController controller)
        {
            this.controller = controller;
        }

        public string InstrumentID
        {
            get { return this.InstrumentIDTextBox.Text; }
            set { this.InstrumentIDTextBox.Text = value; }
        }

        public string InstrumentName
        {
            get { return this.InstrumentNameTextBox.Text; }
            set { this.InstrumentNameTextBox.Text = value; }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
