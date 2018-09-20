﻿using System;
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
    public partial class ReagentAddView : UserControl, IReagentAddView
    {
        ReagentAddController controller;
        public int SelectedItemIndex { get; set; }
        public Control ParentControl { get; private set; }

        public ReagentAddView()
        {
            InitializeComponent();
            this.ParentControl = this.Parent;
        }

        public void SetController(ReagentAddController controller)
        {
            this.controller = controller;
        }

        public void ClearView()
        {
            this.searchTextBox.Text = "";
            this.resultsListView.Items.Clear();
        }

        public void ClearListView()
        {
            this.resultsListView.Items.Clear();
        }

        public void AddItemToListView(Chemical item)
        {
            ListViewItem listViewItem = this.resultsListView.Items.Add(item.ProductCode);
            listViewItem.SubItems.Add(item.ProductName);
            listViewItem.SubItems.Add(item.TypeName);
            listViewItem.SubItems.Add(item.CreatedBy);
            listViewItem.SubItems.Add(item.CreatedDate);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (this.searchTextBox.Text.Trim() != "")
            {
                controller.SearchButtonClicked(this.searchTextBox.Text);
            }
            else
            {
                MessageBox.Show("Name is required.");
            }
        }

        private void resultsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.resultsListView.SelectedIndices.Count != 0)
            {
                SelectedItemIndex = this.resultsListView.SelectedItems[0].Index;
                controller.ListViewSelectedIndexChanged();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            controller.AddButtonClicked();
        }
    }
}
