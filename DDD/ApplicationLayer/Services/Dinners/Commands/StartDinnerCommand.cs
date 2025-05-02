
using DomainLayer.DinnerAggregate; 
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record StartDinnerCommand
    (
        string HostId,
        string DinnerId,
        DateTime StartAt
    ) : IRequest<Result<Dinner>>; 
}
