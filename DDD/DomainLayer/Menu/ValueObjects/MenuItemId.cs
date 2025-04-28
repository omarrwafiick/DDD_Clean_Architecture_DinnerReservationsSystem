
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Menu.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId Create() => new MenuItemId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
