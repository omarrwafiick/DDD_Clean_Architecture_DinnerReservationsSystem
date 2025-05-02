
using DomainLayer.DinnerAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record GuestArrivedAtCommand 
    (
        string DinnerId, 
        string ReservationId,
        DateTime ArrivalDateTime
    ) : IRequest<Result<Dinner>>; 
}
