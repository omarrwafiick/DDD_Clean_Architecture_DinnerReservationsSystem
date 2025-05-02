 
namespace Contracts.Dinners
{
    public record DinnerResponse(
        Guid Id,
        string HostId,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
