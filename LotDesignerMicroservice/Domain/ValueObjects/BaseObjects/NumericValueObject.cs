using System.Numerics;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents numeric object that always has not null value
    /// </summary>
    /// <typeparam name="T"> Object's numeric type </typeparam>
    public abstract class NumericValueObject<T>(T value, Action<T> validate) :
        ValueObject<T>(value, validate),
        IComparisonOperators<NumericValueObject<T>, NumericValueObject<T>, bool>,
        IEqualityOperators<NumericValueObject<T>, NumericValueObject<T>, bool>,
        IEquatable<NumericValueObject<T>>
        where T : struct, INumber<T>
    {
        public override int GetHashCode() => Value!.GetHashCode();

        public bool Equals(NumericValueObject<T>? other)
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
            => Equals(other as NumericValueObject<T>);

        public static bool operator ==(NumericValueObject<T>? left, NumericValueObject<T>? right)
            => Equals(left, right);

        public static bool operator !=(NumericValueObject<T>? left, NumericValueObject<T>? right)
            => !Equals(left, right);

        public static bool operator <(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value < right.Value;

        public static bool operator >(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value > right.Value;

        public static bool operator <=(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value <= right.Value;

        public static bool operator >=(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value >= right.Value;
    }
}