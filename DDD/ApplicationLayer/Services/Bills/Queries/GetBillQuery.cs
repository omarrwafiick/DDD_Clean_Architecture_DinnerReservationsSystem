

using DomainLayer.BillAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Bills.Queries
{
    public record GetBillQuery(string guestid, string billid) : IRequest<Result<Bill>>;
}
