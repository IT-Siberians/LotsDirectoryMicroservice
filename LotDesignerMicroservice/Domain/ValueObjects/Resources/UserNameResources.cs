namespace Domain.ValueObjects.Resources
{
    /// <summary>
    /// Constants and message strings for UserName value objects
    /// </summary>
    internal static class UserNameResources
    {
        /// <summary>
        /// Maximal lenght for UserName value
        /// </summary>
        public const int USER_NAME_MAX_LENGTH = 30;

        /// <summary>
        /// Text message for exception for null, empty or only white spaces UserName values
        /// </summary>
        public const string USER_NAME_NULL_OR_WHITE_SPACES_EXCEPTION = "Received UserName value is null, empty or only white spaces";

        /// <summary>
        /// Text message for exception for UserName values that longer then USER_NAME_MAX_LENGTH
        /// </summary>
        public const string USER_NAME_MAX_LENGHT_EXCEPTION = "Received UserName value length ({0}) is longer than the maximum value ({1}).";
    }
}