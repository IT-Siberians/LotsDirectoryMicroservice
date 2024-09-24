using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;
using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.ValueObjects
{
    /// <summary>
    /// Class for entity's title property
    /// </summary>
    /// <param name="value"> Title string value </param>
    public sealed class Title(string value) : ValueObject<string>(value)
    {
        /// <summary>
        /// Title value object's validation method
        /// </summary>
        /// <exception cref="TitleNullOrWhiteSpacesException"></exception>
        /// <exception cref="TitleMaxLenghtException"></exception>
        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new TitleNullOrWhiteSpacesException();

            else if (value.Length > TitleResources.TITLE_MAX_LENGTH)
                throw new TitleMaxLenghtException(value.Length);
        }
    }
}