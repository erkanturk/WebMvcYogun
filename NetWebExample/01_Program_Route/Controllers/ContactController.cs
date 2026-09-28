using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    /* Alternatif yöntem:Attribute Routing
     * Rota,Program.cs'teki genel kurallar yerine doğrudan sınıfın methodu üzerine yazılır.
     * Web Api projelerinde standart olarak budur (bkz.ders 16) Bir controller'a [Route] yazılınca
     * o controller artık Program.cs teki default rotayı kullanmaz sadece burada yazılanlara cevap verir.
     * 
     */
    [Route("iletisim")]
    [Route("[controller]")]
    public class ContactController:Controller
    {
        [Route("")]//iletişim ve /contact
        [Route("[action]")]//iletisim/index ve /contact/index
        public IActionResult Index()
        {
            return View();
        }

    }
}
