
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        public MenuSectionId(Guid value)
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
