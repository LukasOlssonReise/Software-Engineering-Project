using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class LoansDAO : ILoanDataServices
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=CampusExchange;
                                    Integrated Security=True;
                                    Connect Timeout=30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";
        public List<LoanModel> GetLoansByAccountId(int account_id)
        {
            List<LoanModel> foundloans = new List<LoanModel>();

            // SQL code to get loan by account id from database
            string sqlStatement = @"SELECT * FROM dbo.Loans
                                    WHERE BORROWER_ACCOUNT_ID = @AccountId
                                    OR LENDER_ACCOUNT_ID = @AccountId";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@AccountId", account_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundloans.Add(new LoanModel
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[1],
                        ProductName = (string)reader[2],
                        BorrowerAccountId = (int)reader[3],
                        BorrowerAccountName = (string)reader[4],
                        LenderAccountId = (int)reader[5],
                        LenderAccountName = (string)reader[6],
                        ExpectedReturnDate = (DateTime)reader[7],
                        LoanDate = (DateTime)reader[8]
                    });
                }
            }
            return foundloans;
        }

        public LoanModel GetLoanById(int id)
        {
            LoanModel foundLoan = null;

            // SQL code to get a loan by their id from database
            string sqlStatement = @"SELECT * FROM dbo.Loans
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
                    foundLoan = new LoanModel
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[1],
                        ProductName = (string)reader[2],
                        BorrowerAccountId = (int)reader[3],
                        BorrowerAccountName = (string)reader[4],
                        LenderAccountId = (int)reader[5],
                        LenderAccountName = (string)reader[6],
                        ExpectedReturnDate = (DateTime)reader[7],
                        LoanDate = (DateTime)reader[8]
                    };
                }
            }
            return foundLoan;
        }

        public int Insert(LoanModel loan)
        {
            int newIdNumber = -1;

            // SQL code to add a loan in database
            string sqlStatement = @"INSERT INTO dbo.Loans (PRODUCT_ID, PRODUCT_NAME, BORROWER_ACCOUNT_ID, BORROWER_ACCOUNT_NAME, LENDER_ACCOUNT_ID, LENDER_ACCOUNT_NAME, EXPECTED_RETURN_DATE, LOAN_DATE)
                                    VALUES (@Productid, @ProductName, @BorrowerAccountId, @BorrowerAccountName, @LenderAccountId, @LenderAccountName, @ExpectedReturnDate, @LoanDate)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ProductId", loan.ProductId);
                command.Parameters.AddWithValue("@ProductName", loan.ProductName);
                command.Parameters.AddWithValue("@BorrowerAccountId", loan.BorrowerAccountId);
                command.Parameters.AddWithValue("@BorrowerAccountName", loan.BorrowerAccountName);
                command.Parameters.AddWithValue("@LenderAccountId", loan.LenderAccountId);
                command.Parameters.AddWithValue("@LenderAccountName", loan.LenderAccountName);
                command.Parameters.AddWithValue("@ExpectedReturnDate", loan.ExpectedReturnDate);
                command.Parameters.AddWithValue("@LoanDate", loan.LoanDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return newIdNumber;
        }

        public int Delete(LoanModel loan)
        {
            int newIdNumber = -1;

            // SQL code to delete a loan by their id from database 
            string sqlStatement = @"DELETE FROM dbo.Loans
                                    WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", loan.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public List<LoanModel> GetLoansByBorrowerAccountId(int account_id)
        {
            List<LoanModel> foundLoans = new List<LoanModel>();

            // SQL code to get every loan from borrower account
            string sqlStatement = @"SELECT * FROM dbo.Loans WHERE BORROWER_ACCOUNT_ID = @BorrowAccountId";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@BorrowAccountId", account_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundLoans.Add(new LoanModel
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[1],
                        ProductName = (string)reader[2],
                        BorrowerAccountId = (int)reader[3],
                        BorrowerAccountName = (string)reader[4],
                        LenderAccountId = (int)reader[5],
                        LenderAccountName = (string)reader[6],
                        ExpectedReturnDate = (DateTime)reader[7],
                        LoanDate = (DateTime)reader[8]
                    });
                }
            }
            return foundLoans;
        }

        public List<LoanModel> GetLoansByLenderAccountId(int account_id)
        {
            List<LoanModel> foundLoans = new List<LoanModel>();

            // SQL code to get every loan from lender account'
            string sqlStatement = @"SELECT * FROM dbo.Loans WHERE LENDER_ACCOUNT_ID = @LenderAccountId";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@LenderAccountId", account_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundLoans.Add(new LoanModel
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[1],
                        ProductName = (string)reader[2],
                        BorrowerAccountId = (int)reader[3],
                        BorrowerAccountName = (string)reader[4],
                        LenderAccountId = (int)reader[5],
                        LenderAccountName = (string)reader[6],
                        ExpectedReturnDate = (DateTime)reader[7],
                        LoanDate = (DateTime)reader[8]
                    });
                }
            }
            return foundLoans;
        }
    }
}
