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
            string sqlStatement = "DELETE FROM dbo.Products WHERE Id = @Id";

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
                    foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Description = (string)reader[2] });
                }
            }
            return foundProducts;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            // SQL code to get a product by their id from database
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Description = (string)reader[2] };
                }
            }
            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = -1;

            // SQL code to add a product in database
            string sqlStatement = "INSERT INTO dbo.Products (Name, Description) VALUES (@Name, @Description)";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            // SQL code to get products with by their Name from database
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Description = (string)reader[2] });
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;

            // SQL code to update a product by their id from database
            string sqlStatement = "UPDATE dbo.Products SET Name = @Name, Description = @Description WHERE Id = @Id";

            // Talk to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);

                connection.Open();
                newIdNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return newIdNumber;
        }
    }
}
