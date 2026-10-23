using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            RequestsDAO requests = new RequestsDAO();

            return View(requests.GetAllRequests());
        }


        // Borrow
        public IActionResult ProcessBorrow(RequestModel request)
        {
            RequestsDAO requests = new RequestsDAO();
            AccountsDAO accounts = new AccountsDAO();

            string currentUsername = User.Identity.Name;
            int accountId = accounts.GetAccountByUserName(currentUsername);

            request.AccountId = accountId;
            request.AccountName = currentUsername;

            requests.Insert(request);

            return View("Index", requests.GetAllRequests());
        }

        public IActionResult Borrow(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);

            RequestModel request = new RequestModel
            {
                ProductId = foundProduct.Id,
                ProductName = foundProduct.Name
            };

            return View("Borrow", request);
        }
    }
}
