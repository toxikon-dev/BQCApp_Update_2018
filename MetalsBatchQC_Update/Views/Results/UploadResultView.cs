using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces.Results;
using Toxikon.BatchQC.Controllers.Results;
using Toxikon.BatchQC.Models;
using System.Diagnostics;

namespace Toxikon.BatchQC.Views.Results
{
    public partial class UploadResultView : UserControl, IUploadResultView
    {
        UploadResultViewController controller;
        public string RunID { get; private set; }

        public UploadResultView()
        {
            InitializeComponent();
        }

        public void SetController(UploadResultViewController controller)
        {
            this.controller = controller;
        }

        public void RefreshView()
        {
            this.controller.RefreshView();
        }

        public void ShowSubmitButton(bool value)
        {
            this.SubmitButton.Enabled = value;
        }

        public void AddElementToDataGrid(Element element)
        {
            this.ElementDataGridView.Rows.Add(element.RunID, element.InstrumentID, element.Symbol, 
                element.ResultValue, element.ResultUnit);
        }

        public void ClearDataGrid()
        {
            this.ElementDataGridView.Rows.Clear();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                RunID = openFileDialog.FileName;
                controller.BrowseButtonClicked(openFileDialog.FileName);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

    }
}
