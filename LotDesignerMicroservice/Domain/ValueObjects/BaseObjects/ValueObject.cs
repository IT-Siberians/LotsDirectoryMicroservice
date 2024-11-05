using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents object that always has not null value
    /// </summary>
    /// <typeparam name="T"> Stored value type </typeparam>
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        /// <summary>
        /// General constructor for all value objects
        /// </summary>
        /// <param name="value"></param>
        public ValueObject(T value, Action<T>? validate = null)
        {
            if (value == null)
                throw new ValueObjectNullException(GetType());

            if (validate != null)
                validate(value);

            Value = value;
        }

        /// <summary>
        /// Value object`s stored value
        /// </summary>
        public T Value { get; protected set; }

        public override int GetHashCode() => Value!.GetHashCode();

        public override bool Equals(object? other) => Equals(other as ValueObject<T>);

        public bool Equals(ValueObject<T>? other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            return Equals(Value, other.Value);
        }

        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
            => Equals(left, right);

        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
            => !Equals(left, right);
    }
}
