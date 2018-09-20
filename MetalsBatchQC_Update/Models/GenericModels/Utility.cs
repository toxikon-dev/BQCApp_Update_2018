using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    internal class Utility
    {
        internal static string GetLIMSConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings = 
                ConfigurationManager.ConnectionStrings["Toxikon.BatchQC.Properties.Settings.LIMS_connString"];
            if(settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }

        internal static string GetToxXConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["Toxikon.BatchQC.Properties.Settings.TOXX_BATCHQC_connString"];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }

        internal static string GetTMSConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["Toxikon.BatchQC.Properties.Settings.TMS_connString"];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }
    }
}
