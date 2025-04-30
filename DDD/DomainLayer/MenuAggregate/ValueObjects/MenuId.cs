
using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.MenuAggregate.ValueObjects
{
    public class MenuId : ValueObject
    {
        private MenuId() { }
        public Guid Value { get; private set;}
        private MenuId(Guid value)
        {
            Value = value;
        }
        public static MenuId Create(Guid value) => new MenuId(value);
        public static MenuId Create() => new MenuId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
