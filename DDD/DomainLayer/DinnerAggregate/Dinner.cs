using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.Entities;
using DomainLayer.DinnerAggregate.Enums;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects;

namespace DomainLayer.DinnerAggregate
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private Dinner() { }
         
        public string Name { get; private set;}
        public string Description { get; private set;}
        public DinnerStatus DinnerStatus { get; private set;}
        public Price Price { get; private set;}
        public bool IsPublic { get; private set;}
        public int MaxGuests { get; private set;}
        public HostId HostId { get; private set;}
        public MenuId MenuId { get; private set;}
        public string ImageUrl { get; private set;}
        public Location Location { get; private set;}
        private readonly List<Reservation> _reservations = new();
        public DateTime StartedAt { get; private set;}
        public DateTime EndedAt { get; private set;}
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DinnerStatus dinnerStatus,
        Price price,
        bool isPublic,
        int maxGuests,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime startedAt,
        DateTime endedAt,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(dinnerId)
        {
            Name = name;
            Description = description;
            DinnerStatus = dinnerStatus;
            Price = price;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            StartedAt = startedAt;
            EndedAt = endedAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Dinner Create(
            string name,
            string description,
            DinnerStatus dinnerStatus,
            Price price,
            bool isPublic,
            int maxGuests,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location
        )
        {
            return new Dinner(
                dinnerId: DinnerId.Create(),
                name: name,
                description: description,
                dinnerStatus: dinnerStatus,
                price: price,
                isPublic: isPublic,
                maxGuests: maxGuests,
                hostId: hostId,
                menuId: menuId,
                imageUrl: imageUrl,
                location: location,
                startedAt: DateTime.UtcNow,
                endedAt: DateTime.UtcNow,
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.UtcNow
            );
        }
    }
}
