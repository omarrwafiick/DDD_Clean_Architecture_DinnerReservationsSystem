using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Common.ValueObjects
{ 
    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
        public static Price Create(decimal Amount = 0, string Currency = null) => new Price(Amount, Currency);
        
    } 
}
