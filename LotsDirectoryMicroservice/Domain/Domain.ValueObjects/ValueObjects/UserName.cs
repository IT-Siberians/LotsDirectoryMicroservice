using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;
using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.ValueObjects
{
    /// <summary>
    /// Class for username property
    /// </summary>
    /// <param name="value"> UserName string value </param>
    public sealed class UserName(string value) : ValueObject<string>(value)
    {
        /// <summary>
        /// UserName value object's validation method
        /// </summary>
        /// <exception cref="UserNameNullOrWhiteSpacesException"></exception>
        /// <exception cref="UserNameMaxLenghtException"></exception>
        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new UserNameNullOrWhiteSpacesException();

            else if (value.Length > UserNameResources.USER_NAME_MAX_LENGTH)
                throw new UserNameMaxLenghtException(value.Length);
        }
    }
}