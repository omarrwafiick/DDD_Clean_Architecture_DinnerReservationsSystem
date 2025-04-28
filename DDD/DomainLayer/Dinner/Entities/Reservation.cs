using DomainLayer.Bill.ValueObjects;
using DomainLayer.Common.BaseClasses; 
using DomainLayer.Dinner.Enums;
using DomainLayer.Dinner.ValueObjects;
using DomainLayer.Guest.ValueObjects; 

namespace DomainLayer.Dinner.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public Reservation(
            ReservationId id, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId,
            DateTime arrivalDateTime, DateTime createdAt, DateTime updatedAt
        ) : base(id)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ArrivalDateTime = arrivalDateTime;
        }
        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime ArrivalDateTime { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public static Reservation Create(int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId)
        {
            return new Reservation(ReservationId.Create(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
