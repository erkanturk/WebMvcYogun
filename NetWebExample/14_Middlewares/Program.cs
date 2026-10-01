using _14_Middlewares.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
/* Middleware isteğin geçici boru hattındaki (pipeline) her bir halka
 * Her halka 1 isteği görür sonrakine geçer yada geçmez donen cevabı görür
 * yazım sırası bu yüzden program.cs satır sırası önemlidir.
 */
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Ders", "14-Middlewares");
    await next(context);
});
app.Use(async (context, next) =>
{
    if (context.Request.Path=="/ping")
    {
        context.Response.ContentType="text/plain;charset=utf-8";
        await context.Response.WriteAsync("pong");
        return;
    }
    await next(context);
});
app.UseRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
