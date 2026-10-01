namespace _14_Middlewares.Middlewares
{
    /*Extension Method:app.UseMiddleware<RequestLoggingMiddleware>(); yerine okunaklı bir app.UseRequestLogging() sunar
     * Framework'teki useroting usesession vb de aynı kalıpla yazılmıştır.
     */
    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
