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


        // Edit
        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("Edit", foundProduct);
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }


        // Deleate
        public IActionResult Delete(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }


        // Create
        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            AccountsDAO accounts = new AccountsDAO();

            string currentUsername = User.Identity.Name;

            int accountId = accounts.GetAccountByUserName(currentUsername);

            product.AccountId = accountId;

            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
