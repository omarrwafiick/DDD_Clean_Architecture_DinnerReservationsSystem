 
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.DinnerAggregate.ValueObjects
{
    public class ReservationId : ValueObject
    {
        public Guid Value { get; private set;}
        private ReservationId(Guid value)
        {
            Value = value;
        }
        public static ReservationId Create(Guid value) => new ReservationId(value);
        public static ReservationId Create() => new ReservationId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
} 
