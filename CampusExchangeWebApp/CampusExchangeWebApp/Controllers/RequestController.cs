using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class RequestController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            RequestsDAO requests = new RequestsDAO();

            return View(requests.GetAllRequests());
        }

        // My Requests
        public IActionResult MyRequests()
        {
            RequestsDAO requests = new RequestsDAO();
            AccountsDAO accounts = new AccountsDAO();

            string username = User.Identity.Name;

            int accountId = accounts.GetAccountByUserName(username);

            var viewModel = new RequestModel
            {
                SentRequests = requests.GetRequestsByAccountId(accountId),
                IncomingRequests = requests.GetIncomingRequestForAccount(accountId),
            };

            return View(viewModel);
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

            return RedirectToAction("Index", "Browse");
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


        // Reject
        public IActionResult Reject(int id)
        {
            RequestsDAO requests = new RequestsDAO();
            RequestModel request = requests.GetRequestById(id);
            requests.Delete(request);
            return RedirectToAction("MyRequests", "Request");
        }
    }
}
