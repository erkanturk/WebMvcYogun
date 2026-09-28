var builder = WebApplication.CreateBuilder(args);//Ayarlar Loglama ve DI container burada hazırlanır

//Servisler Dependency Injection container
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();//Servis kaydı biter uygulama nesnesi oluşur

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) //Middleware hattı (pipeline) her istek bu sırayla geçer
{
    app.UseExceptionHandler("/Home/Error");//Canlıda hata olursa bu sayfaya yönlendirir.
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();//HTTPS ile gel der
}

app.UseHttpsRedirection();//Http ve Https
app.UseRouting();//Adresi rota şablonlarıyla eşleştirir

app.UseAuthorization();//Yetki kontrolü

app.MapStaticAssets();//wwwroot dosyaları (.net 9+ : eski useSataticFiles yerine:Sıkıştırma + önbellek + parmak izi)

//Rotalar
//Endpoint routing'de daha özel şablonlar kazanır: sabit bir kelime> kısıtlı parametre > parametre
//Yine de okunabilirlik için özel rotaları önce genel "default" rotayı en sona yazmak iyi alışkanlıktır
/* Özel rota 1 /Hakkimizda homecontroller.about aynı sayfa
 */
app.MapControllerRoute(
    name: "about",
    pattern: "Hakkimizda",
    defaults: new { controller = "Home", action = "About" }
    );
/* özel rota 2: blog/details/5 blogcontroller.details(id:5)
 * {id:int} rota kısıtı constraint id sadece tam sayı olabilir abc uygulanamaz.
 */
app.MapControllerRoute(
    name: "blogDetails",
    pattern: "blog/deails/{id:int}",
    defaults: new { controller = "Blog", action = "Details" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();//Uygulama istekleri dinlemeye başlar bundan sonra tanımlanan yapılar çalışmaz.
