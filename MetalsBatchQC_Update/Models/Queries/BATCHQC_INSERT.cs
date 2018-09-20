using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Toxikon.BatchQC.Models.Reports;
using Toxikon.BatchQC.Models.Results;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BATCHQC_INSERT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static Int32 InsertLastSequenceNumber()
        {
            Int32 result = 0;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertLastSequenceNumber", connection))
                {
                    string yearMonth = DateTime.Now.ToString("yyMM");
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", yearMonth);

                    result = (Int32)command.ExecuteScalar();
                }
            }
            return result;
        }

        public static Int32 InsertRole(string roleName)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            Int32 result = 0;

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertRole", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", roleName);
                    command.Parameters.AddWithValue("@IsActive", 1);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertDepartment(string departmentName)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            string departmentCode = departmentName.Substring(0, 3);
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand commamd = new SqlCommand("InsertDepartment", connection))
                {
                    commamd.CommandType = System.Data.CommandType.StoredProcedure;
                    commamd.Parameters.AddWithValue("@DepartmentCode", departmentCode);
                    commamd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    commamd.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = commamd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertUser(User user)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@PositionTitle", user.PositionTitle);
                    command.Parameters.AddWithValue("@DepartmentCode", user.DepartmentCode);
                    command.Parameters.AddWithValue("@RoleID", user.RoleID);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertReagent(Chemical item)
        {
            Int32 result = InsertChemical(item, "InsertReagent");
            return result;
        }

        public static Int32 InsertSpikeSolution(Chemical item)
        {
            Int32 result = InsertChemical(item, "InsertSpikeSolution");
            return result;
        }

        private static Int32 InsertChemical(Chemical item, string query)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductCode", item.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", item.ProductName);
                    command.Parameters.AddWithValue("@TypeNumber", item.TypeNumber);
                    command.Parameters.AddWithValue("@TypeName", item.TypeName);
                    command.Parameters.AddWithValue("@IsActive", 1);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);
                    command.Parameters.AddWithValue("@UpdatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertBatchCode(BatchCode batchCode)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertBatchCode", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchCode", batchCode.FullCode);
                    command.Parameters.AddWithValue("@MethodCode", batchCode.MethodCode);
                    command.Parameters.AddWithValue("@SequenceNumber", batchCode.SequenceNumber);
                    command.Parameters.AddWithValue("@DepartmentCode", batchCode.DepartmentCode);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = (Int32)command.ExecuteScalar();
                }
            }
            return result;
        }

        public static Int32 InsertBatchDetail()
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            BatchDetail batchDetail = dataSheet.BatchDetail;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertBatchDetail", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", dataSheet.BatchCode.ID);
                    command.Parameters.AddWithValue("@PurifiedWater", batchDetail.PurifiedWater);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertBatchProject(Project project)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertBatchProject", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@ProjectNumber", project.ProjectNumber);
                    command.Parameters.AddWithValue("@StudyDirector", project.StudyDirector);
                    command.Parameters.AddWithValue("@StudyCode", project.StudyCode);
                    command.Parameters.AddWithValue("@StudyName", project.StudyName);
                    command.Parameters.AddWithValue("@SponsorCode", project.SponsorCode);
                    command.Parameters.AddWithValue("@SponsorName", project.SponsorName);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertBatchSpikeSolution(SpikeSolution spikeSolution)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertBatchSpikeSolution", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@ProductCode", spikeSolution.ProductCode);
                    command.Parameters.AddWithValue("@ItemCode", spikeSolution.ItemCode);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = (Int32)command.ExecuteScalar();
                }
            }
            return result;
        }

        public static Int32 InsertBatchReagent(Reagent reagent)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertBatchReagent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@ProductCode", reagent.ProductCode);
                    command.Parameters.AddWithValue("@ItemCode", reagent.ItemCode);
                    command.Parameters.AddWithValue("@Amount", reagent.Amount);
                    command.Parameters.AddWithValue("@Unit", reagent.Unit);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = (Int32)command.ExecuteScalar();
                }
            }
            return result;
        }

        public static Int32 InsertBatchSample(Sample sample)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertBatchSample2", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@SampleCode", sample.SampleCode);
                    command.Parameters.AddWithValue("@GroupCode", sample.GroupCode);
                    command.Parameters.AddWithValue("@ProjectNumber", sample.ProjectNumber);

                    command.Parameters.AddWithValue("@SampleAmount", sample.SampleAmount);
                    command.Parameters.AddWithValue("@SampleUnit", sample.SampleUnit);

                    command.Parameters.AddWithValue("@InitialDigestionAmount", sample.InitialDigestionAmount);
                    command.Parameters.AddWithValue("@InitialDigestionUnit", sample.InitialDigestionUnit);

                    command.Parameters.AddWithValue("@FinalAmount", sample.FinalAmount);
                    command.Parameters.AddWithValue("@FinalUnit", sample.FinalUnit);

                    command.Parameters.AddWithValue("@Description", sample.Description);
                    command.Parameters.AddWithValue("@Comment", sample.Comment);
                    command.Parameters.AddWithValue("@CreatedBy", loginInfo.UserName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertBQCReport(Project project, string userName)
        {
            Int32 result = 0;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertBQCReport", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectNumber", project.ProjectNumber);
                    command.Parameters.AddWithValue("@MethodCode", project.MethodCode);
                    command.Parameters.AddWithValue("@StudyDirector", project.StudyDirector);
                    command.Parameters.AddWithValue("@CreatedBy", userName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static Int32 InsertICAPResults(BQCSampleResult sampleResult)
        {
            Int32 result = InsertSampleResult(sampleResult, "InsertICAPResults");
            return result;
        }
        public static Int32 InsertICAPRQResults(BQCSampleResult sampleResult)
        {
            Int32 result = InsertSampleResult(sampleResult, "InsertICAPRQResults");
            return result;
        }

        public static Int32 InsertICPMSResults(BQCSampleResult sampleResult)
        {
            Int32 result = InsertSampleResult(sampleResult, "InsertICPMSResults");
            return result;
        }
        public static Int32 InsertICPMSQResults(BQCSampleResult sampleResult)
        {
            Int32 result = InsertSampleResult(sampleResult, "InsertICPMSQResults");
            return result;
        }


        private static Int32 InsertSampleResult(BQCSampleResult sampleResult, string query)
        {
            Int32 result = 0;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (Element element in sampleResult.Elements)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add("@BatchID", SqlDbType.Int).Value = sampleResult.BatchID;
                        command.Parameters.Add("@RunID", SqlDbType.NChar).Value = sampleResult.RunID;
                        command.Parameters.Add("@InstrumentID", SqlDbType.NChar).Value = sampleResult.InstrumentID;
                        command.Parameters.Add("@SampleType", SqlDbType.NChar).Value = sampleResult.SampleType;
                        command.Parameters.Add("@RunDate", SqlDbType.DateTime).Value = sampleResult.RunDate;
                        command.Parameters.Add("@Low", SqlDbType.Float).Value = element.LowValue;
                        command.Parameters.Add("@High", SqlDbType.Float).Value = element.HighValue;
                        command.Parameters.Add("@ElementSymbol", SqlDbType.NChar).Value = element.Symbol;
                        command.Parameters.Add("@ResultValue", SqlDbType.Float).Value = element.ResultValue;
                        command.Parameters.Add("@ResultUnit", SqlDbType.NChar).Value = element.ResultUnit;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = element.IsActive;
                        command.Parameters.Add("@UploadedBy", SqlDbType.NVarChar).Value = loginInfo.UserName;

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            return result;
        }
    }
}
