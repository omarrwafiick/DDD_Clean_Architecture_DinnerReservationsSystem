using DomainLayer.Common.BaseClasses;
using DomainLayer.Menu.ValueObjects;
 
namespace DomainLayer.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; } 
        private MenuItem (MenuItemId menuItemId, string name, string description) : base(menuItemId) { 
            Name = name;
            Description = description;
        }
        public static MenuItem Create(string name, string description) => new MenuItem(MenuItemId.Create(), name, description);
    }
}
