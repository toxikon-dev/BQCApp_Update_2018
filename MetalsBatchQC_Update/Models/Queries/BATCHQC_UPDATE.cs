using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BATCHQC_UPDATE
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 UpdateBatchDetail()
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            BatchDetail batchDetail = dataSheet.BatchDetail;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateBatchDetails", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", dataSheet.BatchCode.ID);
                    command.Parameters.AddWithValue("@PreparedBy", batchDetail.PreparedBy);
                    command.Parameters.AddWithValue("@SampleType", batchDetail.SampleType);
                    command.Parameters.AddWithValue("@InstrumentID", batchDetail.InstrumentID);
                    command.Parameters.AddWithValue("@BalanceID", batchDetail.BalanceID);
                    command.Parameters.AddWithValue("@MethodName", batchDetail.Method);
                    command.Parameters.AddWithValue("@MethodID", batchDetail.MethodID);
                    command.Parameters.AddWithValue("@MethodTemp", batchDetail.MethodTemp);
                    command.Parameters.AddWithValue("@Analyte", batchDetail.Analyte);
                    command.Parameters.AddWithValue("@PrepType", batchDetail.PrepType);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchProject_IsActive(int batchID, Project project, string updatedBy)
        {
            Int32 result = 0;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBatchProject_IsActive", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@BatchID", System.Data.SqlDbType.Int).Value = batchID;
                    command.Parameters.Add("@ProjectNumber", System.Data.SqlDbType.NVarChar).Value = 
                                                                                      project.ProjectNumber;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = project.IsActive;
                    command.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.NVarChar).Value = updatedBy;

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchSpikeSolutions_IsActive(SpikeSolution item, string updatedBy)
        {
            Int32 result = 0;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateBatchSpikeSolutions_IsActive", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@ItemID", System.Data.SqlDbType.Int).Value = item.ItemID;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                    command.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.NVarChar).Value = updatedBy;

                    result = command.ExecuteNonQuery();
                }
             }
            return result;
        }

        public static Int32 UpdateBatchReagent(Reagent reagent)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateBatchReagent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", reagent.ItemID);
                    command.Parameters.AddWithValue("@Amount", reagent.Amount);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchReagent_IsActive(Reagent item, string updatedBy)
        {
            Int32 result = 0;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBatchReagents_IsActive", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@ItemID", System.Data.SqlDbType.Int).Value = item.ItemID;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                    command.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.NVarChar).Value = updatedBy;

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchSample(Sample sample)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBatchSample2", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", dataSheet.BatchCode.ID);
                    command.Parameters.AddWithValue("@SampleCode", sample.SampleCode);

                    command.Parameters.AddWithValue("@SampleAmount", sample.SampleAmount);
                    command.Parameters.AddWithValue("@InitialDigestionAmount", sample.InitialDigestionAmount);
                    command.Parameters.AddWithValue("@FinalAmount", sample.FinalAmount);

                    command.Parameters.AddWithValue("@Description", sample.Description);
                    command.Parameters.AddWithValue("@Comment", sample.Comment);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchSample_IsActive(int batchID, Sample item, string updatedBy)
        {
            Int32 result = 0;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBatchSample_IsActive", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@BatchID", System.Data.SqlDbType.Int).Value = batchID;
                    command.Parameters.Add("@SampleCode", System.Data.SqlDbType.NVarChar).Value =
                                                                                      item.SampleCode;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                    command.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.NVarChar).Value = updatedBy;

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 UpdateBatchCodeIsComplete(int value)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateBatchCodeIsComplete", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@IsComplete", value);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static void UpdateBatchCode(BatchCode batchCode, string updatedBy)
        {
            string query = @"UPDATE BatchCodes
                             SET BatchCode = @BatchCode,
                                 MethodCode = @MethodCode,
                                 IsActive = @IsActive,
                                 IsComplete = @IsComplete,
                                 UpdatedBy = @UpdatedBy,
                                 UpdatedDate = GETDATE()
                             WHERE ID = @BatchID";
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.Add("@BatchID", System.Data.SqlDbType.Int).Value = batchCode.ID;
                    command.Parameters.Add("@BatchCode", System.Data.SqlDbType.VarChar).Value = batchCode.FullCode;
                    command.Parameters.Add("@MethodCode", System.Data.SqlDbType.Char).Value = batchCode.MethodCode;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = batchCode.IsActive;
                    command.Parameters.Add("@IsComplete", System.Data.SqlDbType.Bit).Value = batchCode.IsComplete;
                    command.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.NVarChar).Value = updatedBy;

                    Int32 result = command.ExecuteNonQuery();
                }
            }
        }

        public static Int32 UpdateBQCReport()
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            BQCReport report = BQCReport.GetInstance();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("UpdateBQCReportOnSaveChanges", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectNumber", report.ProjectNumber);
                    command.Parameters.AddWithValue("@MethodCode", report.Method);
                    command.Parameters.AddWithValue("@Matrix", report.Matrix);
                    command.Parameters.AddWithValue("@Instruments", report.AnalyticalInstrument);
                    command.Parameters.AddWithValue("@SampleTypes", report.BQCSampleTypes);
                    command.Parameters.AddWithValue("@BQCComment", report.BQCComment);
                    command.Parameters.AddWithValue("@SampleID", report.SampleID);
                    command.Parameters.AddWithValue("@RunID", report.RunID);
                    command.Parameters.AddWithValue("@Exceptions", report.Exceptions);
                    command.Parameters.AddWithValue("@BQCStatus", report.BQCStatus);
                    command.Parameters.AddWithValue("@RunComment", report.RunComment);
                    command.Parameters.AddWithValue("@Analyst", report.Analyst);
                    command.Parameters.AddWithValue("@AnalystSignature", report.AnalystSignature);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
