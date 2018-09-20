using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class SampleGroup
    {
        public string GroupCode { get; set; }
        public string ProjectNumber { get; set; }
        public string Description { get; set; }

        public double SampleAmount { get; set; }
        public string SampleUnit { get; set; }
        public double InitialDigestionAmount { get; set; }
        public string InitialDigestionUnit { get; set; }
        public double FinalAmount { get; set; }
        public string FinalUnit { get; set; }

        public int NumberOfSamples { get; set; }
        public string SampleType { get; set; }
        public IList Samples { get; set; }

        public SampleGroup()
        {
            this.GroupCode = "";
            this.SampleUnit = "";
            this.InitialDigestionUnit = "";
            this.FinalUnit = "";
            Init();
        }

        public SampleGroup(string groupCode)
        {
            Init();
            Create(groupCode);
        }

        private void Init()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            BatchDetail batchDetail = dataSheet.BatchDetail;
            this.SampleType = batchDetail.SampleType;
            ProjectNumber = "";
            Description = "";
            SampleAmount = 0;
            InitialDigestionAmount = 0;
            FinalAmount = 0;
            Samples = new ArrayList();
        }

        public bool CheckSampleCodeExists(string sampleCode)
        {
            bool result = false;
            foreach(Sample sample in Samples)
            {
                if(sample.SampleCode == sampleCode)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void AddSample(Sample sample)
        {
            this.Samples.Add(sample);
        }

        public Sample GetSample(string sampleCode)
        {
            Sample result = new Sample();
            foreach(Sample sample in Samples)
            {
                if(sample.SampleCode == sampleCode)
                {
                    result = sample;
                    break;
                }
            }
            return result;
        }

        public void Create(string groupCode)
        {
            this.GroupCode = groupCode;
            if (SampleType == SampleTypes.LIQUID)
            {
                this.SampleUnit = Units.ML;
                this.InitialDigestionUnit = Units.ML;
            }
            else if (this.SampleType == SampleTypes.SOLID)
            {
                this.SampleUnit = Units.G;
                this.InitialDigestionUnit = Units.G;
            }
            this.FinalUnit = Units.ML;
        }
    }
}
