

using FluentValidation;

namespace ApplicationLayer.Services.Authentication.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {  
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}