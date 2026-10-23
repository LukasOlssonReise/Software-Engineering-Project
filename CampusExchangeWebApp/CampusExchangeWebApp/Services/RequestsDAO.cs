using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class RequestsDAO : IRequestsDataServices
    {
        // Connection string for database
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=CampusExchange;
                                    Integrated Security=True;
                                    Connect Timeout=30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";

        public List<RequestModel> GetAllRequests()
        {
            List<RequestModel> foundRequests = new List<RequestModel>();

            // SQL code to get all products from database
            string sqlStatement = @"SELECT * FROM dbo.Requests";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundRequests.Add(new RequestModel
                    {
                        Id = (int)reader[0],
                        ProductName = (string)reader[1],
                        ProductId = (int)reader[2],
                        AccountName = (string)reader[3],
                        AccountId = (int)reader[4]
                    });
                }
            }
            return foundRequests;
        }

        public int Insert(RequestModel request)
        {
            int newIdNumber = -1;

            // SQL code to add a product in database
            string sqlStatement = @"INSERT INTO dbo.Requests (PRODUCT_NAME, PRODUCT_ID, ACCOUNT_NAME, ACCOUNT_ID) VALUES (@ProductName, @ProductId, @AccountName, @AccountId)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ProductName", request.ProductName);
                command.Parameters.AddWithValue("@ProductId", request.ProductId);
                command.Parameters.AddWithValue("@AccountName", request.AccountName);
                command.Parameters.AddWithValue("@AccountId", request.AccountId);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }
    }
}
