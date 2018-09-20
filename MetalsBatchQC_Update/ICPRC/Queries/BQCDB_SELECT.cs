using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.BatchQC.ICPRC.Models;
using Toxikon.BatchQC.Models;

namespace Toxikon.BatchQC.ICPRC.Queries
{
    public class BQCDB_SELECT
    {
        private static string CONNECTION_STRING = Utility.GetToxXConnectionString();

        public static IList SelectActiveReportHeaders()
        {
            IList results = new ArrayList();
            string query = @"SELECT BatchCodes.ID, BatchCodes.BatchCode, BatchCodes.SequenceNumber,
	                                BatchCodes.MethodCode, BatchProjects.ProjectNumber, 
                                    BatchProjects.SponsorName, 
                                    CONVERT(varchar(12), BatchDetails.PrepDate, 101) AS PrepDate, 
                                    BatchDetails.InstrumentID,
                                    BatchDetails.SampleType
                             FROM BatchCodes
                             INNER JOIN BatchDetails
                             ON BatchCodes.ID = BatchDetails.BatchID
                             LEFT JOIN BatchProjects
                             ON BatchCodes.ID = BatchProjects.BatchID
                             WHERE BatchCodes.IsActive = 1
                             AND BatchCodes.IsComplete = 0";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReportHeader reportHeader = CreateReportHeader(reader);
                        results.Add(reportHeader);
                    }
                }
            }
            return results;
        }

        private static ReportHeader CreateReportHeader(SqlDataReader reader)
        {
            ReportHeader reportHeader = new ReportHeader();
            reportHeader.BatchID = Convert.ToInt32(reader[0].ToString());
            reportHeader.BatchCode = reader[1].ToString();
            reportHeader.SequenceNumber = Convert.ToInt32(reader[2].ToString());
            reportHeader.MethodCode = reader[3].ToString();
            reportHeader.ProjectNumber = reader[4].ToString();
            reportHeader.SponsorName = reader[5].ToString();
            reportHeader.PrepDate = reader[6].ToString();
            reportHeader.InstrumentID = reader[7].ToString();
            reportHeader.SampleType = reader[8].ToString();
            reportHeader.SetInstrumentResultUnit();
            reportHeader.SetAnalyticalMethod();
            return reportHeader;
        }

        public static IList<Element> LoadElementsByInstrumentID(string instrumentID)
        {
            IList<Element> results = new List<Element>() { };
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SelectElementsForInstrument", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@InstrumentID", System.Data.SqlDbType.NChar).Value = instrumentID;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Element element = CreateElement(reader, instrumentID);
                        results.Add(element);
                    }
                }
            }
            
            return results;
        }

        private static Element CreateElement(SqlDataReader reader, string instrumentID)
        {
            Element element = new Element();
            element.Name = reader[1].ToString().Trim();
            element.MassValue = Convert.ToDouble(reader[2].ToString().Trim());
            element.TrueValue = Convert.ToDouble(reader[3].ToString().Trim());
            element.TrueValueUnit = reader[4].ToString().Trim();

            if(instrumentID == Instruments.ICP_2995)
            {
                element.Symbol = reader[0].ToString().Trim();
                element.SetLowValue(0.15);
                element.SetHighValue(0.15);
                element.ResultUnit = Units.PPM;
            }
            else if(instrumentID == Instruments.ICP_2224)
            {
                element.Symbol = element.MassValue + reader[0].ToString().Trim();
                element.SetLowValue(0.20);
                element.SetHighValue(0.20);
                element.ResultUnit = Units.PPB;
            }

            else if (instrumentID == Instruments.ICP_3180)
            {
                element.Symbol = element.MassValue + reader[0].ToString().Trim();
                element.SetLowValue(0.20);
                element.SetHighValue(0.20);
                element.ResultUnit = Units.PPB;
            
            }

            else if (instrumentID == Instruments.ICP_3666)
            {
                element.Symbol = element.MassValue + reader[0].ToString().Trim();
                element.SetLowValue(0.2);
                element.SetHighValue(0.2);
                element.ResultUnit = Units.PPB;

            }
            element.ReportingLimitValue = Convert.ToDouble(reader[5].ToString().Trim());
            element.ReportingLimitUnit = reader[6].ToString().Trim();
            element.IsActive = true;
            return element;
        }

        public static IList LoadBatchSamples(int batchID)
        {
            IList results = new ArrayList();
            string query = "SelectBatchSamples";
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@BatchID", System.Data.SqlDbType.Int).Value = batchID;

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        BatchSample batchSample = CreateBatchSample(reader);
                        results.Add(batchSample);
                    }
                }
            }
            return results;
        }

        private static BatchSample CreateBatchSample(SqlDataReader reader)
        {
            BatchSample batchSample = new BatchSample();
            batchSample.SampleCode = reader[0].ToString().Trim();
            batchSample.GroupCode = reader[1].ToString().Trim();
            batchSample.ProjectNumber = reader[2].ToString().Trim();
            batchSample.InitialAmount = Convert.ToDouble(reader[3].ToString().Trim());
            batchSample.InitialUnit = reader[4].ToString().Trim();
            batchSample.FinalAmount = Convert.ToDouble(reader[5].ToString().Trim());
            batchSample.FinalUnit = reader[6].ToString().Trim();
            batchSample.SampleDescription = reader[7].ToString().Trim();
            batchSample.Comment = reader[8].ToString().Trim();
            return batchSample;
        }

        public static Int32 SelectLCSResultsByBatchID(string instrumentID, int batchID)
        {
            Int32 resultCount = 0;

            string query=" ";

            if(instrumentID == Instruments.ICP_2995){

            query =  "SelectICAPResultsByBatchID";

            }
            else if (instrumentID == Instruments.ICP_2224){
            
            query = "SelectICPMSResultsByBatchID";
            }
            else if (instrumentID == Instruments.ICP_3180)
            {
                query = "SelectICPMSQResultsByBatchID";

            }
            else if (instrumentID == Instruments.ICP_3666)
            {
                query = "SelectICAPRQResultsByBatchID";

            }
          
            else {

                Console.WriteLine("instrument is not exist.");
            }

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
                        resultCount += 1;
                    }
                }
            }
            return resultCount;
        }
    }
}
