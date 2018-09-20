using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Controllers
{
    public class SpikeSolutionAddController
    {
        ISpikeSolutionAddView view;
        List<Chemical> searchResults;
        Chemical selectedItem;
        LoginInfo loginInfo;

        public SpikeSolutionAddController(ISpikeSolutionAddView view)
        {
            this.view = view;
            view.SelectedItemIndex = -1;
            view.SetController(this);

            loginInfo = LoginInfo.GetInstance();
        }

        public void SearchButtonClicked(string searchString)
        {
            try
            {
                GetSearchResults(searchString);
                UpdateViewWithSearchResults();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetSearchResults(string searchString)
        {
            searchResults = new List<Chemical>() { };
            IList dbResults = LIMS_Queries.GetResultsFromSearchItemByName(searchString);
            foreach(Chemical item in dbResults)
            {
                searchResults.Add(item);
            }
        }

        private void UpdateViewWithSearchResults()
        {
            view.ClearListView();
            foreach(Chemical item in searchResults)
            {
                view.AddItemToListView(item);
            }
        }

        public void ListViewSelectedIndexChanged()
        {
            this.selectedItem = searchResults[view.SelectedItemIndex];
        }

        public void AddButtonClicked()
        {
            try
            {
                if (IsValidSelectedItemIndex())
                {
                    bool productCodeExists = BATCHQC_SELECT.CheckSpikeSolutionExists(this.selectedItem.ProductCode);
                    if (!productCodeExists)
                    {
                        InsertNewSpikeSolution();
                    }
                    else
                    {
                        MessageBox.Show("Spike solution " + this.selectedItem.ProductCode + " already exists.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select one name.");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool IsValidSelectedItemIndex()
        {
            bool result = true;
            if (view.SelectedItemIndex == -1)
            {
                result = false;
            }
            return result;
        }

        private void InsertNewSpikeSolution()
        {
            Int32 result = BATCHQC_INSERT.InsertSpikeSolution(this.selectedItem);
            view.SelectedItemIndex = -1;
            view.ClearView();
            MessageBox.Show("New spike solution is added.");
        }
    }
}
