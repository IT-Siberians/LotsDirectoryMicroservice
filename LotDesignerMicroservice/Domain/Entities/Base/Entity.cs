using System.Numerics;

namespace LotDesignerMicroservice.Domain.Entities.Base
{
    /// <summary>
    /// Base entity interface
    /// </summary>
    /// <typeparam name="TKey"> Identifier's type </typeparam>
    public abstract class Entity<TKey> :
        IEquatable<Entity<TKey>>,
        IEqualityOperators<Entity<TKey>, Entity<TKey>, bool>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Entity's identifier
        /// </summary>
        public TKey Id { get; protected set; }

        public bool Equals(Entity<TKey>? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return other.Id!.Equals(Id);
        }

        public override bool Equals(object? other)
            => Equals(other as Entity<TKey>);

        public override int GetHashCode()
            => Id!.GetHashCode();

        public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
            => Equals(left?.Id, right?.Id);

        public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
            => !Equals(left?.Id, right?.Id);
    }
}