
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.MenuAggregate.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId Create() => new MenuSectionId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
