using DomainLayer.Common.BaseClasses;
using DomainLayer.Dinner.ValueObjects;
using DomainLayer.Guest.ValueObjects;
using DomainLayer.Host.ValueObjects;

namespace DomainLayer.Guest.Entities
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
