using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.Common.BaseClasses;
using DomainLayer.MenuAggregate.ValueObjects;

namespace DomainLayer.DinnerAggregate.ValueObjects
{
    public class DinnerId : ValueObject
    {
        private DinnerId() { }
        public Guid Value { get; private set;}
        private DinnerId(Guid value)
        {
            Value = value;
        } 
        public static DinnerId Create(Guid value) => new DinnerId(value);  
        public static DinnerId Create() => new DinnerId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
