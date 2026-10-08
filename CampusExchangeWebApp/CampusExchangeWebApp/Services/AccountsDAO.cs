using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class AccountsDAO : IAccountDataServices
    {
        bool success = false;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusExchange;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public bool FindUserByNameAndPassword(AccountModel user)
        {
            // SQL code to get a user with same username and password with the @ values
            string sqlStatement = "SELECT * FROM dbo.Accounts WHERE USERNAME = @UserName AND PASSWORD = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    success = true;
                }
            }

            return success;
        }

        public AccountModel GetAccountById(int id)
        {
            AccountModel foundAccount = null;

            // SQL code to get a user by their id from database
            string sqlStatement = "SELECT * FROM dbo.Accounts WHERE Id = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundAccount = new AccountModel { Id = (int)reader[0], UserName = (string)reader[1], Password = (string)reader[2], Email = (string)reader[3] };
                }
            }
            return foundAccount;
        }
    }
}
