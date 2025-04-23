using ApplicationLayer.Services.Authentication.Commands;
using ApplicationLayer.Services.Authentication.Common;
using ApplicationLayer.Services.Authentication.Queries;
using Contracts.Authentication;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Utilities;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController(ISender mediator) : ErrorHandlerController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            Result<AuthResult> result = await mediator.Send(command);

            return result.IsSuccess ? Ok(MapResults.MapAuthResult(result.Value)) 
                : Problem(result.Errors); 
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(MapResults.MapAuthResult(result.Value))
                : Problem(result.Errors);
        } 
    }
     
}
