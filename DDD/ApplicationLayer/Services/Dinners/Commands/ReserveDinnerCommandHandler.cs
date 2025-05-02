using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.DinnerAggregate;
using DomainLayer.DinnerAggregate.Entities;
using DomainLayer.DinnerAggregate.Enums;
using DomainLayer.GuestAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class ReserveDinnerCommandHandler : IRequestHandler<ReserveDinnerCommand, Result<Reservation>>
    {
        private readonly ICreateRepository<Reservation> _reservationRepository;
        private readonly IGetRepository<Dinner> _dinnerRepository;
        private readonly IUpdateRepository<Dinner> _updateDinnerRepository;
        public ReserveDinnerCommandHandler(
            ICreateRepository<Reservation> reservationRepository, 
            IGetRepository<Dinner> dinnerRepository,
            IUpdateRepository<Dinner> updateDinnerRepository)
        {
            _reservationRepository = reservationRepository;
            _dinnerRepository = dinnerRepository;
            _updateDinnerRepository = updateDinnerRepository;
        }
        public async Task<Result<Reservation>> Handle(ReserveDinnerCommand request, CancellationToken cancellationToken)
        { 
            var dinner = await _dinnerRepository.GetAsync(Guid.Parse(request.DinnerId)); 
            var reservation = Reservation.Create(
                 request.GuestCount,
                 ReservationStatus.Reserved,
                 GuestId.Create(Guid.Parse(request.GuestId)),
                 BillId.Create(Guid.Parse(request.BillId))
            );
            await _reservationRepository.AddAsync(reservation);
            dinner.AddReservation(reservation);
            await _updateDinnerRepository.UpdateAsync(dinner);
            return reservation;
        }
    }
}
