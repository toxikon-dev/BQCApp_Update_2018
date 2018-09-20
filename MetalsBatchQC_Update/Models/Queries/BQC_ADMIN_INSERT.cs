using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BQC_ADMIN_INSERT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 InsertInstrument(Instrument instrument)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertInstrument", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrument.ID);
                    command.Parameters.AddWithValue("@InstrumentName", instrument.Name);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertElement(Element element)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertElement", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", element.InstrumentID);
                    command.Parameters.AddWithValue("@Symbol", element.Symbol);
                    command.Parameters.AddWithValue("@Name", element.Name);
                    command.Parameters.AddWithValue("@MassValue", element.MassValue);
                    command.Parameters.AddWithValue("@TrueValue", element.TrueValue);
                    command.Parameters.AddWithValue("@TrueValueUnit", element.TrueValueUnit);
                    command.Parameters.AddWithValue("@ReportingLimitValue", element.ReportingLimitValue);
                    command.Parameters.AddWithValue("@ReportingLimitUnit", element.ReportingLimitUnit);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
