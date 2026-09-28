using CampusExchangeWebApp.Models;
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
            if (userModel.Name == "123" && userModel.Password == "123")
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
