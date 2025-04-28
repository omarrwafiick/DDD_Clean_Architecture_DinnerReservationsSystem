using ApplicationLayer.Common.Errors;
using ApplicationLayer.Common.Interfaces.JwtToken;
using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Services.Authentication.Common;
using DomainLayer.UserAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResult>>
    {
        private readonly IJwtTokenGenerator _tokenGenrator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator tokenGenrator, IUserRepository userRepository)
        {
            _tokenGenrator = tokenGenrator;
            _userRepository = userRepository;
        }
        public async Task<Result<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                return Result.Fail<AuthResult>(
                new[] { new DuplicateEmailError() {
                    Message ="User was not found"
                }});
            }

            Guid userid = Guid.NewGuid();
            var user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);
            
            _userRepository.Add(user);
            var token = _tokenGenrator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
