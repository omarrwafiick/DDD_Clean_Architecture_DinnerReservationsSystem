
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.User.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; }
        public UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create() => new UserId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
