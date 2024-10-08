using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents type of the entity's title
    /// </summary>
    /// <param name="value"> Title's string value </param>
    public sealed class Title(string value) : StringObject(value)
    {
        /// <summary>
        /// Title's min value lenght
        /// </summary>
        public override int MIN_LENGHT => 3;

        /// <summary>
        /// Title's max value lenght
        /// </summary>
        public override int MAX_LENGHT => 50;
    }
}