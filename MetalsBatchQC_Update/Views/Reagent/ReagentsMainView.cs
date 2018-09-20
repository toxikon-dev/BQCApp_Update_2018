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
    public partial class ReagentsMainView : UserControl, IReagentsMainView
    {
        ReagentsMainViewController controller;

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public ReagentsMainView()
        {
            InitializeComponent();
        }

        public void SetController(ReagentsMainViewController controller)
        {
            this.controller = controller;
        }

        public void AddChemicalToListView(Chemical chemical)
        {
            ListViewItem item = this.ReagentListView.Items.Add(chemical.ProductCode);
            item.SubItems.Add(chemical.ProductName);
        }

        private void AddNewReagentButton_Click(object sender, EventArgs e)
        {
            this.controller.AddNewReagentButtonClicked();
        }
    }
}
