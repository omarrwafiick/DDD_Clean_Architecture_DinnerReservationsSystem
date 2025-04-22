using System.Net;
using System.Text.Json;

namespace PresentationLayer.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) {
                await HandleException(context, ex);
            }
        }

        private async Task<Task> HandleException(HttpContext context, Exception ex)
        { 
            var result = JsonSerializer.Serialize(new { error = "An error occured unfortunately" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
