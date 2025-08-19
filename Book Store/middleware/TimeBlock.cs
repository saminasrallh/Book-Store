using Microsoft.AspNetCore.Http;
using System;
using System.Security.AccessControl;
using System.Threading.Tasks;
namespace Book_Store.middleware
{
    public class TimeBlock
    {
        private readonly RequestDelegate _next;

        public TimeBlock(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var hour = DateTime.Now.Hour;
            if (hour >= 22 || hour < 6)
            {
                //httpContext.Response.StatusCode = 403;
                await httpContext.Response.WriteAsync("The site is closed");

            }
             await _next(httpContext);
        }
    }

    
}
