using ApplicationLayer.Services;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            return Ok( new AuthResponse (result.id, result.Email, result.FirstName, result.LastName, result.Token)); 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = authService.Login(request.Email, request.Password);
            return Ok(new AuthResponse(result.id, result.Email, result.FirstName, result.LastName, result.Token));
        }
    }
}
