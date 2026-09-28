using _03_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ViewToController.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Post: form fönderildiğinde çalışır aynı isim farklı http methodu => overload
        //Model bindig:formdaki name="ad" parametre "ad" name kisiler="kisiler"
        //bool onay =false checkbox işaretlenmezse tarayıcı o alanı hiç göndermez ,varsayılan(optional) false kalır.
        [HttpPost]
        [ValidateAntiForgeryToken] //CSRF koruması:form tag helper'ı gizli bir token ekler burada doğrulanır.
        public IActionResult Index(string ad,string kisiler,bool onay=false)
        {
            ViewBag.Mesaj=$"Ad: {ad}, Seçilen:{kisiler}, Onay: {(onay ? "Evet" : "Hayır")}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
