using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for Price values that has more than two decimal places
    /// </summary>
    /// <param name="value"> Price received value </param>
    internal class PriceHasMoreThanTwoDecimalPlaces(decimal value)
        : ArgumentOutOfRangeException("Value", string.Format(PriceResources.PRICE_HAS_MORE_THEN_TWO_DECIMAL_PLACES, value));
}