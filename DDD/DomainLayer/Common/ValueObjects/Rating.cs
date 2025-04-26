
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        private Rating(double value)
        {
            Value = value; 
        }
        public double Value { get; private set; } 
        public static Rating Create(double value = 0) => new Rating(value);
        
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value; 
        }
    }
}
