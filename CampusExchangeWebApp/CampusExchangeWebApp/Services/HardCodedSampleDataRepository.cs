using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public class HardCodedSampleDataRepository : IProductDataServices
    {
        List<ProductModel> productsList = new List<ProductModel>();
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            productsList.Add(new ProductModel { Id = 1, Name = "Keyboard", Description = "Keyboard is very important to type things" });
            productsList.Add(new ProductModel { Id = 2, Name = "Mouse", Description = "Mouse is not a real mouse, you know the animal..." });
            productsList.Add(new ProductModel { Id = 3, Name = "Mouse Pad", Description = "Mouse need something to glide on" });

            return productsList;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
