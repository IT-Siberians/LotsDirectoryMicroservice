using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for Title values that longer then TITLE_MAX_LENGTH
    /// </summary>
    /// <param name="value"> Title received value </param>
    internal class TitleMaxLenghtException(int valueLength)
        : ArgumentOutOfRangeException("Value", string.Format(TitleResources.TITLE_MAX_LENGHT_EXCEPTION, valueLength, TitleResources.TITLE_MAX_LENGTH));
}