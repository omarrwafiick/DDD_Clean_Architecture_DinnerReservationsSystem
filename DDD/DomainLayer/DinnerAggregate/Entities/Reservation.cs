using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.Common.BaseClasses; 
using DomainLayer.DinnerAggregate.Enums;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects; 

namespace DomainLayer.DinnerAggregate.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        private Reservation(
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

        private Reservation() {  }
        public int GuestCount { get; private set;}
        public ReservationStatus ReservationStatus { get; private set;}
        public GuestId GuestId { get; private set;}
        public BillId BillId { get; private set;}
        public DateTime ArrivalDateTime { get; private set;}
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}
        public static Reservation Create(int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId)
        {
            return new Reservation(ReservationId.Create(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
