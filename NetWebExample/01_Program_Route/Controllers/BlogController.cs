using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    //Rota parametresi:/blog/details/id=5
    //ParametreAdı (id),rota şablonundaki {id} ile aynı olmalı .Eşleştirmeyi "model binding" yapacak
    // blog/detals/abc {id:int} kısıtına uymaz bu rota devreye girmez
    public class BlogController : Controller
    {
        public IActionResult Details(int id)
        {
            ViewData["blogId"]=id;//Controllerdan View e veri taşımanın en bbasit yolu örneğin detay:ders 4
            return View();
        }
    }
}
