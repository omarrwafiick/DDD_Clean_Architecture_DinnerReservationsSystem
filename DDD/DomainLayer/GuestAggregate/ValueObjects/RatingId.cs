using DomainLayer.Common.BaseClasses; 

namespace DomainLayer.GuestAggregate.ValueObjects
{
    public class RatingId : ValueObject
    {
        public Guid Value { get; }
        public RatingId(Guid value)
        {
            Value = value;
        }

        public static RatingId Create() => new RatingId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
