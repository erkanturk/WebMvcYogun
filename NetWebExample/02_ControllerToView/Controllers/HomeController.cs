using _02_ControllerToView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]//yazılmasa bile varsayılan Get'tir
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3" };
            ViewData["Products"]=products;
            ViewBag.Baslik="Ürün Listesi";
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["Product"]=$"Ürün {id} Detayları";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
