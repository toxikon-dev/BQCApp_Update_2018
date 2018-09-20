using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Queries;

namespace Toxikon.BatchQC.Models
{
    public class LoginInfo
    {
        private static LoginInfo _instance;
        public Lab lab { get; private set; }
        private User user;

        private LoginInfo()
        {
            lab = new Lab();
            user = new User();
            user = BATCHQC_SELECT.GetUser();
        }

        public static LoginInfo GetInstance()
        {
            if(_instance ==  null)
            {
                _instance = new LoginInfo();
            }
            return _instance;
        }

        public string UserName 
        {
            get { return this.user.UserName; }
        }

        public string FullName
        {
            get { return this.user.FullName; }
        }

        public int RoleID
        {
            get { return this.user.RoleID; }
        }
    }
}
