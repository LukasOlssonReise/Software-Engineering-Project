using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface IProductDataServices
    {
        List<ProductModel> GetAllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);
    }
}
