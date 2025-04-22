using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PresentationLayer.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            var message = new ProblemDetails()
            {
                Type = "someplace",
                Title = "An error occured unfortunately",
                Status = StatusCodes.Status500InternalServerError,
            };
             

            context.Result = new ObjectResult(message)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
