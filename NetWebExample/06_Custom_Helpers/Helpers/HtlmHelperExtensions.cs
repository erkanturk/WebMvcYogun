using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _06_Custom_Helpers.Helpers
{
    public static class HtlmHelperExtensions
    {
        public static IHtmlContent Etiket(this IHtmlHelper html, string metin, string renk = "primary")
        {
            //html.Encode metindeki < > gibi karakterleri kaldırır
            //HtmlString bu html güvenlidir olduğu gibi bas demektir razor @ hata vermez.
            return new HtmlString($"<span class=\"badge bg-{renk}\">{html.Encode(metin)}</span>");
        }
    }
}
