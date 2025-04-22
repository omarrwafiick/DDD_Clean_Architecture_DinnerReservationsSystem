
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{  
    public class ErrorHandlerController : ControllerBase
    {
        public IActionResult Problem(List<IError> errors)
        {
            var messages = errors.Select(e => e.Message).ToList();
             
            var problemDetails = new ProblemDetails
            {
                Title = "Multiple errors occurred",
                Status = 400,
                Detail = "Check the 'errors' field for more details.",
            };

            problemDetails.Extensions["errors"] = messages;

            return BadRequest(problemDetails);
        }
    }
}
