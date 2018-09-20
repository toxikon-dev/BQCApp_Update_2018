using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Sample
    {
        public string GroupCode { get; set; }
        public string SampleCode { get; set; }
        public string SampleType { get; set; }
        public int SampleIndex { get; set; }
        public string ProjectNumber { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public double SampleAmount { get; set; }
        public string SampleUnit { get; set; }
        public double InitialDigestionAmount { get; set; }
        public string InitialDigestionUnit { get; set; }
        public double FinalAmount { get; set; }
        public string FinalUnit { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public Sample()
        {
            SampleCode = "";
            Description = "";
            Comment = "";

            SampleAmount = 0;
            InitialDigestionAmount = 0;
            FinalAmount = 0;

            SampleUnit = Units.ML;
            InitialDigestionUnit = Units.ML;
            FinalUnit = Units.ML;
        }

        public Sample(string sampleName, SampleGroup sampleGroup)
        {
            this.GroupCode = sampleGroup.GroupCode;
            this.ProjectNumber = sampleGroup.ProjectNumber;
            this.SampleIndex = sampleGroup.Samples.Count;
            this.SampleType = sampleGroup.SampleType;

            SetSampleCode(sampleName);

            this.SampleAmount = sampleGroup.SampleAmount;
            this.SampleUnit = sampleGroup.SampleUnit;

            this.InitialDigestionAmount = sampleGroup.InitialDigestionAmount;
            this.InitialDigestionUnit = sampleGroup.InitialDigestionUnit;

            this.FinalAmount = sampleGroup.FinalAmount;
            this.FinalUnit = sampleGroup.FinalUnit;

            this.Description = sampleGroup.Description;
            this.Comment = "";
            this.IsActive = true;
        }

        private void SetSampleCode(string sampleName)
        {
            if(this.GroupCode == "G01")
            {
                this.SampleCode = GroupCode + "-" + sampleName;
            }
            else
            {
                string sampleCodeSequence = "";
                if (this.SampleType == SampleTypes.LIQUID)
                {
                    sampleCodeSequence = this.SampleIndex == 0 ? "CTRL" : "S" + (this.SampleIndex);
                }
                else
                {
                    sampleCodeSequence = "S" + (SampleIndex + 1);
                }
                this.SampleCode = this.GroupCode + "-" + this.ProjectNumber + "-" + sampleCodeSequence;
            }
        }
    }
}
