using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class UsersDAO
    {
        bool success = false;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusExchange;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public bool FindUserByNameAndPassword(UserModel user)
        {
            // SQL code to get a user with same username and password with the @ values
            string sqlStatement = "SELECT * FROM dbo.Users WHERE USERNAME = @UserName AND PASSWORD = @Password";

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
    }
}
