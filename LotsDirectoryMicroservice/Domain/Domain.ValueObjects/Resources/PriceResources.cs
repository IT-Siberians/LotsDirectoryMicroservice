namespace Domain.ValueObjects.Resources
{
    /// <summary>
    /// Constants and message strings for Price value objects
    /// </summary>
    internal static class PriceResources
    {
        /// <summary>
        /// Text message for exception for Price values that less or equal to zero
        /// </summary>
        public const string PRICE_LESS_OR_EQUAL_ZERO = "Received Price value({0}) is less or equal zero.";

        /// <summary>
        /// Text message for exception for Price values that has more than two decimal places
        /// </summary>
        public const string PRICE_HAS_MORE_THEN_TWO_DECIMAL_PLACES = "Received Price value({0}) has more than two decimal places.";
    }
}