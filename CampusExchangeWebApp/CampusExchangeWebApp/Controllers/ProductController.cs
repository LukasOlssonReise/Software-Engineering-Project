using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
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
            return View(foundProduct);
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return RedirectToAction("MyItems", "Account");
        }


        // Delete
        public IActionResult Delete(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return RedirectToAction("MyItems", "Account");
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
            return RedirectToAction("MyItems", "Account");
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
