using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Book_Store.middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var problem = new ProblemDetails
                {
                    Status = httpContext.Response.StatusCode,
                    Title = ex.Message,
                };
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }
    }
}
