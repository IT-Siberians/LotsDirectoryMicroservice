using Domain.ValueObjects.Resources;

namespace Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for UserName values that longer then USER_NAME_MAX_LENGTH
    /// </summary>
    /// <param name="value"> UserName received value </param>
    internal class UserNameMaxLenghtException(int valueLength)
        : ArgumentOutOfRangeException("Value", string.Format(UserNameResources.USER_NAME_MAX_LENGHT_EXCEPTION, valueLength, UserNameResources.USER_NAME_MAX_LENGTH));
}