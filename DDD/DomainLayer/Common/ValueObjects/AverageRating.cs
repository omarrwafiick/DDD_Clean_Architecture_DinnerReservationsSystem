 
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        private AverageRating() { }
        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }
        public double Value { get; private set; }
        public int NumRatings { get; private set; }
        public static AverageRating Create(double value = 0, int numRatings = 0) => new AverageRating(value, numRatings);
        public void Add(Rating rating)
        {
            Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        }
        public void Remove(Rating rating)
        {
            Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return NumRatings;
        }
    }
}
