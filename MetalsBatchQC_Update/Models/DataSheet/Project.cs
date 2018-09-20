using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class Project
    {
        public string ProjectNumber { get; set; }
        public string MethodCode { get; set; }
        public string StudyDirector { get; set; }
        public string StudyCode { get; set; }
        public string StudyName { get; set; }
        public string SponsorCode { get; set; }
        public string SponsorName { get; set; }
        public bool IsActive { get; set; }

        public Project()
        {
            ProjectNumber = "";
            StudyDirector = "";
            StudyCode = "";
            StudyName = "";
            SponsorName = "";
            SponsorCode = "";
            IsActive = true;
        }
    }
}
