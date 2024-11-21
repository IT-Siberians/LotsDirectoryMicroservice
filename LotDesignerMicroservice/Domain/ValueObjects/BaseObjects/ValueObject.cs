﻿using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;
using System.Numerics;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents object that always has not null value
    /// </summary>
    /// <typeparam name="T"> Stored value type </typeparam>
    public abstract class ValueObject<T> :
        IEquatable<ValueObject<T>>,
        IEqualityOperators<ValueObject<T>, ValueObject<T>, bool>
    {
        /// <summary>
        /// General constructor for all value objects
        /// </summary>
        /// <param name="value"></param>
        public ValueObject(T value, Action<T> validate)
        {
            if (value == null)
                throw new ValueObjectNullException(GetType());

            validate.Invoke(value);
            Value = value;
        }

        /// <summary>
        /// Value object`s stored value
        /// </summary>
        public T Value { get; protected set; }

        public override int GetHashCode() => Value!.GetHashCode();

        public bool Equals(ValueObject<T>? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return other.Value!.Equals(Value);
        }

        public override bool Equals(object? other)
            => Equals(other as ValueObject<T>);

        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
            => Equals(left, right);

        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
            => !Equals(left, right);
    }
}