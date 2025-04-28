
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.MenuAggregate.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; }
        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId Create() => new MenuId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
