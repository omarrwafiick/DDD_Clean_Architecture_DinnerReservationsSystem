using DomainLayer.Common.BaseClasses;
using DomainLayer.MenuAggregate.ValueObjects;

namespace DomainLayer.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; }
        public string Description { get; }
        private readonly List<MenuItem> _menuItems = new();
        private IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();
        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id) 
        {
            Name = name;
            Description = description;
            _menuItems = items;
        }
        public static MenuSection Create(string name, string description, List<MenuItem> items) => new MenuSection(MenuSectionId.Create(), name, description, items);
    }
}
