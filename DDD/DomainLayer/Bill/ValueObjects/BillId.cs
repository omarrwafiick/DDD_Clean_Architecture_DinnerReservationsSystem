
using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.BillAggregate.ValueObjects
{
    public class BillId : ValueObject
    {
        private BillId() { }
        public Guid Value { get; private set;}
        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId Create() => new BillId(Guid.NewGuid());
        public static BillId Create(Guid value) => new BillId(value);
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
