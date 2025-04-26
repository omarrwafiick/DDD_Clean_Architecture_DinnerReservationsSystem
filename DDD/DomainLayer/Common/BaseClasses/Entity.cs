 

namespace DomainLayer.Common.BaseClasses
{
    public abstract class Entity<TID> : IEquatable<Entity<TID>> where TID : notnull
    {
        public TID Id { get; protected set; }
        protected Entity(TID id) {
            Id = id;
        }
        public override bool Equals(object? obj) => obj is Entity<TID> entity && Id.Equals(entity.Id);

        public static bool operator ==(Entity<TID> left, Entity<TID> right) => left.Equals(right);

        public static bool operator !=(Entity<TID> left, Entity<TID> right) => !left.Equals(right);

        public bool Equals(Entity<TID>? other) => Equals((object?)other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
