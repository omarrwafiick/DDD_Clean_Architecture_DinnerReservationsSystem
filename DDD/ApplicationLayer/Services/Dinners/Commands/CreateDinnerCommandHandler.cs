using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate;
using DomainLayer.DinnerAggregate.Entities;
using DomainLayer.DinnerAggregate.Enums; 
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects; 
using DomainLayer.MenuAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, Result<Dinner>>
    {
        private readonly ICreateRepository<Dinner> _dinnerRepository;
        public CreateDinnerCommandHandler(ICreateRepository<Dinner> dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }
        public async Task<Result<Dinner>> Handle(CreateDinnerCommand request, CancellationToken cancellationToken)
        {
            var dinner = Dinner.Create(
                request.Name,
                request.Description,
                DinnerStatus.Upcoming, 
                Price.Create(
                    request.Amount,
                    request.Currency),
                request.IsPublic,
                request.MaxGuests,
                HostId.Create(Guid.Parse(request.HostId)),
                MenuId.Create(Guid.Parse(request.MenuId)),
                request.ImageUrl,
                Location.Create(
                    request.AddressName,
                    request.Address,
                    request.Latitude,
                    request.Longitude),
                request.Reservations.Select(
                        rs => Reservation.Create(
                            rs.GuestCount, 
                            ReservationStatus.Reserved, 
                            GuestId.Create(Guid.Parse(rs.GuestId)), 
                            BillId.Create(Guid.Parse(rs.BillId))
                        )
                    ).ToList()
                );
            await _dinnerRepository.AddAsync(dinner);
            return dinner;
        }
    }
}
