using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
