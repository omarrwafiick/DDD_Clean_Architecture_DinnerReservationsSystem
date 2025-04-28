using DomainLayer.Bill.ValueObjects;
using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.Dinner.ValueObjects;
using DomainLayer.Guest.ValueObjects;
using DomainLayer.MenuReview.ValueObjects;
using DomainLayer.User.ValueObjects;

namespace DomainLayer.Guest
{
    public class Guest : AggregateRoot<GuestId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<RatingId> _ratingIds = new();
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<RatingId> RatingIds => _ratingIds.AsReadOnly();

        private Guest(
           GuestId guestId,
           string firstName,
           string lastName,
           string profileImage,
           AverageRating averageRating,
           UserId userId,
           DateTime createdAt,
           DateTime updatedAt
        ) : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

         public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId
        )
        {
            return new Guest(
                guestId: GuestId.Create(),  
                firstName: firstName,
                lastName: lastName,
                profileImage: profileImage,  
                averageRating: averageRating,  
                userId: userId,
                createdAt: DateTime.UtcNow,  
                updatedAt: DateTime.UtcNow   
            );
        }
    }
}
