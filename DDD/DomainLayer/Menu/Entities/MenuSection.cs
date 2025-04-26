using DomainLayer.Common.BaseClasses;
using DomainLayer.Menu.ValueObjects;

namespace DomainLayer.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; }
        public string Description { get; }
        private readonly List<MenuItem> _menuItems = new();
        private IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();
        private MenuSection(MenuSectionId id, string name, string description) : base(id) 
        {
            Name = name;
            Description = description;
        }
        public static MenuSection Create(string name, string description) => new MenuSection(MenuSectionId.Create(), name, description);
    }
}
