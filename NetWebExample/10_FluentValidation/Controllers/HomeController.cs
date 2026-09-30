using _10_FluentValidation.Models;
using _10_FluentValidation.ViewModel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_FluentValidation.Controllers
{
    public class HomeController(IValidator<HomePageViewModel> validator) : Controller
    {
        public IActionResult Index()
        {
            return View(new HomePageViewModel());//Boş model form boş açılsın
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(HomePageViewModel model)
        {
            ValidationResult result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("Index", model);
            }
            return RedirectToAction(nameof(Success));
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}
