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
    public partial class SpikeSolutionView : UserControl, ISpikeSolutionView
    {
        SpikeSolutionController _controller;
        public Control ParentControl { get; private set; }
        public SimpleListItem ComboBoxSelectedItem { get; private set; }

        public SpikeSolutionView()
        {
            InitializeComponent();
            ParentControl = this.Parent;
            this.ChemicalComboBox.ComboBox.DisplayMember = "ProductName";
        }

        public void SetController(SpikeSolutionController controller)
        {
            _controller = controller;
        }

        public void ShowDeleteButton(bool value)
        {
            this.DeleteButton.Visible = value;
        }

        public void AddSpikeSolutionToListView(SpikeSolution listItem)
        {
            ListViewItem item;
            item = this.spikeSolutionListView.Items.Add(listItem.ItemCode);
            item.SubItems.Add(listItem.ProductName);
        }

        public void RemoveSelectedItemFromListView(int selectedIndex)
        {
            ListViewItem item = this.spikeSolutionListView.Items[selectedIndex];
            this.spikeSolutionListView.Items.Remove(item);
        }

        public void AddChemicalToComboBox(Chemical item)
        {
            this.ChemicalComboBox.Items.Add(item);
        }

        public void SetComboBoxSelectedIndex(int selectedIndex)
        {
            this.ChemicalComboBox.SelectedIndex = selectedIndex;
        }

        private void findCodeButton_Click(object sender, EventArgs e)
        {
            _controller.FindCodeButtonClicked();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.spikeSolutionListView.SelectedItems.Count != 0)
            {
                int selectedIndex = this.spikeSolutionListView.SelectedItems[0].Index;
                _controller.RemoveSelectedSpikeSolution(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an item and try it again.");
            }
        }

        private void ChemicalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._controller.ComboBoxSelectedIndexChange(this.ChemicalComboBox.SelectedIndex);
        }
    }
}
