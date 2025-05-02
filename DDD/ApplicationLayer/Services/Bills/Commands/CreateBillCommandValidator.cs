using FluentValidation;

namespace ApplicationLayer.Services.Bills.Commands
{
    public class CreateBillCommandValidator : AbstractValidator<CreateBillCommand>
    {
        public CreateBillCommandValidator()
        {
            RuleFor(x => x.HostId).NotEmpty();
            RuleFor(x => x.DinnerId).NotEmpty();
            RuleFor(x => x.GuestId).NotEmpty();
        }
    }
}
