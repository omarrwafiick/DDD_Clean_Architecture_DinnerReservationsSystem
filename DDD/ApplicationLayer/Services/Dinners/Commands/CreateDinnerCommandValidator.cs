  
using FluentValidation;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class CreateDinnerCommandValidator : AbstractValidator<CreateDinnerCommand>
    {
        public CreateDinnerCommandValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty(); 
        }
    }
}
