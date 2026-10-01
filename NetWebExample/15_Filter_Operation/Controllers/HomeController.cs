using _15_Filter_Operation.Filters;
using _15_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Filter_Operation.Controllers
{
    /* Filter:action çalışma önce/sonra araya giren kod Middleware den farklı  mvc yi bilir (hangi action hangi model).
     * Çalışma sırası Authorization > Resource > Action > Exception> Result olarak çalışıt
     * Bir action Service filter  bir controller'ın tamamına sınıfın üstüne tüm uygulamaya PRogram.cs ten globale uygulanabilir.
     */
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult Index()
        {
            logger.LogInformation("Index action çalışıyor (filteren önce ve sonra logları arasında)");
            return View();
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Privacy()
        {
            return View();
        }
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpecialAction()
        {
            throw new InvalidOperationException("Test Hatası");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
