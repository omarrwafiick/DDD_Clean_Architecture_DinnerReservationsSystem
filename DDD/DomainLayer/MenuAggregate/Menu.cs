using DomainLayer.Common.BaseClasses;
using DomainLayer.Common.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.Entities;
using DomainLayer.MenuAggregate.Events;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.MenuReviewAggregate.ValueObjects;
 
namespace DomainLayer.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId> 
    {
        private Menu() { }
        private readonly List<MenuSection> _menuSectionIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new ();

        public string Name { get; private set;}
        public string Description { get; private set;}
        public AverageRating AverageRating { get; private set;}
        public HostId HostId { get; private set;}

        public IReadOnlyList<MenuSection> MenuSectionIds  => _menuSectionIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}

        private Menu(MenuId menuId, string name, string description, HostId hostId, List<MenuSection> sections, DateTime createdAt, DateTime updatedAt) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _menuSectionIds = sections;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AverageRating = AverageRating.Create();
        }  
        public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections) {
           var menu = new Menu(MenuId.Create(Guid.NewGuid()), name, description, hostId, sections, DateTime.UtcNow, DateTime.UtcNow);
           menu.AddDomainEvent(new MenuCreated(menu));
           return menu;
        }
    }
}
