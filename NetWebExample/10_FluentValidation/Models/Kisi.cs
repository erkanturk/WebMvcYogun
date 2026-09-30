using System.ComponentModel.DataAnnotations;

namespace _10_FluentValidation.Models
{
    public class Kisi
    {
        [Display(Name = "Ad")]
        public string? Ad { get; set; }
        [Display(Name = "Soyad")]
        public string? Soyad { get; set; }
        [Display(Name = "Yaş")]
        public int? Yas { get; set; }
    }
}
