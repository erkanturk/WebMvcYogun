using _10_FluentValidation.ViewModel;
using FluentValidation;

namespace _10_FluentValidation.Validators
{
    public class HomePageViewModelValidator:AbstractValidator<HomePageViewModel>
    {
        public HomePageViewModelValidator()
        {
            RuleFor(vm => vm.KisiNesnesi).SetValidator(new KisiValidator());
            RuleFor(vm => vm.AdresNesnesi).SetValidator(new AdresValidator());
        }
    }
}
