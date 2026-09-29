using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        /* ViewData: Sözlük (key-value) Sadece o istek için geçerli. Okurken cast gerekir.
         * Viewbag: ViewBag dynamic bir yapıdadır içerisinde bir çok değeri barındırır tek istek için geçerlidir.
         * TempData: 2 Action result boyunca çalışır Key value ilişkisi vardır Okununca bu veri silinir 
         * Keep ile korunur Peek ile silimeden okunur.
         */
        public IActionResult Index()
        {
            ViewBag.ad="Erkan";
            ViewBag.liste= new List<object> { "A", 10, 'B' };
            ViewBag.sonuc=true;

            ViewData["soyad"]="Türk";
            TempData["cinsiyet"]="Erkek";
            TempData.Keep("cinsiyet");
            return View();
        }

        public IActionResult Privacy()
        {
            //Viewbag.ad burada gelmeyeek Viewbag/ViewData sadece kendi isteğinde çalışır burada nulldur
            ViewBag.text=ViewBag.ad;
            //Keep yapısı sayesinde 2 istek boyunca veriyi taşıyacak
            TempData["c"]=TempData["cinsiyet"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
