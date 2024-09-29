using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;

namespace LotDesignerMicroservice.Domain.ValueObjects.NumericObjects
{
    /// <summary>
    /// Represents type of the entity's price
    /// </summary>
    public sealed class Price : NumericObject<decimal>
    {
        /// <summary>
        /// Price's min value
        /// </summary>
        public override decimal? MIN_VALUE => 0.01m;

        /// <summary>
        /// Price's max value
        /// </summary>
        public override decimal? MAX_VALUE => null;

        /// <summary>
        /// Represents type of the entity's price
        /// </summary>
        /// <param name="value"> Price value </param>
        public Price(decimal value) : base(value, Validate)
        {
            if (value % 0.01m != 0)
                Value = Math.Round(value, 2);
        }

        /// <summary>
        /// Price's additional validation method
        /// </summary>
        private static void Validate(decimal value)
        {

        }
    }
}