using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Services.Bills.Queries;
using DomainLayer.BillAggregate;
using DomainLayer.BillAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Bills.Commands
{
    public class GetBillQueryHandler : IRequestHandler<GetBillQuery, Result<Bill>>
    { 
        private readonly IGetRepository<Bill, BillId> _billRepository;
        public GetBillQueryHandler(IGetRepository<Bill, BillId> billRepository)
        {
            _billRepository = billRepository;
        }
        public async Task<Result<Bill>> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetAsync(
                BillId.Create(Guid.Parse(request.billid)), 
                x => x.GuestId.Value == Guid.Parse(request.guestid)); 
            return bill;
        }
    }
}
