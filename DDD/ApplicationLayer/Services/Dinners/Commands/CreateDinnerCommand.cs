 
using DomainLayer.DinnerAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record CreateDinnerCommand
    (
        string Name,
        string Description, 
        decimal Amount,
        string Currency,
        bool IsPublic,
        int MaxGuests,
        string ImageUrl, 
        string MenuId,
        string HostId,
        string AddressName,
        string Address,
        double Latitude,
        double Longitude,
        List<ReservationCommand> Reservations
    ) : IRequest<Result<Dinner>>;
    public record ReservationCommand(
        int GuestCount, 
        string GuestId,
        string BillId
    ); 
}
