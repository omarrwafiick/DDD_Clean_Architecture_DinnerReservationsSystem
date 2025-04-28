using DomainLayer.Common.BaseClasses;

namespace DomainLayer.DinnerAggregate.ValueObjects
{
    public class DinnerId : ValueObject
    {
        public Guid Value { get; }
        public DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId Create() => new DinnerId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
