using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            AccountsDAO accounts = new AccountsDAO();
            AccountModel foundAccount = accounts.GetAccountById(id);
            return View(foundAccount);
        }
    }
}
