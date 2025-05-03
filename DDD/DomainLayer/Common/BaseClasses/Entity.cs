 

namespace DomainLayer.Common.BaseClasses
{
    public abstract class Entity<TID> : IEquatable<Entity<TID>>,
        IHasDomainEvents where TID : notnull
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity() { }
        public TID Id { get; private set; }
        protected Entity(TID id) {
            Id = id;
        }
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly(); 

        public override bool Equals(object? obj) => obj is Entity<TID> entity && Id.Equals(entity.Id);

        public static bool operator ==(Entity<TID> left, Entity<TID> right) => left.Equals(right);

        public static bool operator !=(Entity<TID> left, Entity<TID> right) => !left.Equals(right);

        public bool Equals(Entity<TID>? other) => Equals((object?)other);

        public override int GetHashCode() => Id.GetHashCode();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
