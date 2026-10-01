using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operation.Filters
{
    /* hattın en başında çalışır context.result atanırsa action hiç çalışmaz
     * Gerçek projede bunu kendimiz yazmayız [Authorize] attribute ile aynı işi yapar 
     */
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;//isteği yapan kullanıcı kimliği

            //?.ve ??: Identity null olabilir null ise giriş yapmamış.
            var girisYapilmis=user.Identity?.IsAuthenticated ?? false;

            if (!girisYapilmis)
            {
                context.Result=new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
