using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null, empty or only white spaces UserName values
    /// </summary>
    internal class UserNameNullOrWhiteSpacesException()
        : ArgumentNullException("Value", UserNameResources.USER_NAME_NULL_OR_WHITE_SPACES_EXCEPTION);
}