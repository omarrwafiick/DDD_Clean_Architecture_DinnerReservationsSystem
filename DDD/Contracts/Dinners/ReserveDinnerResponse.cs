 
namespace Contracts.Dinners
{
    public record ReserveDinnerResponse
    (
        Guid Id,
        string guestId,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
