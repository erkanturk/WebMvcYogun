using _10_FluentValidation.Models;
using FluentValidation;

namespace _10_FluentValidation.Validators
{
    public class KisiValidator:AbstractValidator<Kisi>
    {
        public KisiValidator()
        {
            RuleFor(k => k.Ad).NotEmpty().WithMessage("Ad Alanı boş bırakılamaz")
                .MaximumLength(50)
                .WithMessage("Max 50 karakter olmalı")
                .MinimumLength(3)
                .WithMessage("Minimum 3 karakter olmalı");
            RuleFor(k => k.Soyad).NotEmpty().WithMessage("Soyad Alanı boş bırakılamaz")
                .MaximumLength(50)
                .WithMessage("Max 50 karakter olmalı")
                .MinimumLength(3)
                .WithMessage("Minimum 3 karakter olmalı");
            RuleFor(k => k.Yas)
                .NotNull().WithMessage("Yaş Zorunludur.")
                .InclusiveBetween(1, 119).WithMessage("Yaş 1 ile 119 arasında olmalıdır");
        }
    }
}
