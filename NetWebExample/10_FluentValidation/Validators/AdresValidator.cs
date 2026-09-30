using _10_FluentValidation.Models;
using FluentValidation;

namespace _10_FluentValidation.Validators
{
    public class AdresValidator:AbstractValidator<Adres>
    {
        public AdresValidator()
        {
            RuleFor(a => a.AdresTanim)
                .NotEmpty().WithMessage("Adres Tanım Boş bırakılamaz")
                .MaximumLength(100).WithMessage("Adres tanım en fazla 100 karakter olabilir");
            RuleFor(a => a.Sehir)
                .NotEmpty().WithMessage("Şehir boş bırakılamaz")
                .MaximumLength(50).WithMessage("Şehir tanım en fazla 50 karakter olabilir");
        }
    }
}
