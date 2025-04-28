

using DomainLayer.Common.BaseClasses;

namespace DomainLayer.Common.ValueObjects
{
    public class Location : ValueObject
    {
        private Location(string name, string address, double latitude , double longitude )
        { 
            Name = name;
            Address = address;
            Longitude = longitude;
            Latitude = latitude;
        }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public static Location Create(string name, string address, double latitude = 0, double longitude = 0) => new Location(name, address, longitude, latitude);
        
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
