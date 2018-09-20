using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Toxikon.BatchQC.Models
{
    class LIMS_Queries
    {
        private static string CONNECTION_STRING = Utility.GetLIMSConnectionString();

        private static string GET_CHEMICAL_LIST =
        @"
        SELECT DISTINCT UserTable4.Code AS ItemCode, UserTable3.UserText2 AS CategoryName,
	                    UserTable4.UserDate4 AS ExpirationDate
        FROM [MATTOXIKONPLUS].[dbo].[UserTable4]
        INNER JOIN [MATTOXIKONPLUS].[dbo].[UserTable3]
        ON UserTable4.UserText1 = UserTable3.Code
        WHERE UserTable4.UserText1 = @ProductCode
        AND UserTable3.RecordStatus = 1
        AND UserTable4.RecordStatus = 1
        AND UserTable4.UserDate4 > CONVERT(varchar(12), GETDATE(), 112)
        ORDER BY ItemCode DESC
        ";

        private static string SEARCH_ITEM_BY_NAME =
        @"
        SELECT UserTable3.Code AS ProductCode,
               UserTable3.UserText2 AS ProductName,
               UserTable3.UserInt10 AS ItemType,
	           UserTable3.CreationUser AS CreatedBy,
	           UserTable3.CreationDate AS CreatedDate
        FROM [MATTOXIKONPLUS].[dbo].[UserTable3]
        WHERE UserText2 LIKE @ItemName
        AND RecordStatus = 1
        ORDER BY CreatedDate DESC
        ";

        private static string SEARCH_PROJECT_NUMBER =
        @"
            SELECT DISTINCT Project.SampleCode AS ProjectNumber,
				Project.SampleText5 as StudyDirector,
				Project.SubstanceCode AS StudyCode,
				Study.SubstanceText1 AS StudyName,
				Sponsor.SubmitterCode AS SponsorCode,
                Sponsor.SubmitterName AS SponsorName
            FROM Samples AS Project
            INNER JOIN Substances AS Study
            ON Project.SubstanceCode = Study.SubstanceCode
            INNER JOIN Submitters AS Sponsor
            ON Project.SubmitterCode = Sponsor.SubmitterCode
            WHERE Project.SampleCode LIKE @SearchString
            AND Project.AuditFlag = 0
            AND Study.RecordStatus = 1
        ";

        public static IList GetResultsFromSearchItemByName(string searchString)
        {
            IList results = new ArrayList();
            searchString += "%";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(SEARCH_ITEM_BY_NAME, connection);
                command.Parameters.AddWithValue("@ItemName", searchString);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int itemType;
                    if (Int32.TryParse(reader[2].ToString(), out itemType))
                    {
                        Chemical item = CreateNewChemicalItem(reader);
                        results.Add(item);
                    }
                }
                reader.Close();
            }
            return results;
        }

        private static Chemical CreateNewChemicalItem(SqlDataReader reader)
        {
            Chemical item = new Chemical();
            item.ProductCode = reader[0].ToString();
            item.ProductName = reader[1].ToString();
            item.TypeNumber = Convert.ToInt32(reader[2].ToString());
            item.TypeName = item.TypeNumber == 1 ? "Chemical" : "LPR";
            item.CreatedBy = reader[3].ToString().Replace(@"TOXIKON\", "");
            item.CreatedDate = reader[4].ToString();
            return item;
        }

        public static IList GetChemicalList(string productCode)
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(GET_CHEMICAL_LIST, connection);
                command.Parameters.AddWithValue("@ProductCode", productCode);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(reader[0].ToString());
                }
                reader.Close();
            }
            return results;
        }

        public static Project SearchProjectNumber(string searchString)
        {
            searchString = Regex.Replace(searchString, @"\s+", "");
            Project result = new Project();
            string connectionString = Utility.GetLIMSConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SEARCH_PROJECT_NUMBER, connection))
                {
                    command.Parameters.AddWithValue("@SearchString", searchString);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.ProjectNumber = reader[0].ToString();
                        result.StudyDirector = reader[1].ToString();
                        result.StudyCode = reader[2].ToString();
                        result.StudyName = reader[3].ToString();
                        result.SponsorCode = reader[4].ToString();
                        result.SponsorName = reader[5].ToString();
                    }
                    reader.Close();
                }
            }
            return result;
        }
    }
}
