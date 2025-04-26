

namespace DomainLayer.Common.BaseClasses
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if(obj is null || obj.GetType() != GetType()) return false;
            var valObj = obj as ValueObject;
            return GetEqualityComponents().SequenceEqual(valObj.GetEqualityComponents());
        }
        public static bool operator ==(ValueObject left, ValueObject right) => left.Equals(right);
       
        public static bool operator !=(ValueObject left, ValueObject right) => !left.Equals(right);
        
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode()??0)
                .Aggregate((x,y) => x ^ y);
        }

        public bool Equals(ValueObject? other) => Equals((object?)other);
        
    }
    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}

