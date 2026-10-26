using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class BrowseController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
        }


        // Search
        [AllowAnonymous]
        public IActionResult SearchResults(string searchTerm, string category)
        {
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> prouctList = products.SearchProducts(searchTerm, category);
            return View("index", prouctList);
        }
        [AllowAnonymous]
        public IActionResult Search()
        {
            return View();
        }


        // Details
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
    }
}
