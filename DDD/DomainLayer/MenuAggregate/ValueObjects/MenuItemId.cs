
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.MenuAggregate.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        private MenuItemId() { }
        public Guid Value { get; private set;}
        private MenuItemId(Guid value)
        {
            Value = value;
        }  
        public static MenuItemId Create(Guid value) => new MenuItemId(value); 
        public static MenuItemId Create() => new MenuItemId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
