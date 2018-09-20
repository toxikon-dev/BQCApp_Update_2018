using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Interfaces;

namespace Toxikon.BatchQC.Views.UserControls
{
    public partial class ReagentsView : UserControl, IReagentsView
    {
        private ReagentsController _controller;
        public Control ParentControl { get; private set; }

        public ReagentsView()
        {
            InitializeComponent();
            ParentControl = this.Parent;
            this.reagentComboBox.ComboBox.DisplayMember = "ProductName";
        }

        public void SetController(ReagentsController controller)
        {
            _controller = controller;
        }

        public void ShowDeleteButton(bool value)
        {
            //this.DeleteButton.Visible = value;
        }

        public void AddReagentToListView(Reagent reagent)
        {
            ListViewItem item;
            item = this.reagentsListView.Items.Add(reagent.ItemCode);
            item.SubItems.Add(reagent.ProductName);
            item.SubItems.Add(reagent.Amount.ToString());
            item.SubItems.Add(reagent.Unit);
        }

        public void UpdateItemAmountFromListViewAt(int itemIndex, double amount)
        {
            ListViewItem item = this.reagentsListView.Items[itemIndex];
            item.SubItems[2].Text = amount.ToString();
        }

        public void RemoveItemFromListViewAt(int selectedIndex)
        {
            ListViewItem item = this.reagentsListView.Items[selectedIndex];
            this.reagentsListView.Items.Remove(item);
        }

        public void AddChemicalToComboBox(Chemical item)
        {
            this.reagentComboBox.Items.Add(item);
        }

        public void SetComboBoxSelectedIndex(int selectedIndex)
        {
            this.reagentComboBox.SelectedIndex = selectedIndex;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(this.reagentsListView.SelectedIndices.Count != 0)
            {
                int selectedIndex = this.reagentsListView.SelectedItems[0].Index;
                _controller.UpdateSelectedReagentAmount(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an item and try it again.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(this.reagentsListView.SelectedItems.Count != 0)
            {
                int selectedIndex = this.reagentsListView.SelectedItems[0].Index;
                _controller.RemoveSelectedReagent(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an item and try it again.");
            }
        }

        private void reagentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.ComboBoxSelectedIndexChange(this.reagentComboBox.SelectedIndex);
        }

        private void findCodeButton_Click(object sender, EventArgs e)
        {
            _controller.FindCodeButtonClicked();
        }
    }
}
