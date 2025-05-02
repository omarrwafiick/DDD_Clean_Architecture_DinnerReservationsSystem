  
using FluentValidation;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class GuestArrivedAtCommandValidator : AbstractValidator<GuestArrivedAtCommand>
    {
        public GuestArrivedAtCommandValidator() {
            RuleFor(x => x.ArrivalDateTime).NotEmpty(); 
        }
    }
}
