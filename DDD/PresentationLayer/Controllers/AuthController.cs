using ApplicationLayer.Services.Authentication.Commands;
using ApplicationLayer.Services.Authentication.Common;
using ApplicationLayer.Services.Authentication.Queries;
using Contracts.Authentication;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers 
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController(ISender mediator, IMapper mapper) : ErrorHandlerController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = mapper.Map<RegisterCommand>(request);
            Result<AuthResult> result = await mediator.Send(command);

            return result.IsSuccess ? Ok(mapper.Map<AuthResponse>(result))
                : Problem(result.Errors); 
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = mapper.Map<LoginQuery>(request);
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(mapper.Map<AuthResponse>(result))
                : Problem(result.Errors);
        } 
    }
     
}
