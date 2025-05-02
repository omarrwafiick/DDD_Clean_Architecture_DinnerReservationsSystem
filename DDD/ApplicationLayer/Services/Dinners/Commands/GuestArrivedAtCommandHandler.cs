using ApplicationLayer.Common.Interfaces.Repositories; 
using DomainLayer.DinnerAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class GuestArrivedAtCommandHandler : IRequestHandler<GuestArrivedAtCommand, Result<Dinner>>
    {
        private readonly IGetRepository<Dinner> _dinnerRepository;
        private readonly IUpdateRepository<Dinner> _updateDinnerRepository;
        public GuestArrivedAtCommandHandler( 
            IGetRepository<Dinner> dinnerRepository,
            IUpdateRepository<Dinner> updateDinnerRepository)
        { 
            _dinnerRepository = dinnerRepository;
            _updateDinnerRepository = updateDinnerRepository;
        }

        public async Task<Result<Dinner>> Handle(GuestArrivedAtCommand request, CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRepository.GetAsync(Guid.Parse(request.DinnerId),
                x => x.ReservationIds.Any(x => x.Id.Value == Guid.Parse(request.ReservationId)));
            dinner.ReservationIds.FirstOrDefault()!.GuestArrived(request.ArrivalDateTime);
            await _updateDinnerRepository.UpdateAsync(dinner);
            return dinner;
        }
    }
}
