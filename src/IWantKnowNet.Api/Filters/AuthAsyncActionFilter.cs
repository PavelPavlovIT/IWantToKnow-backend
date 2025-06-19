using IWantKnowNet.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace IWantKnowNet.Api.Filters;

public class AuthActionFilter() : IActionFilter
{
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        //var auth = context.HttpContext.User.Identity is { IsAuthenticated: true };
        //if (auth)
        //{

        //    var user = context.HttpContext.User.Identity?.Name;
            
        //}
    }
}