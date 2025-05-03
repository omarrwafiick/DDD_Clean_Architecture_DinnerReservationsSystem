using ApplicationLayer.Common.Interfaces.Repositories;
using ApplicationLayer.Services.Bills.Queries;
using DomainLayer.BillAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Bills.Commands
{
    public class GetBillQueryHandler : IRequestHandler<GetBillQuery, Result<Bill>>
    { 
        private readonly IGetRepository<Bill, Guid> _billRepository;
        public GetBillQueryHandler(IGetRepository<Bill, Guid> billRepository)
        {
            _billRepository = billRepository;
        }
        public async Task<Result<Bill>> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetAsync(
                Guid.Parse(request.billid), 
                x => x.GuestId.Value == Guid.Parse(request.guestid)); 
            return bill;
        }
    }
}
