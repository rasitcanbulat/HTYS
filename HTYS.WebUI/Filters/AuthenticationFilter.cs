using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HTYS.WebUI.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("KullaniciAdi")))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
