using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoFang.MobileSite.Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MoFang.MobileSite.Dashboard.Filters
{
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var securityManager = context.HttpContext.RequestServices.GetService<OASecurityManager>();

            if (securityManager.IsLogin)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                string url = this.GetRedirectUrl(context.HttpContext.Request);

                context.Result = new RedirectToActionResult("Login", "Account", new { redirect = url });
            }
        }

        private string GetRedirectUrl(HttpRequest request)
        {
            var builder = new UriBuilder()
            {
                Path = request.Path,
                Query = request.QueryString.ToUriComponent()
            };

            return builder.Uri.PathAndQuery;
        }
    }
}
