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

namespace Toxikon.BatchQC.Controllers
{
    public class SampleGroupAddController
    {
        ISampleGroupAddView view;
        IList projectNumbers;
        DataSheet dataSheet;
        SampleGroup sampleGroup;
        BatchDetail batchDetail;

        public SampleGroupAddController(ISampleGroupAddView view, SampleGroup sampleGroup)
        {
            this.view = view;
            this.view.SetController(this);
            this.sampleGroup = sampleGroup;
            projectNumbers = new ArrayList();
            dataSheet = DataSheet.GetInstance();
            batchDetail = dataSheet.BatchDetail;
        }

        public void LoadView()
        {
            SetProjectNumbers();
            AddProjectNumbersToComboBox();
            view.GroupCode = sampleGroup.GroupCode;
            view.SampleUnit = sampleGroup.SampleUnit;
            view.InitialDigestionUnit = sampleGroup.InitialDigestionUnit;
            view.FinalUnit = sampleGroup.FinalUnit;
        }

        private void SetProjectNumbers()
        {
            projectNumbers.Clear();
            IList projects = dataSheet.Projects;
            foreach(Project project in projects)
            {
                projectNumbers.Add(project.ProjectNumber);
            }
        }

        private void AddProjectNumbersToComboBox()
        {
            foreach(string projectNumber in projectNumbers)
            {
                view.AddItemToComboBox(projectNumber);
            }
            view.SetComboBoxSelectedIndex(0);
        }

        public void AddButtonClicked()
        {
            if(IsNumber(view.NumberOfSamples))
            {
                UpdateSampleGroup();
                view.SetDialogResult(DialogResult.OK);
            }
            else
            {
                ShowInvalidValueMessage("Invalid Number of Samples.");
            }
        }

        private void UpdateSampleGroup()
        {
            sampleGroup.ProjectNumber = view.ProjectNumber;

            UpdateSampleGroupSampleAmount();
            UpdateSampleGroupInitialDigestionAmount();
            UpdateSampleGroupFinalAmount();

            sampleGroup.Description = view.Description;
            sampleGroup.NumberOfSamples = Convert.ToInt32(view.NumberOfSamples);
        }

        private void UpdateSampleGroupSampleAmount()
        {
            if (IsNumber(view.SampleAmount))
            {
                sampleGroup.SampleAmount = Convert.ToDouble(view.SampleAmount);
            }
            else
            {
                sampleGroup.SampleAmount = 0;
            }
        }

        private void UpdateSampleGroupInitialDigestionAmount()
        {
            if (IsNumber(view.InitialDigestionAmount))
            {
                sampleGroup.InitialDigestionAmount = Convert.ToDouble(view.InitialDigestionAmount);
            }
            else
            {
                sampleGroup.InitialDigestionAmount = 0;
            }
        }

        private void UpdateSampleGroupFinalAmount()
        {
            if (IsNumber(view.FinalAmount))
            {
                sampleGroup.FinalAmount = Convert.ToDouble(view.FinalAmount);
            }
            else
            {
                sampleGroup.FinalAmount = 0;
            }
        }

        private bool IsNumber(string input)
        {
            bool result = true;
            double number = 0;
            if(!Double.TryParse(input, out number))
            {
                result = false;
            }
            return result;
        }

        private void ShowInvalidValueMessage(string message)
        {
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                view.SetDialogResult(DialogResult.Retry);
            }
        }
    }
}
