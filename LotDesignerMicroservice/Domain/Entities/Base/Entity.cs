namespace LotDesignerMicroservice.Domain.Entities.Base
{
    /// <summary>
    /// Base entity interface
    /// </summary>
    /// <typeparam name="TKey"> Identifier's type </typeparam>
    public abstract class Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Entity's identifier
        /// </summary>
        public TKey Id { get; protected set; }

        public static Type GetKeyType() => typeof(TKey);
    }
}
