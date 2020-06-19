using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class CustomAuthFilter: ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext context)
    {
        string str = context.HttpContext.Request.Headers["Authorization"];
        if(str==null)
        {
            context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
        }
        else if(!str.StartsWith("Bearer"))
        {
            context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
        }
    }
}
