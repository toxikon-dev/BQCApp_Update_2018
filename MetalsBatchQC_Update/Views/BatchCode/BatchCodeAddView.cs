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
    public partial class BatchCodeAddView : UserControl, IBatchCodeAddView
    {
        BatchCodeAddController controller;
        public Control ParentControl 
        {
            get { return this.ParentForm; }
        }

        public BatchCodeAddView()
        {
            InitializeComponent();
            this.MethodCodeComboBox.DisplayMember = "Code";
        }

        public void SetController(BatchCodeAddController controller)
        {
            this.controller = controller;
        }

        public void AddMethodCodeToComboBox(MethodCode item)
        {
            this.MethodCodeComboBox.Items.Add(item);
        }
        public void SetMethodCodeComboBoxSelectedIndex(int index)
        {
            this.MethodCodeComboBox.SelectedIndex = index;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void MethodCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.MethodCodeComboBoxSelectedIndexChanged(this.MethodCodeComboBox.SelectedIndex);
        }
    }
}
