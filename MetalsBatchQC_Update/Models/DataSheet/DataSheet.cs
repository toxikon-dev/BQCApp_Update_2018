using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models.Queries;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Models
{
    public class DataSheet
    {
        private static DataSheet _instance;

        public BatchCode BatchCode { get; private set; }
        public BatchDetail BatchDetail { get; private set; }
        public List<Project> Projects { get; private set; }
        public List<Reagent> Reagents { get; private set; }
        public List<SpikeSolution> SpikeSolutions { get; private set; }
        private Dictionary<string, SampleGroup> SampleGroupDictionary;

        public static DataSheet GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataSheet();
            }
            return _instance;
        }

        private DataSheet()
        {
            BatchCode = new Models.BatchCode();
            BatchDetail = new BatchDetail();
            Reagents = new List<Reagent>() { };
            Projects = new List<Project>() { };
            SpikeSolutions = new List<SpikeSolution>() { };
            SampleGroupDictionary = new Dictionary<string, SampleGroup>() { };
        }

        public List<SampleGroup> SampleGroups
        {
            get { return this.SampleGroupDictionary.Values.ToList(); }
        }

        public SampleGroup GetSampleGroup(string groupCode)
        {
            return this.SampleGroupDictionary[groupCode];
        }

        public List<Sample> GetAllSamples()
        {
            List<Sample> results = new List<Sample>() { };
            foreach(SampleGroup group in SampleGroupDictionary.Values.ToList())
            {
                foreach(Sample item in group.Samples)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        public bool HasGroupCode(string groupCode)
        {
            return this.SampleGroupDictionary.ContainsKey(groupCode);
        }

        public string GetNewGroupCode()
        {
            string result = "";
            int groupCount = SampleGroupDictionary.Count == 0 ?
                             SampleGroupDictionary.Count + 2 : SampleGroupDictionary.Count + 1;
            result = "G" + groupCount.ToString("00");
            return result;
        }

        public void Clear()
        {
            this.BatchDetail.Clear();
            this.Projects.Clear();
            this.SpikeSolutions.Clear();
            this.Reagents.Clear();
            this.SampleGroupDictionary.Clear();
        }

        public void Load()
        {
            LoadBatchDetail();
            LoadProjects();
            LoadSpikeSolutions();
            LoadReagents();
            LoadSampleGroups();
        }

        private void LoadBatchDetail()
        {
            try
            {
                BatchDetail = BATCHQC_SELECT.GetBatchDetail(this.BatchCode.ID);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadProjects()
        {
            IList dbProjects = BATCHQC_SELECT.GetBatchProjects();
            foreach(Project project in dbProjects)
            {
                this.Projects.Add(project);
            }
        }

        private void LoadSpikeSolutions()
        {
            IList dbResults = BATCHQC_SELECT.GetBatchSpikeSolutions();
            foreach(SpikeSolution item in dbResults)
            {
                this.SpikeSolutions.Add(item);
            }
        }

        private void LoadReagents()
        {
            IList dbResults = BATCHQC_SELECT.GetBatchReagents();
            foreach(Reagent item in dbResults)
            {
                this.Reagents.Add(item);
            }
        }

        private void LoadSampleGroups()
        {
            IList samples = BATCHQC_SELECT.GetBatchSamples();
            string lastSampleGroupCode = "";
            foreach (Sample sample in samples)
            {
                SampleGroup sampleGroup;
                if (sample.GroupCode != lastSampleGroupCode)
                {
                    sampleGroup = new SampleGroup(sample.GroupCode);
                    SampleGroupDictionary.Add(sampleGroup.GroupCode, sampleGroup);
                    lastSampleGroupCode = sample.GroupCode;
                }
                else
                {
                    sampleGroup = SampleGroupDictionary[lastSampleGroupCode];
                }
                sample.SampleType = sampleGroup.SampleType;
                sampleGroup.AddSample(sample);
            }
        }

        public void AddSampleGroup(SampleGroup sampleGroup)
        {
            this.SampleGroupDictionary.Add(sampleGroup.GroupCode, sampleGroup);
        }

        public void AddSpikeSolution(SpikeSolution spikeSolution)
        {
            SpikeSolutions.Add(spikeSolution);
        }

        public void AddReagent(Reagent reagent)
        {
            Reagents.Add(reagent);
        }

        public void SetBatchCode(BatchCode bc)
        {
            this.BatchCode = new BatchCode(bc);
        }

        public void AddProject(Project project)
        {
            this.Projects.Add(project);
        }

        public SpikeSolution GetSpikeSolutionAt(int index)
        {
            return this.SpikeSolutions[index];
        }

        public void RemoveSpikeSolutionAt(int index)
        {
            if(index + 1 < this.SpikeSolutions.Count)
            {
                this.SpikeSolutions.RemoveAt(index);
            }
        }

        public void RemoveReagentAt(int index)
        {
            if(index + 1 < this.Reagents.Count)
            {
                this.Reagents.RemoveAt(index);
            }
        }

        public void Print()
        {
            MEMSDataSheet report = new MEMSDataSheet();
            report.Create();
        }
    }
}
