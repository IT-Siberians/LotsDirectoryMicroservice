using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents type of the entity's user name
    /// </summary>
    /// <param name="value"> User name's string value </param>
    public sealed class UserName(string value) : StringObject(value, Validate)
    {
        /// <summary>
        /// User name's min value lenght
        /// </summary>
        public override int? MIN_LENGHT => 3;

        /// <summary>
        /// User name's max value lenght
        /// </summary>
        public override int? MAX_LENGHT => 30;

        /// <summary>
        /// User name's additional validation method
        /// </summary>
        /// <param name="value"> Value for validation </param>
        private static void Validate(string value)
        {

        }
    }
}