 
using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.BillAggregate.ValueObjects
{
    public class BillId : ValueObject
    {
        public Guid Value { get; }
        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId Create() => new BillId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
