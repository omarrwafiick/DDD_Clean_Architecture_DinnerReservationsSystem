 using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.HostAggregate.ValueObjects
{
    public class HostId : ValueObject
    {
        private HostId() { }
        public Guid Value { get; private set;}
        private HostId(Guid value)
        {
            Value = value;
        }  
        public static HostId Create(Guid value) => new HostId(value);
        public static HostId Create() => new HostId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
