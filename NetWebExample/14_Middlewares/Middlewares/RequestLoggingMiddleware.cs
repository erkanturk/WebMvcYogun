using System.Diagnostics;

// Sınıf tabanlı middleware (convention-based):
//  - constructor'da RequestDelegate next alır (sıradaki halka)
//  - public Task InvokeAsync(HttpContext context) metodu olmalı
//  - Middleware uygulama boyunca TEK nesnedir (singleton gibi). Bu yüzden constructor'a sadece singleton servisler
//    (ILogger gibi) verilir; scoped servisler (DbContext) InvokeAsync parametresi olarak alınır.
namespace _14_Middlewares.Middlewares
{
    public class RequestLoggingMiddleware(RequestDelegate next ,ILogger<RequestDelegate> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var start = Stopwatch.GetTimestamp();
            context.Items["MiddlewareMessage"]=$"Middleware çalıştı:{context.Request.Method} {context.Request.Path}";
            //Httpcontext.Items aynı istek için middleware controller arası veri taşımak için kullanım

            await next(context);
            var elapsed = Stopwatch.GetElapsedTime(start);
            logger.LogInformation("{Method} {Path} {StatusCode} {Elapsed:F1} ms",
                context.Request.Method,context.Request.Path,context.Response.StatusCode,elapsed.TotalMilliseconds);
        }
    }
}
