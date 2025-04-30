 
using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate.ValueObjects; 
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.UserAggregate.ValueObjects;

namespace DomainLayer.HostAggregate
{ 
    public sealed class Host : AggregateRoot<HostId>
    { 
        private Host() { }
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        public string ProfileImage { get; private set;}
        public decimal AverageRating { get; private set;}
        public UserId UserId { get; private set;}
 
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
         
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
         
        public DateTime CreatedDateTime { get; private set;}
        public DateTime UpdatedDateTime { get; private set;}
         
        private Host(HostId hostId, string firstName, string lastName, string profileImage, decimal averageRating,
                      UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
            : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
         
        public static Host Create(string firstName, string lastName, string profileImage, decimal averageRating,
                                   UserId userId)
        { 
            var currentTime = DateTime.UtcNow; 
            return new Host(HostId.Create(), firstName, lastName, profileImage, averageRating, userId, currentTime, currentTime);
        } 
    }
}
