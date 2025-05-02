 
namespace Contracts.Bills
{
    public record BillQueryResponse(
        Guid Id,
        Guid DinnerId ,
        Guid GuestId ,
        Guid HostId , 
        DateTime CreatedAt ,
        DateTime UpdatedAt 
    );
}
