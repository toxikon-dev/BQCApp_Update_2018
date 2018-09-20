using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Interfaces;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.Controllers
{
    public class SampleUpdateController
    {
        ISampleUpdateView view;
        Sample selectedSample;

        public SampleUpdateController(ISampleUpdateView view, Sample sample)
        {
            this.view = view;
            this.view.SetController(this);
            this.selectedSample = sample;
        }

        public void LoadView()
        {
            view.SampleCode = selectedSample.SampleCode;

            view.SampleAmount = selectedSample.SampleAmount.ToString();
            view.SampleUnit = selectedSample.SampleUnit;

            view.InitialDigestionAmount = selectedSample.InitialDigestionAmount.ToString();
            view.InitialDigestionUnit = selectedSample.InitialDigestionUnit;

            view.FinalAmount = selectedSample.FinalAmount.ToString();
            view.FinalUnit = selectedSample.FinalUnit;

            view.Description = selectedSample.Description;
            view.Comment = selectedSample.Comment;
        }

        public void UpdateButtonClicked()
        {
            UpdateSample();
            view.SetDialogResult(DialogResult.OK);
        }

        private void UpdateSample()
        {
            UpdateSampleAmount();
            UpdateInitialDigestionAmount();
            UpdateSampleFinalAmount();
            selectedSample.Description = view.Description;
            selectedSample.Comment = view.Comment;
        }

        private void UpdateSampleAmount()
        {
            if (IsNumber(view.SampleAmount))
            {
                selectedSample.SampleAmount = Convert.ToDouble(view.SampleAmount);
            }
            else
            {
                selectedSample.SampleAmount = 0;
            }
        }

        private void UpdateInitialDigestionAmount()
        {
            if (IsNumber(view.InitialDigestionAmount))
            {
                selectedSample.InitialDigestionAmount = Convert.ToDouble(view.InitialDigestionAmount);
            }
            else
            {
                selectedSample.InitialDigestionAmount = 0;
            }
        }

        private void UpdateSampleFinalAmount()
        {
            if (IsNumber(view.FinalAmount))
            {
                selectedSample.FinalAmount = Convert.ToDouble(view.FinalAmount);
            }
            else
            {
                selectedSample.FinalAmount = 0;
            }
        }

        private bool IsNumber(string input)
        {
            bool result = true;
            double number = 0;
            if (!Double.TryParse(input, out number))
            {
                result = false;
            }
            return result;
        }
    }
}
