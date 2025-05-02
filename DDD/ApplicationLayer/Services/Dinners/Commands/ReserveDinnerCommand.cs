  
using DomainLayer.DinnerAggregate.Entities;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record ReserveDinnerCommand
    (
        int GuestCount,
        string GuestId,
        string BillId ,
        string DinnerId
    ) : IRequest<Result<Reservation>>; 
}
