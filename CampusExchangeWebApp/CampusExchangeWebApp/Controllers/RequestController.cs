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

        // Accept
        public IActionResult ProcessAccept(LoanModel loan, int requestId)
        {
            RequestsDAO requests = new RequestsDAO();
            AccountsDAO accounts = new AccountsDAO();
            LoansDAO loans = new LoansDAO();

            string currentUsername = User.Identity.Name;
            int lenderAccountId = accounts.GetAccountByUserName(currentUsername);

            loan.LenderAccountId = lenderAccountId;
            loan.LenderAccountName = currentUsername;

            loans.Insert(loan);

            RequestModel request = requests.GetRequestById(requestId);
            if (request != null)
            {
                requests.Delete(request);
            }

            return RedirectToAction("MyLoans");
        }

        public IActionResult Accept(int id)
        {
            RequestsDAO requests = new RequestsDAO();
            RequestModel request = requests.GetRequestById(id);

            LoanModel loan = new LoanModel
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                BorrowerAccountId = request.AccountId,
                BorrowerAccountName = request.AccountName,
                ExpectedReturnDate = DateTime.Now.AddDays(7)
            };

            ViewBag.Requestid = request.Id;

            return View("Accept", loan);
        }

        // My Loans
        public IActionResult MyLoans()
        {
            AccountsDAO accounts = new AccountsDAO();
            LoansDAO loans = new LoansDAO();

            string username = User.Identity.Name;

            int accountId = accounts.GetAccountByUserName(username);

            var viewModel = new LoanModel
            {
                BorrowedLoans = loans.GetLoansByBorrowerAccountId(accountId),
                LendLoans = loans.GetLoansByLenderAccountId(accountId),
            };

            return View(viewModel);
        }

        // Return
        public IActionResult Return(int id)
        {
            AccountsDAO accounts = new AccountsDAO();
            LoansDAO loans = new LoansDAO();

            string currentUsername = User.Identity.Name;
            int currentAccountId = accounts.GetAccountByUserName(currentUsername);

            LoanModel loan = loans.GetLoanById(id);

            if (loan != null & loan.LenderAccountId == currentAccountId)
            {
                loans.Delete(loan);
            }

            return RedirectToAction("MyLoans");
        }
    }
}
