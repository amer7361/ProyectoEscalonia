using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LaEscalonia.Middlewares
{
    public class ValidateSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("User") == null)
            {
                context.Result = new RedirectToActionResult("Login", "Authentication", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
