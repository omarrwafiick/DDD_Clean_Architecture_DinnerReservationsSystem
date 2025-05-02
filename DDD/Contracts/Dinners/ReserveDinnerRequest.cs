 

namespace Contracts.Dinners
{
    public record ReserveDinnerRequest
    (
        int GuestCount, 
        string BillId
    );
}
