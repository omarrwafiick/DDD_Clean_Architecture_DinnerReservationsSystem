
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Host.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid Value { get; }
        public HostId(Guid value)
        {
            Value = value;
        }

        public static HostId Create() => new HostId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
