using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.Entities;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.MenuReviewAggregate.ValueObjects;
 
namespace DomainLayer.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    //menuId → passed to AggregateRoot → passed to Entity → stored in Id property.
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinners = new();
        private readonly List<MenuReviewId> _reviews = new ();

        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public HostId HostId { get; }

        public IReadOnlyList<MenuSection> MenuSections  => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviews.AsReadOnly();

        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        private Menu(MenuId menuId, string name, string description, HostId hostId, List<MenuSection> sections, DateTime createdAt, DateTime updatedAt) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _sections = sections;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AverageRating = AverageRating.Create();
        }

        public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections) {
            return new Menu(MenuId.Create(), name, description, hostId, sections, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
