using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.BillAggregate;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Bills.Commands
{
    public class CreateBillQueryHandler : IRequestHandler<CreateBillCommand, Result<Bill>>
    {
        private readonly ICreateRepository<Bill> _billRepository;
        private readonly IGetRepository<Guest, Guid> _guestRepository;
        public CreateBillQueryHandler(ICreateRepository<Bill> billRepository, IGetRepository<Guest, Guid> guestRepository)
        {
            _billRepository = billRepository;
            _guestRepository = guestRepository;
        }
        public async Task<Result<Bill>> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetAsync(Guid.Parse(request.GuestId));
            if (guest is null) return null!;
            var bill = Bill.Create(
                DinnerId.Create(Guid.Parse(request.DinnerId)),
                GuestId.Create(Guid.Parse(request.GuestId)),
                HostId.Create(Guid.Parse(request.HostId)),
                Price.Create(
                    request.Amount,
                    request.Currency
                )
            );
            await _billRepository.AddAsync(bill);
            guest.AddBill(bill.Id);
            return bill;
        }
    }
}
