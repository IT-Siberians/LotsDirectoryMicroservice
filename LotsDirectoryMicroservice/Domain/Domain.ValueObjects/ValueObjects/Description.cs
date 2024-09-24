using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.ValueObjects
{
    /// <summary>
    /// Class for entity's description property
    /// </summary>
    /// <param name="value"> Description string value </param>
    public sealed class Description(string value) : ValueObject<string>(value)
    {
        /// <summary>
        /// Description value object's validation method
        /// </summary>
        /// <exception cref="TitleNullOrWhiteSpacesException"></exception>
        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new TitleNullOrWhiteSpacesException();
        }
    }
}