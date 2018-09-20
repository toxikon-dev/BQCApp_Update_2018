using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC.Controllers
{
    public class SampleController
    {
        ISampleView view;
        DataSheet dataSheet;
        BatchDetail batchDetail;
        Sample selectedSample;
        Int32 selectedSampleIndex;

        private const string G01 = "G01"; // this group is reserved for MB, LCS, LCSD samples;

        public SampleController(ISampleView view)
        {
            this.view = view;
            this.view.SetController(this);
            dataSheet = DataSheet.GetInstance();
            batchDetail = dataSheet.BatchDetail;
        }

        public void LoadView()
        {
            AddSamplesToListView();
        }

        private void AddSamplesToListView()
        {
            foreach(SampleGroup sampleGroup in dataSheet.SampleGroups)
            {
                foreach(Sample sample in sampleGroup.Samples)
                {
                    view.AddItemToListView(sample);
                }
            }
        }

        public void G01_AddSampleButtonClicked(string sampleName)
        {
            try
            {
                if(batchDetail.SampleType == "")
                {
                    ShowSampleTypeRequiredMessage();
                }
                else
                {
                    SampleGroup sampleGroup = GetG01();
                    Sample sample = new Sample(sampleName, sampleGroup);
                    if(sampleGroup.CheckSampleCodeExists(sample.SampleCode))
                    {
                        MessageBox.Show("Sample " + sample.SampleCode + " already exists. Please try Update instead.");
                    }
                    else
                    {
                        ShowSampleAddView(sample, sampleGroup);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private SampleGroup GetG01()
        {
            SampleGroup sampleGroup;
            if (dataSheet.HasGroupCode(G01))
            {
                sampleGroup = dataSheet.GetSampleGroup(G01);
            }
            else
            {
                sampleGroup = new SampleGroup(G01);
                dataSheet.AddSampleGroup(sampleGroup);
            }
            return sampleGroup;
        }

        private void ShowSampleAddView(Sample sample, SampleGroup sampleGroup)
        {
            SampleAddView subView = new SampleAddView();
            SampleAddController controller = new SampleAddController(subView, sample);
            controller.LoadView();
            DialogResult dialogResult = subView.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                sampleGroup.AddSample(sample);
                view.AddItemToListView(sample);
                Int32 dbInsertResult = BATCHQC_INSERT.InsertBatchSample(sample);
            }
            subView.Dispose();
        }

        public void AddSampleGroupButtonClicked()
        {
            try
            {
                if(this.batchDetail.SampleType == "")
                {
                    ShowSampleTypeRequiredMessage();
                }
                else
                {
                    if(dataSheet.Projects.Count == 0)
                    {
                        MessageBox.Show("Please add at least one project in Projects tab page.");
                    }
                    else
                    {
                        ShowSampleGroupAddView();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowSampleGroupAddView()
        {
            string groupCode = dataSheet.GetNewGroupCode();
            SampleGroupAddView subView = new SampleGroupAddView();
            SampleGroup sampleGroup = new SampleGroup(groupCode);
            SampleGroupAddController controller = new SampleGroupAddController(subView, sampleGroup);
            controller.LoadView();

            DialogResult dialogResult = subView.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                dataSheet.AddSampleGroup(sampleGroup);
                AddSampleGroupToView(sampleGroup);
            }
            subView.Dispose();
        }

        private void AddSampleGroupToView(SampleGroup sampleGroup)
        {
            for(int i = 0; i < sampleGroup.NumberOfSamples; i++)
            {
                Sample sample = new Sample(sampleGroup.ProjectNumber, sampleGroup);
                sampleGroup.AddSample(sample);
                view.AddItemToListView(sample);
                Int32 dbInsertResult = BATCHQC_INSERT.InsertBatchSample(sample);
            }
        }

        public void SampleListViewSelectedIndexChanged(ListViewItem item)
        {
            string groupCode = item.Text;
            string sampleCode = item.SubItems[1].Text;
            SampleGroup sampleGroup = dataSheet.GetSampleGroup(groupCode);
            this.selectedSample = sampleGroup.GetSample(sampleCode);
            this.selectedSampleIndex = item.Index;
        }

        public void UpdateButtonClicked()
        {
            try
            {
                if(this.selectedSample == null)
                {
                    MessageBox.Show("Please select a sample and try it again.");
                }
                else
                {
                    ShowSampleUpdateView();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowSampleTypeRequiredMessage()
        {
            MessageBox.Show("Sample type is required. Please go back to Batch Detail tab page.");
        }

        private void ShowSampleUpdateView()
        {
            SampleUpdateView updateView = new SampleUpdateView();
            SampleUpdateController updateController = new SampleUpdateController(updateView, this.selectedSample);
            updateController.LoadView();

            DialogResult dialogResult = updateView.ShowDialog(view.ParentControl);
            if(dialogResult == DialogResult.OK)
            {
                Int32 dbResult = BATCHQC_UPDATE.UpdateBatchSample(this.selectedSample);
                view.UpdateItemFromListView(this.selectedSample);
            }
            updateView.Dispose();
        }

        public void DeleteButtonClicked()
        {
            try
            {
                if (this.selectedSample == null)
                {
                    MessageBox.Show("Please select a sample and try it again.");
                }
                else
                {
                    ShowSampleDeleteView();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowSampleDeleteView()
        {
            SampleDeleteView subView = new SampleDeleteView();
            SampleDeleteViewController subViewController = new SampleDeleteViewController(subView, 
                                        this.selectedSample);
            subViewController.LoadView();
            DialogResult dialogResult = subView.ShowDialog(view.ParentControl);
            if(dialogResult == DialogResult.OK)
            {
                view.RemoveItemFromListViewAt(this.selectedSampleIndex);
            }
            subView.Dispose();
        }
    }
}
