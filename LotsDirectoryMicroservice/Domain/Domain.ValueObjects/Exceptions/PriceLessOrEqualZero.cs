using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for Price values that less or equal to zero
    /// </summary>
    /// <param name="value"> Price received value </param>
    internal class PriceLessOrEqualZero(decimal value)
        : ArgumentNullException("Value", string.Format(PriceResources.PRICE_LESS_OR_EQUAL_ZERO, value));
}