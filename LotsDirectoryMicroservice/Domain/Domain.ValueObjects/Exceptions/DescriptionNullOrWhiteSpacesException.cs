using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null, empty or only white spaces Description values
    /// </summary>
    internal class DescriptionNullOrWhiteSpacesException()
        : ArgumentNullException("Value", DescriptionResources.DESCRIPTION_NULL_OR_WHITE_SPACES_EXCEPTION);
}