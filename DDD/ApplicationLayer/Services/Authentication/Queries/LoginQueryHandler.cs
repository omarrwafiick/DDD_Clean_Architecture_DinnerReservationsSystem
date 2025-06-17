 
using ApplicationLayer.Common.Errors;
using ApplicationLayer.Common.Interfaces.JwtToken;
using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Services.Authentication.Common;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthResult>>
    {
        private readonly IJwtTokenGenerator _tokenGenrator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator tokenGenrator, IUserRepository userRepository)
        {
            _tokenGenrator = tokenGenrator;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user is null)
            {
                return Result.Fail<AuthResult>(
                new[] { new UserNotFoundError() {
                    Message ="Incorrect email"
                }});
            }
            if (user.Password != request.Password)
            {
                return Result.Fail<AuthResult>(
                new[] { new UserNotFoundError() {
                    Message ="Incorrect password"
                }});
            }
            var token = _tokenGenrator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
