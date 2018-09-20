using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BATCHQC_SELECT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        /******************************* SELECT *************************/
        public static IList GetAllActiveDepartments()
        {
            IList results = new ArrayList();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectAllActiveDepartments", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Department department = new Department();
                        department.DepartmentCode = reader[0].ToString();
                        department.DepartmentName = reader[1].ToString();
                        results.Add(department);
                    }
                }
            }
            return results;
        }

        public static IList GetAllActiveRoles()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectAllActiveRoles", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.RoleID = Convert.ToInt16(reader[0].ToString());
                        role.RoleName = reader[1].ToString();
                        results.Add(role);
                    }
                }
            }
            return results;
        }

        public static User GetUser()
        {
            User result = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SelectUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", Environment.UserName);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            result.UserName = reader[0].ToString();
                            result.FirstName = reader[1].ToString();
                            result.LastName = reader[2].ToString();
                            result.FullName = reader[3].ToString();
                            result.EmailAddress = reader[4].ToString();
                            result.DepartmentCode = reader[5].ToString();
                            result.RoleID = Convert.ToInt16(reader[6].ToString());
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public static IList GetActiveBatchCodesByMethod(string methodCode)
        {
            IList results = new ArrayList();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectActiveBatchCodesByMethod", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MethodCode", methodCode);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        BatchCode batchCode = CreateBatchCode(reader);
                        results.Add(batchCode);
                    }
                }
            }
            return results;
        }

        public static IList GetActiveBatchCodes()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectActiveBatchCodes", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BatchCode batchCode = CreateBatchCode(reader);
                        results.Add(batchCode);
                    }
                }
            }
            return results;
        }

        private static BatchCode CreateBatchCode(SqlDataReader reader)
        {
            BatchCode batchCode = new BatchCode();
            batchCode.ID = Convert.ToInt32(reader[0].ToString());
            batchCode.FullCode = reader[1].ToString();
            batchCode.MethodCode = reader[2].ToString();
            batchCode.SequenceNumber = Convert.ToInt32(reader[3].ToString());
            batchCode.DepartmentCode = reader[4].ToString();
            batchCode.CreatedBy = reader[5].ToString();
            batchCode.CreatedDate = reader[6].ToString();
            batchCode.UpdatedBy = reader[7].ToString();
            batchCode.UpdatedDate = reader[8].ToString();
            return batchCode;
        }

        public static bool CheckReagentExists(string productCode)
        {
            bool result = CheckChemicalExists(productCode, "CheckReagentExists");
            return result;
        }

        public static bool CheckSpikeSolutionExists(string productCode)
        {
            bool result = CheckChemicalExists(productCode, "CheckSpikeSolutionExists");
            return result;
        }

        private static bool CheckChemicalExists(string productCode, string query)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    Int32 count = (Int32)command.ExecuteScalar();
                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public static IList SelectAllActiveReagents()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectAllActiveReagents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Chemical item = CreateNewChemicalItem(reader);
                        results.Add(item);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static IList SelectAllActiveSpikeSolution()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectAllActiveSpikeSolutions", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Chemical item = CreateNewChemicalItem(reader);
                        results.Add(item);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        private static Chemical CreateNewChemicalItem(SqlDataReader reader)
        {
            Chemical item = new Chemical();
            item.ProductCode = reader[0].ToString();
            item.ProductName = reader[1].ToString();
            item.TypeNumber = Convert.ToInt32(reader[2].ToString());
            item.TypeName = reader[3].ToString();
            item.CreatedDate = reader[4].ToString();
            item.CreatedBy = reader[5].ToString();
            item.UpdatedDate = reader[6].ToString();
            item.UpdatedBy = reader[7].ToString();
            return item;
        }

        public static BatchDetail GetBatchDetail(Int32 batchID)
        {           
            BatchDetail batchDetail = new BatchDetail();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectBatchDetail", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        batchDetail.PrepDate = reader[0].ToString();
                        batchDetail.PreparedBy = reader[1].ToString();
                        batchDetail.SampleType = reader[2].ToString();
                        batchDetail.InstrumentID = reader[3].ToString();
                        batchDetail.BalanceID = reader[4].ToString();
                        batchDetail.Method = reader[5].ToString();
                        batchDetail.MethodID = reader[6].ToString();
                        batchDetail.MethodTemp = reader[7].ToString();
                        batchDetail.Analyte = reader[8].ToString();
                        batchDetail.PrepType = reader[9].ToString();
                        batchDetail.PurifiedWater = reader[10].ToString();
                    }
                    reader.Close();
                }
            }
            return batchDetail;
        }

        public static bool CheckBatchDetailExists()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            bool result = false;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("CheckBatchDetailExists", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    Int32 count = (Int32)command.ExecuteScalar();
                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public static IList GetBatchProjects()
        {
            IList results = new ArrayList();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectBatchProjects", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Project project = new Project();
                        project.ProjectNumber = reader[0].ToString();
                        project.StudyDirector = reader[1].ToString();
                        project.StudyCode = reader[2].ToString();
                        project.StudyName = reader[3].ToString();
                        project.SponsorCode = reader[4].ToString();
                        project.SponsorName = reader[5].ToString();

                        results.Add(project);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static IList GetBatchReagents()
        {
            IList results = new ArrayList();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectBatchReagents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Reagent reagent = new Reagent();
                        reagent.ItemID = Convert.ToInt32(reader[0].ToString());
                        reagent.ProductCode = reader[1].ToString();
                        reagent.ItemCode = reader[2].ToString();
                        reagent.Amount = Convert.ToDouble(reader[3].ToString());
                        reagent.Unit = reader[4].ToString();
                        reagent.ProductName = reader[5].ToString();
                        reagent.TypeNumber = Convert.ToInt32(reader[6].ToString());
                        reagent.TypeName = reader[7].ToString();

                        results.Add(reagent);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static IList GetBatchSpikeSolutions()
        {
            IList results = new ArrayList();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectBatchSpikeSolutions", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SpikeSolution item = new SpikeSolution();
                        item.ItemID = Convert.ToInt32(reader[0].ToString());
                        item.ProductCode = reader[1].ToString();
                        item.ItemCode = reader[2].ToString();
                        item.ProductName = reader[3].ToString();
                        item.TypeNumber = Convert.ToInt32(reader[4].ToString());
                        item.TypeName = reader[5].ToString();

                        results.Add(item);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static IList GetBatchSamples()
        {
            IList results = new ArrayList();
            DataSheet dataSheet = DataSheet.GetInstance();
            Int32 batchID = dataSheet.BatchCode.ID;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectBatchSamples", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sample item = new Sample();
                        item.SampleCode = reader[0].ToString();
                        item.GroupCode = reader[1].ToString();
                        item.ProjectNumber = reader[2].ToString();
                        item.InitialDigestionAmount = Convert.ToDouble(reader[3].ToString());
                        item.InitialDigestionUnit = reader[4].ToString();
                        item.FinalAmount = Convert.ToDouble(reader[5].ToString());
                        item.FinalUnit = reader[6].ToString();
                        item.Description = reader[7].ToString();
                        item.Comment = reader[8].ToString();
                        item.SampleAmount = Convert.ToDouble(reader[9].ToString());
                        item.SampleUnit = reader[10].ToString();

                        results.Add(item);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static IList GetBatchCodesForProject(string projectNumber)
        {
            IList results = new ArrayList();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectBatchCodesByProjectNumber", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectNumber", projectNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static Int32 GetBQCReportByProjectNumber(string projectNumber)
        {
            Int32 result = 0;
            BQCReport report = BQCReport.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectBQCReportByProjectNumber", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectNumber", projectNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        report.SetMatrix(reader[0].ToString());
                        report.SetAnalyticalInstrument(reader[1].ToString());
                        report.SetBQCSampleTypes(reader[2].ToString());
                        report.SetBQCComment(reader[3].ToString());
                        report.SetSampleIDs(reader[4].ToString());
                        report.SetRunID(reader[5].ToString());
                        report.SetExceptions(reader[6].ToString());
                        report.SetBQCStatus(reader[7].ToString());
                        report.SetRunComment(reader[8].ToString());
                        report.SetAnalyst(reader[9].ToString());
                        report.SetAnalystSignature(reader[10].ToString());
                        report.SetAnalystSignedDate(reader[11].ToString());
                        report.SetQA(reader[12].ToString());
                        report.SetQASignature(reader[13].ToString());
                        report.SetQASignedDate(reader[14].ToString());
                        report.SetStudyDirector(reader[15].ToString());
                        report.SetSDSignature(reader[16].ToString());
                        report.SetSDSignedDate(reader[17].ToString());
                        report.SetIsAnalystApproved((bool)reader[18]);
                        report.SetIsQAApproved((bool)reader[19]);
                        report.SetIsSDApproved((bool)reader[20]);
                    }
                    reader.Close();
                }
            }
            return result;
        }

        public static IList GetElementsForInstrument(string instrumentID)
        {
            IList results = new ArrayList();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SelectElementsForInstrument", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrumentID);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Element element = new Element();
                        element.Symbol = reader[0].ToString().Trim();
                        element.Name = reader[1].ToString().Trim();
                        element.MassValue = Convert.ToDouble(reader[2].ToString().Trim());
                        element.TrueValue = Convert.ToDouble(reader[3].ToString().Trim());
                        if(instrumentID == Instruments.ICP_2995)
                        {
                            element.SetLowValue(15);
                            element.SetHighValue(15);
                        }
                        else
                        {
                            element.SetLowValue(20);
                            element.SetHighValue(20);
                        }
                        results.Add(element);
                    }
                }
            }
            return results;
        }
    }
}
