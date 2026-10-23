using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
        }


        // Search
        public IActionResult SearchResults(string searchTerm, string category)
        {
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> prouctList = products.SearchProducts(searchTerm, category);
            return View("index", prouctList);
        }
        public IActionResult Search()
        {
            return View();
        }


        // Details
        public IActionResult Details(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
    }
}
