using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginProcess(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.isValid(userModel))
            {
                return View("LoginSucess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
