using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;

namespace DomainLayer.GuestAggregate.Entities
{
    public class Rating : Entity<RatingId>
    {   
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int RatingValue { get; }  
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
         
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
