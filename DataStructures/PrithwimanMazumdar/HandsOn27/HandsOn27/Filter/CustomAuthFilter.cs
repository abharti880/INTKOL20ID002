using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Stripe.Issuing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;

namespace HandsOn27.Filter
{
    public class CustomAuthFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string authheader = filterContext.HttpContext.Request.Headers["Authorization"];
            if(authheader==null)
            {
                filterContext.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            }
            else if(!authheader.StartsWith("Bearer"))
            {
                filterContext.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer Unavailable");
            }
        }
    }
}
