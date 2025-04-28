 
using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.UserAggregate.ValueObjects;

namespace DomainLayer.HostAggregate
{
    public sealed class Host : AggregateRoot<HostId>
    { 
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public decimal AverageRating { get; }
        public UserId UserId { get; }
 
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
         
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
         
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
         
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
         
        //public void AddMenuId(MenuId menuId)
        //{
        //    _menuIds.Add(menuId);
        //}

        //public void AddDinnerId(DinnerId dinnerId)
        //{
        //    _dinnerIds.Add(dinnerId);
        //}
    }
}
