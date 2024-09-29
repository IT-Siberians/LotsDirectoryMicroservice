using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;
using System.Numerics;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents numeric object that always has not null value
    /// </summary>
    /// <typeparam name="T"> Object's numeric type </typeparam>
    public abstract class NumericObject<T> : ValueObject<T>,
        IComparisonOperators<NumericObject<T>, NumericObject<T>, bool>
        where T : struct, INumber<T>
    {
        /// <summary>
        /// Object's min value
        /// </summary>
        public abstract T? MIN_VALUE { get; }

        /// <summary>
        /// Object's max value
        /// </summary>
        public abstract T? MAX_VALUE { get; }

        /// <summary>
        /// Represents numeric object that always has not null value
        /// </summary>
        /// <param name="value"> Stored object's numeric value </param>
        /// <param name="validate"> Additional validation method </param>
        /// <exception cref="NumericObjectMinValueException{T}"></exception>
        /// <exception cref="NumericObjectMaxValueException{T}"></exception>
        public NumericObject(T value, Action<T> validate) : base(value, validate)
        {
            if (MIN_VALUE != null && value < MIN_VALUE)
                throw new NumericObjectMinValueException<T>(GetType(), value, MIN_VALUE.Value);

            if (MAX_VALUE != null && value > MAX_VALUE)
                throw new NumericObjectMaxValueException<T>(GetType(), value, MAX_VALUE.Value);
        }

        public override int GetHashCode() => Value!.GetHashCode();

        public override bool Equals(object? other) => Equals(other as ValueObject<T>);

        public static bool operator ==(NumericObject<T>? left, NumericObject<T>? right)
            => Equals(left, right);

        public static bool operator !=(NumericObject<T>? left, NumericObject<T>? right)
            => !Equals(left, right);

        public static bool operator <(NumericObject<T> left, NumericObject<T> right)
            => left.Value < right.Value;

        public static bool operator >(NumericObject<T> left, NumericObject<T> right)
            => left.Value > right.Value;

        public static bool operator <=(NumericObject<T> left, NumericObject<T> right)
            => left.Value <= right.Value;

        public static bool operator >=(NumericObject<T> left, NumericObject<T> right)
            => left.Value >= right.Value;
    }
}