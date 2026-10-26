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

        public int Delete(RequestModel request)
        {
            int newIdNumber = -1;

            // SQL code to delete a request by their id from database 
            string sqlStatement = @"DELETE FROM dbo.Requests
                                    WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", request.Id);

                connection.Open();
                newIdNumber = command.ExecuteNonQuery();
            }
            return newIdNumber;
        }

        public List<RequestModel> GetAllRequests()
        {
            List<RequestModel> foundRequests = new List<RequestModel>();

            // SQL code to get all request from database
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

        public RequestModel GetRequestById(int id)
        {
            RequestModel foundRequest = null;

            // SQL code to get a request by their id from database
            string sqlStatement = @"SELECT * FROM dbo.Requests
                                    WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundRequest = new RequestModel
                    {
                        Id = (int)reader[0],
                        ProductName = (string)reader[1],
                        ProductId = (int)reader[2],
                        AccountName = (string)reader[3],
                        AccountId = (int)reader[4],
                    };
                }
            }
            return foundRequest;
        }

        public List<RequestModel> GetRequestsByAccountId(int account_id)
        {
            List<RequestModel> foundRequests = new List<RequestModel>();

            // SQL code to get requests by account id from database
            string sqlStatement = @"SELECT * FROM dbo.Requests
                                    WHERE ACCOUNT_ID = @Account_Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Account_Id", account_id);

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

        public List<RequestModel> GetIncomingRequestForAccount(int account_id)
        {
            List<RequestModel> foundRequests = new List<RequestModel>();

            // SQL code to requesst from a account
            string sqlStatement = @"SELECT r.ID, r.PRODUCT_NAME, r.PRODUCT_ID, r.ACCOUNT_NAME, r.ACCOUNT_ID
                                    FROM dbo.Requests r
                                    INNER JOIN dbo.Products p ON r.PRODUCT_ID = p.Id
                                    WHERE p.ACCOUNT_ID = @AccountId";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@AccountId", account_id);

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

            // SQL code to add a request in database
            string sqlStatement = @"INSERT INTO dbo.Requests (PRODUCT_NAME, PRODUCT_ID, ACCOUNT_NAME, ACCOUNT_ID)
                                    VALUES (@ProductName, @ProductId, @AccountName, @AccountId)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ProductName", request.ProductName);
                command.Parameters.AddWithValue("@ProductId", request.ProductId);
                command.Parameters.AddWithValue("@AccountName", request.AccountName);
                command.Parameters.AddWithValue("@AccountId", request.AccountId);

                connection.Open();
                newIdNumber = command.ExecuteNonQuery();
            }
            return newIdNumber;
        }
    }
}
