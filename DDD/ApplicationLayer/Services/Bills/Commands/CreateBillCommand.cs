using DomainLayer.BillAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Bills.Commands
{
    public record CreateBillCommand
    (
        decimal Amount,
        string Currency,
        string GuestId,
        string HostId,
        string DinnerId
    ) : IRequest<Result<Bill>>;
}
