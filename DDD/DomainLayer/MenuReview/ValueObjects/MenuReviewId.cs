
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; }
        public MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId Create() => new MenuReviewId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
