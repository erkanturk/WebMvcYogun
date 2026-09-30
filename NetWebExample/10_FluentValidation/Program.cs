using _10_FluentValidation.Validators;
using _10_FluentValidation.ViewModel;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*FluentValidation :Her model için bir validator sınıfı DI'a kaydedilir controller Ivalidator<T> ister
 * Alt validator'lar (KisiValidator,AdresValidator) setValidator ile bağlandığı için ayrıca kaydetmeye gerek yok
 * Coç validator varsa FluentValidation.DependencyIncectionExtension paketi+AddValidatorsFormAssemblyContaining kullanılabilir.
 */
builder.Services.AddScoped<IValidator<HomePageViewModel>, HomePageViewModelValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
