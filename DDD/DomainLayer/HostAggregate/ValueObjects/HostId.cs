
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.HostAggregate.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid Value { get; }
        public HostId(Guid value)
        {
            Value = value;
        }

        public static HostId Create() => new HostId(Guid.NewGuid());
        public static HostId Create(string hostId) => new HostId(Guid.Parse(hostId));
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
