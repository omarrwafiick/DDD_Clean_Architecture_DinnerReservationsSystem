using ApplicationLayer.Common.Interfaces.Repositories; 
using DomainLayer.DinnerAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class GuestArrivedAtCommandHandler : IRequestHandler<GuestArrivedAtCommand, Result<Dinner>>
    {
        private readonly IUpdateRepository<Dinner> _updateDinnerRepository;
        private readonly IGetDinnerRepository _getDinnerRepository;
        public GuestArrivedAtCommandHandler( 
            IUpdateRepository<Dinner> updateDinnerRepository,
            IGetDinnerRepository getDinnerRepository)
        { 
            _updateDinnerRepository = updateDinnerRepository;
            _getDinnerRepository = getDinnerRepository;
        }

        public async Task<Result<Dinner>> Handle(GuestArrivedAtCommand request, CancellationToken cancellationToken)
        {
            var dinner = await _getDinnerRepository.GetDinnerAsync(Guid.Parse(request.DinnerId));
            dinner.ReservationIds.FirstOrDefault()!.GuestArrived(request.ArrivalDateTime);
            await _updateDinnerRepository.UpdateAsync(dinner);
            return dinner;
        }
    }
}
