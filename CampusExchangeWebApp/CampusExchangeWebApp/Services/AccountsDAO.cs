using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class AccountsDAO : IAccountDataServices
    {
        bool success = false;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusExchange;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(AccountModel account)
        {
            int newIdNumber = -1;

            // SQL code to delete a Account by their id from database 
            string sqlStatement = "DELETE FROM dbo.Accounts WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", account.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public bool FindUserByNameAndPassword(AccountModel account)
        {
            // SQL code to get a Account with same username and password with the @ values
            string sqlStatement = "SELECT * FROM dbo.Accounts WHERE USERNAME = @UserName AND PASSWORD = @Password";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 40).Value = account.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 40).Value = account.Password;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        success = true;

                        account.Id = Convert.ToInt32(reader["ID"]);
                        account.Email = reader["EMAIL"].ToString();
                        account.Role = reader["ROLE"].ToString();
                    }   
                }
            }

            return success;
        }

        public AccountModel GetAccountById(int id)
        {
            AccountModel foundAccount = null;

            // SQL code to get a Account by their id from database
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

        public List<AccountModel> GetAllAccounts()
        {
            List<AccountModel> foundAccounts = new List<AccountModel>();

            // SQL code to get all Accounts from database
            string sqlStatement = "SELECT * FROM dbo.Accounts";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundAccounts.Add(new AccountModel { Id = (int)reader[0], UserName = (string)reader[1], Password = (string)reader[2], Email = (string)reader[3] });
                }
            }
            return foundAccounts;
        }

        public int Insert(AccountModel account)
        {
            int newIdNumber = -1;

            // SQL code to add a Account in database
            string sqlStatement = "INSERT INTO dbo.Accounts (USERNAME, PASSWORD, EMAIL) VALUES (@UserName, @Password, @Email)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@UserName", account.UserName);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@Email", account.Email);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public int Update(AccountModel account)
        {
            int newIdNumber = -1;

            // SQL code to update a Account by their id from database
            string sqlStatement = "UPDATE dbo.Accounts SET USERNAME = @UserName, PASSWORD = @Password, EMAIL = @Email WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@UserName", account.UserName);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@Id", account.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }
    }
}
