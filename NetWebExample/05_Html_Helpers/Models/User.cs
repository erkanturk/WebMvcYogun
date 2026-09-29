using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _05_Html_Helpers.Models
{
    //Data Annotations:Doğrulama kuralları property'nin üstüne attribute olarak yazılır
    //Hem sunucu  hem istemci tarafında çalışır.
    public class User
    {
        [Required(ErrorMessage ="Ad zorunludur")]
        [Display(Name ="Ad")]//LAbelFor bu metni kullanacak
        public string? Name { get; set; }
        [Range(18,120,ErrorMessage ="Yaş 18 ile 120 arasında olmalıdır.")]
        [Display(Name = "Yaş")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Cinsiyet Zorunludur")]
        [Display(Name = "Cinsiyet")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Ülke zorunludur")]
        [Display(Name = "Ülke")]
        public string? Country { get; set; }

        public IEnumerable<SelectListItem> CountryList { get; set; } = [];
    }
}
