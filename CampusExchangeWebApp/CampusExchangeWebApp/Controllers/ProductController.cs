using CampusExchangeWebApp.Models;
using CampusExchangeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusExchangeWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();

            return View(hardCodedSampleDataRepository.GetAllProducts());
        }
    }
}
