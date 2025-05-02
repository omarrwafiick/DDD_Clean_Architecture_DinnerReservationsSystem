  
using FluentValidation;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class ReserveDinnerCommandValidator : AbstractValidator<ReserveDinnerCommand>
    {
        public ReserveDinnerCommandValidator() {
            RuleFor(x => x.GuestCount).NotEmpty();
            RuleFor(x => x.BillId).NotEmpty(); 
        }
    }
}
