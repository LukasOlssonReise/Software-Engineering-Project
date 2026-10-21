using CampusExchangeWebApp.Models;
using Microsoft.Data.SqlClient;

namespace CampusExchangeWebApp.Services
{
    public class ProductsDAO : IProductDataServices
    {
        // Connection string for database
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusExchange;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;

            // SQL code to delete a product by their id from database 
            string sqlStatement = "DELETE FROM dbo.Products WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", product.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            // SQL code to get all products from database
            string sqlStatement = "SELECT * FROM dbo.Products";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProducts.Add(new ProductModel
                    { 
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Description = (string)reader[2],
                        Category = (string)reader[3],
                        AccountId = (int)reader[5]
                    });
                }
            }
            return foundProducts;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            // SQL code to get a product by their id from database
            string sqlStatement = "SELECT * FROM dbo.Products WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProduct = new ProductModel
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Description = (string)reader[2],
                        Category = (string)reader[3],
                        AccountId = (int)reader[5]
                    };
                }
            }
            return foundProduct;
        }

        public List<ProductModel> GetProductsByAccountId(int account_id)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            // SQL code to get all products from database
            string sqlStatement = "SELECT * FROM dbo.Products WHERE ACCOUNT_ID = @Account_Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Account_Id", account_id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProducts.Add(new ProductModel
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Description = (string)reader[2],
                        Category = (string)reader[3],
                        Photo = reader[4] != DBNull.Value ? System.Text.Encoding.UTF8.GetString((byte[])reader[4]) : null,
                        AccountId = (int)reader[5]
                    });
                }
            }
            return foundProducts;
        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = -1;

            // SQL code to add a product in database
            string sqlStatement = "INSERT INTO dbo.Products (NAME, DESCRIPTION, CATEGORY, ACCOUNT_ID) VALUES (@Name, @Description, @Category, @AccountId)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@AccountId", product.AccountId);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public List<ProductModel> SearchProducts(string searchTerm, string category)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            // SQL code to get products with by their Name from database
            string sqlStatement = "SELECT * FROM dbo.Products WHERE NAME LIKE @Name";

            // If one of category is selected
            bool filterByCategory = !string.IsNullOrEmpty(category) && category != "All";
            if (filterByCategory)
            {
                sqlStatement += " AND CATEGORY LIKE @Category";
            }

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
                if (filterByCategory)
                {
                    command.Parameters.AddWithValue("@Category", '%' + category + '%');
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProducts.Add(new ProductModel
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Description = (string)reader[2],
                        Category = (string)reader[3],
                        AccountId = (int)reader[5]
                    });
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;

            // SQL code to update a product by their id from database
            string sqlStatement = "UPDATE dbo.Products SET NAME = @Name, DESCRIPTION = @Description, CATEGORY = @Category WHERE ID = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@Id", product.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }
    }
}
