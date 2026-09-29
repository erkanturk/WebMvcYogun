using _05_Html_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace _05_Html_Helpers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = new User { Name="Erkan", CountryList=GetCountries() };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(User user)
        {
            if (!ModelState.IsValid)
            {
                user.CountryList=GetCountries();//dropdown listesi post ile gelmez yeniden doldur
                return View("Index", user);//hatalarla birlikte formu tekrar göster
            }
            ViewBag.Message=$"Ad:{user.Name}, Yaş {user.Age}, Cinsiyet: {user.Gender}, Ülke:{user.Country}";
            return View("Result");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        private static IEnumerable<SelectListItem> GetCountries() =>
            [
                new SelectListItem("Türkiye","TR"),
                new SelectListItem("USA","US"),
                new SelectListItem("Japonya","JP"),

            ];
    }
}
