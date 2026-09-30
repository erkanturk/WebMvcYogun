using _10_FluentValidation.Models;

namespace _10_FluentValidation.ViewModel
{
    public class HomePageViewModel
    {
        public Kisi KisiNesnesi { get; set; } = new();//Boş nesneyi başlat hata verme
        public Adres AdresNesnesi { get; set; } = new();
    }
}
