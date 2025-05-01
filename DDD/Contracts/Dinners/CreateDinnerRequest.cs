 
namespace Contracts.Dinners
{
    public record CreateDinnerRequest(
            string Name,
            string Description,
            string DinnerStatus,
            decimal Amount,
            string Currency,
            bool IsPublic,
            int MaxGuests,
            string ImageUrl,
            string HostId,
            string MenuId,
            List<ReservationRequest> Reservations);
    public record ReservationRequest(
        int GuestCount,
        string ReservationStatus,
        string GuestId,
        string BillId
        );
}
