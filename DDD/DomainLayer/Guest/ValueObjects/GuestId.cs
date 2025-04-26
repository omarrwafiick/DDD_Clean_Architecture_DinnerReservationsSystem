
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Guest.ValueObjects
{
    public class GuestId : ValueObject
    {
        public Guid Value { get; }
        public GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId Create() => new GuestId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
