using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BATCHQC_SEARCH
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 SearchProjectFromBQCReport(Project project)
        {
            Int32 result = 0;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SearchProjectFromBQCReport", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectNumber", project.ProjectNumber);
                    command.Parameters.AddWithValue("@MethodCode", project.MethodCode);

                    result = (Int32)command.ExecuteScalar();
                }
            }
            return result;
        }

        public static User SearchUserByUserName(string searchString)
        {
            searchString += "%";
            User result = new User();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SearchUserByUserName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar).Value = searchString;
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        result.UserName = reader[0].ToString();
                        result.FullName = reader[1].ToString();
                        result.DepartmentCode = reader[2].ToString();
                        result.RoleID = Convert.ToInt16(reader[3].ToString());
                        result.IsActive = Convert.ToBoolean(reader[4].ToString());
                        result.EmailAddress = reader[5].ToString();
                    }
                }
            }
            return result;
        }

        public static BatchCode SearchBatchCode(int createdMonth, int createdYear, int sequenceNumber)
        {
            BatchCode result = null;
            try
            {
                string query = @"SELECT BatchCodes.ID, BatchCodes.BatchCode, BatchCodes.MethodCode, 
                                    BatchCodes.IsActive, BatchCodes.IsComplete
                             FROM BatchCodes
                             WHERE BatchCodes.SequenceNumber = @SequenceNumber
                             AND DATEPART(YEAR, BatchCodes.CreatedDate) = @Year
                             AND DATEPART(MONTH, BatchCodes.CreatedDate) = @Month";
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.Add("@SequenceNumber", System.Data.SqlDbType.Int).Value = sequenceNumber;
                        command.Parameters.Add("@Year", System.Data.SqlDbType.Int).Value = createdYear;
                        command.Parameters.Add("@Month", System.Data.SqlDbType.Int).Value = createdMonth;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            result = new BatchCode();
                            result.ID = Convert.ToInt32(reader[0].ToString());
                            result.FullCode = reader[1].ToString();
                            result.MethodCode = reader[2].ToString();
                            result.IsActive = Convert.ToBoolean(reader[3].ToString());
                            result.IsComplete = Convert.ToBoolean(reader[4].ToString());
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                Debug.WriteLine(sqlEx.Message);
            }
            
            return result;
        }
    }
}
