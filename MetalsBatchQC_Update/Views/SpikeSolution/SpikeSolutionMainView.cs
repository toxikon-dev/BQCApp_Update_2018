using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class SpikeSolutionMainView : UserControl, ISpikeSolutionMainView
    {
        SpikeSolutionMainViewController controller;

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public SpikeSolutionMainView()
        {
            InitializeComponent();
        }

        public void SetController(SpikeSolutionMainViewController controller)
        {
            this.controller = controller;
        }

        public void AddChemicalToListView(Chemical item)
        {
            ListViewItem listViewItem = this.SpikeSolutionListView.Items.Add(item.ProductCode);
            listViewItem.SubItems.Add(item.ProductName);
        }

        private void AddNewSpikeSolutionButton_Click(object sender, EventArgs e)
        {
            this.controller.AddNewSpikeSolutionButtonClicked();
        }
    }
}
