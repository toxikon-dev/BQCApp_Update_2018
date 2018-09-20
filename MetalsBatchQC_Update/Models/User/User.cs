using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PositionTitle { get; set; }
        public string DepartmentCode { get; set; }
        public Int16 RoleID { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            this.UserName = "";
            this.FirstName = "";
            this.LastName = "";
            this.FullName = "";
            this.EmailAddress = "";
            this.PositionTitle = "";
            this.RoleID = 0;
            this.IsActive = true;
        }

        public void SetUserName(string userName)
        {
            string[] splits = userName.Split('\\');
            if(splits.Count() >= 2)
            {
                this.UserName = splits[1].ToLower();
            }
        }
    }
}
