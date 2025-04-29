using DomainLayer.Common.BaseClasses;
using DomainLayer.MenuAggregate.ValueObjects;
 
namespace DomainLayer.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public MenuItem() { } 
        public string Name { get; private set;}
        public string Description { get; private set;} 
        private MenuItem (MenuItemId menuItemId, string name, string description) : base(menuItemId) { 
            Name = name;
            Description = description;
        }
        public static MenuItem Create(string name, string description) => new MenuItem(MenuItemId.Create(), name, description);
    }
}
