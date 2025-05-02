using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.MenuReviewAggregate.ValueObjects;
using DomainLayer.UserAggregate.ValueObjects;

namespace DomainLayer.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private Guest() { }
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        public string ProfileImage { get; private set;}
        public AverageRating AverageRating { get; private set;}
        public UserId UserId { get; private set;}
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<RatingId> _ratingIds = new();
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<RatingId> RatingIds => _ratingIds.AsReadOnly();

        public void AddBill(BillId billId)
        {
            _billIds.Add(billId);
        }
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
