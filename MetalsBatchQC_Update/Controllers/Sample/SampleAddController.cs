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
    public class SampleAddController
    {
        ISampleAddView view;
        Sample sample;

        public SampleAddController(ISampleAddView view, Sample sample)
        {
            this.view = view;
            this.sample = sample;

            view.SetController(this);
        }

        public void LoadView()
        {
            view.GroupCode = sample.GroupCode;
            view.SampleCode = sample.SampleCode;
            view.SampleUnit = sample.SampleUnit;
            view.InitialDigestionUnit = sample.InitialDigestionUnit;
            view.FinalUnit = sample.FinalUnit;
        }

        public void AddButtonClicked()
        {
            UpdateSample();
            view.SetDialogResult(DialogResult.OK);
        }

        private void UpdateSample()
        {
            UpdateSampleAmount();
            UpdateInitialDigestionAmount();
            UpdateSampleFinalAmount();
            sample.Description = view.Description;
        }

        private void UpdateSampleAmount()
        {
            if (IsNumber(view.SampleAmount))
            {
                sample.SampleAmount = Convert.ToDouble(view.SampleAmount);
            }
            else
            {
                sample.SampleAmount = 0;
            }
        }

        private void UpdateInitialDigestionAmount()
        {
            if (IsNumber(view.InitialDigestionAmount))
            {
                sample.InitialDigestionAmount = Convert.ToDouble(view.InitialDigestionAmount);
            }
            else
            {
                sample.InitialDigestionAmount = 0;
            }
        }

        private void UpdateSampleFinalAmount()
        {
            if (IsNumber(view.FinalAmount))
            {
                sample.FinalAmount = Convert.ToDouble(view.FinalAmount);
            }
            else
            {
                sample.FinalAmount = 0;
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
