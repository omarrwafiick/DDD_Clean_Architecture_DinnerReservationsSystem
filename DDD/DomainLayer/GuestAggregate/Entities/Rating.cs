using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;

namespace DomainLayer.GuestAggregate.Entities
{
    public class Rating : Entity<RatingId>
    {
        private Rating() { } 
    
        public HostId HostId { get; private set;}
        public DinnerId DinnerId { get; private set;}
        public int RatingValue { get; private set;}  
        public DateTime CreatedDateTime { get; private set;}
        public DateTime UpdatedDateTime { get; private set;}
         
        private Rating(
            RatingId ratingId,
            HostId hostId,
            DinnerId dinnerId,
            int ratingValue,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            RatingValue = ratingValue;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

       
        public static Rating Create(
            HostId hostId,
            DinnerId dinnerId,
            int ratingValue
        )
        {  
            return new Rating(
                ratingId: RatingId.Create(),  
                hostId: hostId,
                dinnerId: dinnerId,
                ratingValue: ratingValue,
                createdDateTime: DateTime.UtcNow,  
                updatedDateTime: DateTime.UtcNow
            );
        }
    }

}
