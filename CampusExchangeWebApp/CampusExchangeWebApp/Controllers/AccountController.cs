using System.Security.Claims;
using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using CampusExchangeWebApp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class AccountController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AccountsDAO products = new AccountsDAO();

            return View(products.GetAllAccounts());
        }

        // Login
        public async Task<IActionResult> LoginProcess(AccountModel user)
        {
            // Logger
            MyLogger.GetInstance().Info("Processing a Login attempt");
            MyLogger.GetInstance().Info(user.toString());

            SecurityService securityService = new SecurityService();

            if (securityService.isValid(user))
            {
                MyLogger.GetInstance().Info("Login Sucess");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                MyLogger.GetInstance().Warn("Login Failure");

                ViewBag.ErrorMessage = "Invalid username or password, Please try again.";

                return View("Login", user);
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
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
