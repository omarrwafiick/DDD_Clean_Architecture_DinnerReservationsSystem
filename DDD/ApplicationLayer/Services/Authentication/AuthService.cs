using ApplicationLayer.Common.Interfaces.Authentication;
using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.Entities;

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

        public AuthResult? Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user is null) return null;    
            if(user.Password != password) return null;
            var token = _tokenGenrator.GenerateToken(user);
            return new AuthResult(user, token);
        }

        public AuthResult? Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null) return null;
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
