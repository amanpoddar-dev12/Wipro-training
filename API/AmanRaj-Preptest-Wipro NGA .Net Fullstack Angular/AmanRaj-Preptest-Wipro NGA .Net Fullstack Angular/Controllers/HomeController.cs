using System.Diagnostics;
using AmanRaj_Preptest_Wipro_NGA_.Net_Fullstack_Angular.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmanRaj_Preptest_Wipro_NGA_.Net_Fullstack_Angular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
