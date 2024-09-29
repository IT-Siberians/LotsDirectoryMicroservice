using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null, empty or only white spaces Title values
    /// </summary>
    internal class TitleNullOrWhiteSpacesException()
        : ArgumentNullException("Value", TitleResources.TITLE_NULL_OR_WHITE_SPACES_EXCEPTION);
}