
using DomainLayer.DinnerAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record EndDinnerCommand
    (
        string HostId,
        string DinnerId,
        DateTime EndAt
    ) : IRequest<Result<Dinner>>; 
}
