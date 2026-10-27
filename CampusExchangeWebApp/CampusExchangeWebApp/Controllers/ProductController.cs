using System.Security.Principal;
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
        [Authorize]
        public IActionResult Details(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }


        // Edit
        [Authorize]
        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
        [Authorize]
        public IActionResult ProcessEdit(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }

            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return RedirectToAction("MyItems", "Account");
        }


        // Delete
        [Authorize]
        public IActionResult Delete(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return RedirectToAction("MyItems", "Account");
        }


        // Create
        [Authorize]
        public IActionResult ProcessCreate(ProductModel product)
        {

            ProductsDAO products = new ProductsDAO();
            AccountsDAO accounts = new AccountsDAO();

            string currentUsername = User.Identity.Name;
            int accountId = accounts.GetAccountByUserName(currentUsername);

            product.OwnerId = accountId;

            products.Insert(product);
            return RedirectToAction("MyItems", "Account");
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
    }
}
