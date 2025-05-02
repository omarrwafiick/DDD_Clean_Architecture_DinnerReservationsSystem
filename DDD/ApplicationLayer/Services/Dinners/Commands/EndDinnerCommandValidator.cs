  
using FluentValidation;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class EndDinnerCommandValidator : AbstractValidator<EndDinnerCommand>
    {
        public EndDinnerCommandValidator() {
            RuleFor(x => x.EndAt).NotEmpty(); 
        }
    }
}
