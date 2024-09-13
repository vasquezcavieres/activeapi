using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Cl.Intertrade.ActivPay.Helpers.Security
{
    [AttributeUsage(validOn: AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "XApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }

        public static string GetApiKey(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey);
            return extractedApiKey;
        }
    }
}
