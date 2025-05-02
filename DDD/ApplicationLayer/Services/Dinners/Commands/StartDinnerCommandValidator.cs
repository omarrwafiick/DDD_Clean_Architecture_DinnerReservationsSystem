  
using FluentValidation;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class StartDinnerCommandValidator : AbstractValidator<StartDinnerCommand>
    {
        public StartDinnerCommandValidator() {
            RuleFor(x => x.StartAt).NotEmpty(); 
        }
    }
}
