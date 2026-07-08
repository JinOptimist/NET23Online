using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebNet23Online.Data.Enums;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers.CustomAuthAttridute
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authService = context
                .HttpContext
                .RequestServices
                .GetRequiredService<IAuthService>();
            if(authService.GetRole()!=UserRole.Admin)
            {
                context.Result = ((Controller)context.Controller)
                    .RedirectToAction("Deny", "MaksKorzAdmin");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
