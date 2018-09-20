using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BQC_ADMIN_UPDATE
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static void UpdateUser(User user, string updatedBy)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = user.RoleID;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;

                    Int32 result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
