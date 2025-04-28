using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;  

namespace DomainLayer.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }  
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
         
        private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdAt, DateTime updatedAt) :base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            Price = price;
            HostId = hostId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Bill Create(string name, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
        {
            return new Bill(BillId.Create(), dinnerId, guestId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
        } 
    }
}
