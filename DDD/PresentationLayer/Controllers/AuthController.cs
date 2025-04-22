using ApplicationLayer.Services.Authentication;
using Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Utilities;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController(IAuthService authService) : ErrorHandlerController
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthResult> result = authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return result.IsSuccess ? Ok(MapResults.MapAuthResult(result.Value)) 
                : Problem(result.Errors); 
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = authService.Login(request.Email, request.Password);
            return result.IsSuccess ? Ok(MapResults.MapAuthResult(result.Value))
                : Problem(result.Errors);
        } 
    }
     
}
