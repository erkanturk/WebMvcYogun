
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_Program_Route.Controllers
{
    /*
     * Controller:Gelen isteği karşılayan sınıf. Sınıf Adı "Controller" ile bitmeli ve Controller'dan türemeli
     * Adres Sınıf Method eşleşmesi :/Home/Index Homecontroller sınıfı index methodu
     */
    public class HomeController : Controller
    {
        //Action:dışarıya açık (public) ve sonuç (IActionResult) döndüren method.
        //View() Views/Home/Index.cshtml dosyalarını bulur html üretip tarayıcıda dönderecek.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

       
    }
}
