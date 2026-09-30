using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection.Controllers
{
    //Constructor Injection:ihtiyaçlar parametre olarak yazılır,container üretip verir 
    //Aynı servisi iki kez isteyip değerleri karşılaştırarak yaşam sürelerini göreceğiz
    //[FromKeyedServices] aynı interface'in hangi kaydı istendiğini söyler 
    public class HomeController([FromKeyedServices("transient")] IRandomNumberService transient1,
        [FromKeyedServices("transient")] IRandomNumberService transient2,
        [FromKeyedServices("scoped")] IRandomNumberService scoped1,
        [FromKeyedServices("scoped")] IRandomNumberService scoped2,
        [FromKeyedServices("singleton")] IRandomNumberService singleton1,
        [FromKeyedServices("singleton")] IRandomNumberService singleton2
        ) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Transient1=transient1.GetRandomNumber();
            ViewBag.Transient2=transient2.GetRandomNumber();

            ViewBag.Singleton1=singleton1.GetRandomNumber();
            ViewBag.singleton2=singleton2.GetRandomNumber();

            ViewBag.Scoped1 = scoped1.GetRandomNumber();
            ViewBag.Scoped2=scoped2.GetRandomNumber();
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
