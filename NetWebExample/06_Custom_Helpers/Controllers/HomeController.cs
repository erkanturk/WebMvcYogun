using _06_Custom_Helpers.Helpers;
using _06_Custom_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _06_Custom_Helpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message=StringHelpers.CapitalizeWords("bugün hava çok güzel");
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
