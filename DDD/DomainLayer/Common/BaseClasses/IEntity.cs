 

namespace DomainLayer.Common.BaseClasses
{
    public interface IEntity<TID>
    {
        public TID Id { get; set; }
    }
}
