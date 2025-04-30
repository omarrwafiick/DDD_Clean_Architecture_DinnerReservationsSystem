
using DomainLayer.Common.BaseClasses;
using DomainLayer.MenuReviewAggregate.ValueObjects;

namespace DomainLayer.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        private UserId() { }
        public Guid Value { get; private set;}
        private UserId(Guid value)
        {
            Value = value;
        }
        public static UserId Create(Guid value) => new UserId(value);
        public static UserId Create() => new UserId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
