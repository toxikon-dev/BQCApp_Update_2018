using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.ICPRC.Queries
{
    public class BQCDB_UPDATE
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 UpdateLCSResults_ResultValue(SampleResult sampleResult, BQCElementResult element)
        {
            Int32 result = 0;
            //string query = sampleResult.InstrumentID == Instruments.ICP_2995 ? "UpdateICAPResults_ResultValue" :
                          // "UpdateICPMSResults_ResultValue";

                           string query = "";
                           switch (sampleResult.InstrumentID)
                           { 
                                case Instruments.ICP_2224:
                                   query = "UpdateICAPResults_ResultValue";
                                       break;
                                case Instruments.ICP_2995:
                                   query = "UpdateICPMSResults_ResultValue";
                                       break;
                                case Instruments.ICP_3180:
                                   query = "UpdateICPMSQResults_ResultValue";
                                       break;
                                case Instruments.ICP_3666:
                                   query = "UpdateICAPRQResults_ResultValue";
                                       break;
                           
                           }
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@BatchID", SqlDbType.Int).Value = sampleResult.BatchID;
                    command.Parameters.Add("@RunID", SqlDbType.NChar).Value = sampleResult.RunID;
                    command.Parameters.Add("@InstrumentID", SqlDbType.NChar).Value = sampleResult.InstrumentID;
                    command.Parameters.Add("@ElementSymbol", SqlDbType.NChar).Value = element.ElementSymbol;
                    command.Parameters.Add("@ResultValue", SqlDbType.Float).Value = element.LCSResult;

                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }
    }
}
