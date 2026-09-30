using _09_ModelBinding.Models;

namespace _09_ModelBinding.ViewModel
{
    public class HomePageViewModel
    {
        public Kisi KisiNesnesi { get; set; } = new();//Boş nesneyi başlat hata verme
        public Adres AdresNesnesi { get; set; } = new();
    }
}
