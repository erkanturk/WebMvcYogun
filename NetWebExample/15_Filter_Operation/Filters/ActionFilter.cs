using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operation.Filters
{
    //Action Filter:Action metodunun hemen öncesi ve sonrası
    //Kullanım alanı loglama süre ölçme ModelState kontrol ve cache
    public class ActionFilter(ILogger<ActionFilter> logger) : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Sonra:{Action} tamamlandı", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Önce:{Action} tamamlandı", context.ActionDescriptor.DisplayName);
        }
    }
}
