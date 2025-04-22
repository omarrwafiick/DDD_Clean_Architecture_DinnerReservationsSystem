using ApplicationLayer.Common.Errors; 
using ApplicationLayer.Common.Interfaces.JwtToken;
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.Entities;
using FluentResults;

namespace ApplicationLayer.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _tokenGenrator;
        private readonly IUserRepository _userRepository;
        public AuthService(IJwtTokenGenerator tokenGenrator, IUserRepository userRepository)
        {
            _tokenGenrator = tokenGenrator;
            _userRepository = userRepository;
        }

        public Result<AuthResult> Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                return Result.Fail<AuthResult>(
                new[] { new UserNotFoundError() {
                    Message ="Incorrect email"
                }});
            }
            if (user.Password != password)
            {
                return Result.Fail<AuthResult>(
                new[] { new UserNotFoundError() {
                    Message ="Incorrect password"
                }});
            }
            var token = _tokenGenrator.GenerateToken(user);
            return new AuthResult(user, token);
        }
        
        public Result<AuthResult> Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Result.Fail<AuthResult>(
                new[] { new DuplicateEmailError() {
                    Message ="User was not found"
                }});
            }

            Guid userid = Guid.NewGuid();
            var user = new User
            {
                Id = userid,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);
            var token = _tokenGenrator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
