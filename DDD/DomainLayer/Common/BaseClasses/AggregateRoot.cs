 
namespace DomainLayer.Common.BaseClasses
{
    public class AggregateRoot<TID> : Entity<TID> where TID :notnull
    {
        protected AggregateRoot() { }

        protected AggregateRoot(TID id) : base(id) { }
    }
}
