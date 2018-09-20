using Toxikon.BatchQC.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Views.Forms;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class ReagentsController
    {
        LoginInfo loginInfo;
        IReagentsView _view;
        DataSheet dataSheet;
        IList comboBoxItems;
        int comboBoxSelectedIndex;

        public ReagentsController(IReagentsView view)
        {
            _view = view;
            _view.SetController(this);

            dataSheet = DataSheet.GetInstance();
            comboBoxItems = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            if(loginInfo.RoleID != 1)
            {
                this._view.ShowDeleteButton(false);
            }
            LoadComboBoxItems();
            UpdateComboBoxDataSource();
            UpdateListViewDataSource();
            _view.SetComboBoxSelectedIndex(0);
        }

        public void UpdateComboBoxDataSource()
        {
            foreach(Chemical item in comboBoxItems)
            {
                _view.AddChemicalToComboBox(item);
            }
        }

        private void UpdateListViewDataSource()
        {
            foreach (Reagent reagent in dataSheet.Reagents)
            {
                _view.AddReagentToListView(reagent);
            }
        }

        private void LoadComboBoxItems()
        {
            try
            {
                IList results = BATCHQC_SELECT.SelectAllActiveReagents();
                foreach(Chemical item in results)
                {
                    comboBoxItems.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            comboBoxSelectedIndex = 0;
        }

        public void ComboBoxSelectedIndexChange(int selectedIndex)
        {
            comboBoxSelectedIndex = selectedIndex;
        }

        public void FindCodeButtonClicked()
        {
            try
            {
                ReagentOptionsView optionsView = new ReagentOptionsView();
                optionsView.Parent = _view.ParentControl;
                optionsView.StartPosition = FormStartPosition.CenterParent;
                Chemical selectedItem = (Chemical)this.comboBoxItems[comboBoxSelectedIndex];
                IList items = LIMS_Queries.GetChemicalList(selectedItem.ProductCode);
                ReagentOptionsController controller = new ReagentOptionsController(optionsView, items);
                controller.LoadView();

                DialogResult dialogResult = optionsView.ShowDialog(_view.ParentControl);
                if (dialogResult == DialogResult.OK)
                {
                    Reagent reagent = new Reagent(selectedItem);
                    reagent.ItemCode = controller.ItemCode;
                    reagent.Amount = controller.AmountValue;
                    reagent.ItemID = BATCHQC_INSERT.InsertBatchReagent(reagent);

                    dataSheet.AddReagent(reagent);
                    _view.AddReagentToListView(reagent);
                }
                optionsView.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void UpdateSelectedReagentAmount(int selectedIndex)
        {
            try
            {
                Reagent selectedReagent = (Reagent)dataSheet.Reagents[selectedIndex];
                ReagentUpdateView updateView = new ReagentUpdateView();
                ReagentUpdateController controller = new ReagentUpdateController(updateView, selectedReagent);
                controller.LoadView();
                DialogResult dialogResult = updateView.ShowDialog(_view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    selectedReagent.Amount = controller.NewAmountValue;
                    Int32 dbResult = BATCHQC_UPDATE.UpdateBatchReagent(selectedReagent);
                    _view.UpdateItemAmountFromListViewAt(selectedIndex, controller.NewAmountValue);
                }
                updateView.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void RemoveSelectedReagent(int selectedIndex)
        {
            try
            {
                Reagent selectedReagent = (Reagent)dataSheet.Reagents[selectedIndex];
                ReagentDeleteView deleteView = new ReagentDeleteView();
                ReagentDeleteController controller = new ReagentDeleteController(deleteView, selectedReagent);
                controller.LoadView();

                DialogResult dialogResult = deleteView.ShowDialog(_view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    dataSheet.RemoveReagentAt(selectedIndex);
                    _view.RemoveItemFromListViewAt(selectedIndex);
                }
                deleteView.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
