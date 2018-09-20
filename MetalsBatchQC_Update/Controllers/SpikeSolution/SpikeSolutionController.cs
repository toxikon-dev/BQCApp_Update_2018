using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Views.Forms;
using System.Data.SqlClient;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class SpikeSolutionController
    {
        ISpikeSolutionView _view;
        DataSheet dataSheet;
        IList comboBoxItems;
        int comboBoxSelectedIndex;

        public SpikeSolutionController(ISpikeSolutionView view)
        {
            _view = view;
            _view.SetController(this);
            dataSheet = DataSheet.GetInstance();
            comboBoxItems = new ArrayList();
        }

        public void LoadView()
        {
            HideDeleteButton();
            LoadComboBoxItems();
            UpdateComboBoxWithValues();
            _view.SetComboBoxSelectedIndex(0);
            UpdateListViewWithValues();
        }

        private void HideDeleteButton()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            if (loginInfo.RoleID != 1)
            {
                this._view.ShowDeleteButton(false);
            }
        }

        private void LoadComboBoxItems()
        {
            try
            {
                IList results = BATCHQC_SELECT.SelectAllActiveSpikeSolution();
                foreach(Chemical item in results)
                {
                    comboBoxItems.Add(item);
                }
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UpdateListViewWithValues()
        {
            foreach (SpikeSolution item in dataSheet.SpikeSolutions)
            {
                _view.AddSpikeSolutionToListView(item);
            }
        }

        private void UpdateComboBoxWithValues()
        {
            foreach (Chemical item in comboBoxItems)
            {
                _view.AddChemicalToComboBox(item);
            }
        }

        public void ComboBoxSelectedIndexChange(int selectedIndex)
        {
            comboBoxSelectedIndex = selectedIndex;
        }

        public void FindCodeButtonClicked()
        {
            try
            {
                SpikeSolutionOptionsView view = new SpikeSolutionOptionsView();
                Chemical selectedItem = (Chemical)this.comboBoxItems[comboBoxSelectedIndex];
                IList optionList = LIMS_Queries.GetChemicalList(selectedItem.ProductCode);
                SpikeSolutionOptionsController controller = new SpikeSolutionOptionsController(view, optionList);
                controller.LoadView();

                DialogResult dialogResult = view.ShowDialog(_view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    SpikeSolution item = new SpikeSolution(selectedItem);
                    item.ItemCode = controller.ItemCode;
                    item.ItemID = BATCHQC_INSERT.InsertBatchSpikeSolution(item);

                    dataSheet.AddSpikeSolution(item);
                    _view.AddSpikeSolutionToListView(item);
                }
                view.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void RemoveSelectedSpikeSolution(int selectedIndex)
        {
            try
            {
                SpikeSolution selectedSpikeSolution = dataSheet.GetSpikeSolutionAt(selectedIndex);
                SpikeSolutionDeleteView view = new SpikeSolutionDeleteView();
                SpikeSolutionDeleteController controller = 
                                    new SpikeSolutionDeleteController(view, selectedSpikeSolution);
                controller.LoadView();

                DialogResult dialogResult = view.ShowDialog(_view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    dataSheet.RemoveSpikeSolutionAt(selectedIndex);
                    _view.RemoveSelectedItemFromListView(selectedIndex);
                }
                view.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
