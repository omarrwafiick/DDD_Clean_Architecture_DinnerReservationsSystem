
using DomainLayer.Common.BaseClasses;
using DomainLayer.MenuAggregate.ValueObjects;

namespace DomainLayer.MenuReviewAggregate.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set;}
        private MenuReviewId(Guid value)
        {
            Value = value;
        }
        public static MenuReviewId Create(Guid value) => new MenuReviewId(value);
        public static MenuReviewId Create() => new MenuReviewId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
