using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.ValueObjects
{
    /// <summary>
    /// Class for entity's price properties
    /// </summary>
    /// <param name="value"></param>
    public sealed class Price(decimal value) : ValueObject<decimal>(value)
    {
        /// <summary>
        /// Price value object's validation method
        /// </summary>
        /// <exception cref="PriceLessOrEqualZero"></exception>
        /// <exception cref="PriceHasMoreThanTwoDecimalPlaces"></exception>
        protected override void Validate(decimal value)
        {
            if (value <= 0)
                throw new PriceLessOrEqualZero(value);

            if (value % 0.01m != 0)
                throw new PriceHasMoreThanTwoDecimalPlaces(value);
        }
    }
}