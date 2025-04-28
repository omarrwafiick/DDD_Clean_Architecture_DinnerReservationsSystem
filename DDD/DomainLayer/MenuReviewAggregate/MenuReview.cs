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
        public int Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; } 
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
 
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

            return new MenuReview(MenuReviewId.Create(), rating, comment, hostId, menuId, guestId, dinnerId, currentTime, currentTime);
        }
    }
}
