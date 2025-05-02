 
namespace Contracts.Dinners
{
    public record GuestArrivedAtRequest(
        string DinnerId,
        string ReservationId,
        DateTime ArrivalDateTime
    );
}
