using _12_Dependency_Injection.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* Dependency Injection:Sınıflar ihtiyaç duydukları nesneleri iretmez constructor'dan ister buna Dışa bağımlılık enjeksiyonu denir.
 * Container kayıt sırasında verilen yaşam süresi (Lifetime) göre nesneyi üretir ve verir
 * Transient her istekte yeni bir nesne üretir
 * Scoped aynı istek boyunca aynı nesne üzerinden devam eder yeni istek yeni nesne oluşturur (dbcontext böyle kaydedilir)
 * Singleton uygulama ömrü boyunca tek nesne üzerinden devam eder (cache ayar gibi paylaşılan şeyler)
 * 
 * Normal kayı (günlüjk kullanım %99'u)
 * builder.Services.AddScoped<IRandomNumberService, ScopedRandomNumberService>(); ı kullanır
 * 
 * 
 */
builder.Services.AddKeyedScoped<IRandomNumberService, ScopedRandomNumberService>("scoped");
builder.Services.AddKeyedTransient<IRandomNumberService, TransientRandomNumberService>("transient");
builder.Services.AddKeyedSingleton<IRandomNumberService, SingletonRandomNumberService>("singleton");

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
