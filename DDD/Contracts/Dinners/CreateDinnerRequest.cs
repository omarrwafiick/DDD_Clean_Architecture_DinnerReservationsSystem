 
namespace Contracts.Dinners
{
    public record CreateDinnerRequest(
            string Name,
            string Description,  
            decimal Amount,
            string Currency,
            bool IsPublic,
            int MaxGuests,
            string ImageUrl, 
            string MenuId,
            string AddressName,
            string Address,
            double Latitude,
            double Longitude,
            List<ReservationRequest> Reservations);
    public record ReservationRequest(
        int GuestCount, 
        string GuestId,
        string BillId
    );
}
