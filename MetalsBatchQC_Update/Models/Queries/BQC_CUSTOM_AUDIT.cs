using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.GenericModels;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BQC_CUSTOM_AUDIT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();
        private static string INSERT_QUERY = "InsertCustomAudit";

        public static void InsertCustomAudit(CustomAuditRecord record)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(INSERT_QUERY, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = record.TableName;
                    command.Parameters.Add("@Type", SqlDbType.NChar).Value = record.Type;
                    command.Parameters.Add("@PK", SqlDbType.NVarChar).Value = record.PK;
                    command.Parameters.Add("@PKValue", SqlDbType.NVarChar).Value = record.PKValue;
                    command.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = record.FieldName;
                    command.Parameters.Add("@OldValue", SqlDbType.NVarChar).Value = record.OldValue;
                    command.Parameters.Add("@NewValue", SqlDbType.NVarChar).Value = record.NewValue;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = record.UpdatedBy;
                    command.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = record.Reason;

                    Int32 dbResult = command.ExecuteNonQuery();
                }
            }
        }
    }
}
