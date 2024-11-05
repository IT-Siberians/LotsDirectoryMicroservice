using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents text object that always has not null, not empty and not only white spaces unlimited lenght string value
    /// </summary>
    /// <param name="value"> Description string value </param>
    public sealed class Text(string value) : StringObject(value)
    {
        /// <summary>
        /// Text's min value lenght
        /// </summary>
        public override int MIN_LENGHT => 10;

        /// <summary>
        /// Text's max value lenght
        /// </summary>
        public override int MAX_LENGHT => 20000;
    }
}