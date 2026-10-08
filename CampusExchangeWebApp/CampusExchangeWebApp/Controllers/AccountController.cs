using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            AccountsDAO products = new AccountsDAO();

            return View(products.GetAllAccounts());
        }

        // Details
        public IActionResult Details(int id)
        {
            AccountsDAO accounts = new AccountsDAO();
            AccountModel foundAccount = accounts.GetAccountById(id);
            return View(foundAccount);
        }


        // Edit
        public IActionResult Edit(int id)
        {
            AccountsDAO accounts = new AccountsDAO();
            AccountModel foundAccount = accounts.GetAccountById(id);
            return View("Edit", foundAccount);
        }
        public IActionResult ProcessEdit(AccountModel account)
        {
            AccountsDAO accounts = new AccountsDAO();
            accounts.Update(account);
            return View("Index", accounts.GetAllAccounts());
        }


        // Deleate
        public IActionResult Delete(int id)
        {
            AccountsDAO accounts = new AccountsDAO();
            AccountModel account = accounts.GetAccountById(id);
            accounts.Delete(account);
            return View("Index", accounts.GetAllAccounts());
        }


        // Create
        public IActionResult ProcessCreate(AccountModel account)
        {
            AccountsDAO accounts = new AccountsDAO();
            accounts.Insert(account);
            return View("Index", accounts.GetAllAccounts());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
