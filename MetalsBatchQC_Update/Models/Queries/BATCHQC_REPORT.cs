using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.Models.Reports;

namespace Toxikon.BatchQC.Models.Queries
{
    public class BATCHQC_REPORT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static IList GetActiveBQCReportForAnalyst()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectActiveBQCReportForAnalyst2", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ProjectNumber = reader[0].ToString();
                        project.MethodCode = reader[1].ToString();
                        project.SponsorName = reader[2].ToString();
                        project.StudyDirector = reader[3].ToString();

                        results.Add(project);
                    }
                    reader.Close();
                }
            }
            return results;
        }

        public static DataTable GetControlChartReportForICPMS(string instrumentID, int month, int year)
        {
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectICPMSResultsByMonthYear", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrumentID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    resultTable.Load(reader);
                }
            }
            return resultTable;
        }

        public static DataTable GetControlChartReportForICAP(string instrumentID, int month, int year)
        {
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectICAPResultsByMonthYear", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrumentID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    resultTable.Load(reader);
                }
            }
            return resultTable;
        }

        public static DataTable GetControlChartReportForICPMSQ(string instrumentID, int month, int year)
        {
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
               
                using (SqlCommand command = new SqlCommand("SelectICPMSQResultsByMonthYear", connection))
                { 
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrumentID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    resultTable.Load(reader);

                }
            }
            return resultTable;
        }

        public static DataTable GetControlChartReportForICAPRQ(string instrumentID, int month, int year)
        {
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {

                using (SqlCommand command = new SqlCommand("SelectICAPRQResultsByMonthYear", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstrumentID", instrumentID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    resultTable.Load(reader);

                }
            }
            return resultTable;
        }

        public static IList GetAvailableReportsForInstrument(string instrumentType)
        {
            IList result = new ArrayList();
            switch(instrumentType)
            {
                case "ICAP":
                    GetAvailableCCR(result, "SelectICAPReports");
                    break;
                case "ICPMS":
                    GetAvailableCCR(result, "SelectICPMSReports");
                    break;
                case "ICPMSQ":
                    GetAvailableCCR(result, "SelectICPMSQReports");
                    break;
                case "ICAPRQ":
                    GetAvailableCCR(result, "SelectICAPRQReports");
                    break;
                default:
                    break;
            }
            return result;
        }

        private static void GetAvailableCCR(IList result, string query)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        ControlChartReport report = new ControlChartReport();
                        report.InstrumentID = reader[0].ToString().Trim();
                        report.ReportMonth = Convert.ToInt32(reader[1].ToString());
                        report.ReportYear = Convert.ToInt32(reader[2].ToString());

                        result.Add(report);
                    }
                }
            }
        }

        public static IList GetICPMSElementResults()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            int batchID = dataSheet.BatchCode.ID;
            IList results = new ArrayList();
            GetElementResultsByBatchID(results, "SelectICPMSResultsByBatchID", batchID);
            return results;
        }

        public static IList GetICPMSQElementResults()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            int batchID = dataSheet.BatchCode.ID;
            IList results = new ArrayList();
            GetElementResultsByBatchID(results, "SelectICPMSQResultsByBatchID", batchID);
            return results;
        }

        public static IList GetICAPElementResults()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            int batchID = dataSheet.BatchCode.ID;
            IList results = new ArrayList();
            GetElementResultsByBatchID(results, "SelectICAPResultsByBatchID", batchID);
            return results;
        }

        public static IList GetICAPRQElementResults()
        {
            DataSheet dataSheet = DataSheet.GetInstance();
            int batchID = dataSheet.BatchCode.ID;
            IList results = new ArrayList();
            GetElementResultsByBatchID(results, "SelectICAPRQResultsByBatchID", batchID);
            return results;
        }

        private static void GetElementResultsByBatchID(IList results, string query, int batchID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Element element = new Element();
                        element.RunID = reader[1].ToString();
                        element.InstrumentID = reader[2].ToString();
                        element.Symbol = reader[3].ToString();
                        element.ResultValue = Convert.ToDouble(reader[8].ToString());
                        element.ResultUnit = reader[9].ToString();

                        results.Add(element);
                    }
                }
            }
        }
    }
}
