using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using CampusExchangeWebApp.Utility;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CampusExchangeWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginProcess(UserModel user)
        {
            MyLogger.GetInstance().Info("Processing a Login attempt");
            MyLogger.GetInstance().Info(user.toString());

            SecurityService securityService = new SecurityService();

            if (securityService.isValid(user))
            {
                MyLogger.GetInstance().Info("Login Sucess");
                return View("LoginSucess", user);
            }
            else
            {
                MyLogger.GetInstance().Warn("Login Failure");
                return View("LoginFailure", user);
            }
        }
    }
}
