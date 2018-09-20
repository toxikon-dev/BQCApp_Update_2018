using System;
using System.Collections;
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
    public class BQCDB_INSERT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 InsertLCSSampleResult(SampleResult sampleResult, IList elements)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();

            
            string query=" ";

            if(sampleResult.InstrumentID == Instruments.ICP_2995){

                query = "InsertICAPResults";

            }
            else if (sampleResult.InstrumentID == Instruments.ICP_2224)
            {

                query = "InsertICPMSResults";
            }
            else if (sampleResult.InstrumentID == Instruments.ICP_3180)
            {
                query = "InsertICPMSQResults";

            }
            else if (sampleResult.InstrumentID == Instruments.ICP_3666)
            {
                query = "InsertICAPRQResults";

            }
            else {

                Console.WriteLine("instrument is not exist.");
            }
            //string query = sampleResult.InstrumentID == Instruments.ICP_2995 ? "InsertICAPResults" :"InsertICPMSResults";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (BQCElementResult element in elements)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add("@BatchID", SqlDbType.Int).Value = sampleResult.BatchID;
                        command.Parameters.Add("@RunID", SqlDbType.NChar).Value = sampleResult.RunID;
                        command.Parameters.Add("@InstrumentID", SqlDbType.NChar).Value = sampleResult.InstrumentID;
                        command.Parameters.Add("@SampleType", SqlDbType.NChar).Value = "LCS";
                        command.Parameters.Add("@RunDate", SqlDbType.DateTime).Value = DateTime.Now;
                        command.Parameters.Add("@Low", SqlDbType.Float).Value = element.Low;
                        command.Parameters.Add("@High", SqlDbType.Float).Value = element.High;
                        string elementSymbol = new String(element.ElementSymbol.Where(Char.IsLetter).ToArray());
                        command.Parameters.Add("@ElementSymbol", SqlDbType.NChar).Value = elementSymbol;
                        command.Parameters.Add("@ResultValue", SqlDbType.Float).Value = element.LCSResult;
                        command.Parameters.Add("@ResultUnit", SqlDbType.NChar).Value = sampleResult.InstrumentUnit;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                        command.Parameters.Add("@UploadedBy", SqlDbType.NVarChar).Value = loginInfo.UserName;

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            return result;
        }
    }
}
