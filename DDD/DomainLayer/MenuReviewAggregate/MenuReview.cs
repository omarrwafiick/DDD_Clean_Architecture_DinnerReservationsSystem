using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.MenuReviewAggregate.ValueObjects;

namespace DomainLayer.MenuReviewAggregate
{ 
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        private MenuReview() { }
        public int Rating { get; private set;}
        public string Comment { get; private set;}
        public HostId HostId { get; private set;}
        public MenuId MenuId { get; private set;}
        public GuestId GuestId { get; private set;}
        public DinnerId DinnerId { get; private set;} 
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}
 
        private MenuReview(MenuReviewId menuReviewId, int rating, string comment, HostId hostId,
                           MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdAt,
                           DateTime updatedAt)
            : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
         
        public static MenuReview Create(int rating, string comment, HostId hostId, MenuId menuId,
                                        GuestId guestId, DinnerId dinnerId)
        { 
            var currentTime = DateTime.UtcNow;

            return new MenuReview(MenuReviewId.Create(Guid.NewGuid()), rating, comment, hostId, menuId, guestId, dinnerId, currentTime, currentTime);
        }
    }
}
