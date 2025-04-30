
using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.GuestAggregate.ValueObjects
{
    public class GuestId : ValueObject
    {
        private GuestId() { }
        public Guid Value { get; private set;}
        private GuestId(Guid value)
        {
            Value = value;
        }
        public static GuestId Create(Guid value) => new GuestId(value);
        public static GuestId Create() => new GuestId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
