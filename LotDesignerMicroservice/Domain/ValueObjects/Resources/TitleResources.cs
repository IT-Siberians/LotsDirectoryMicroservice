namespace Domain.ValueObjects.Resources
{
    /// <summary>
    /// Constants and message strings for Title value objects
    /// </summary>
    internal static class TitleResources
    {
        /// <summary>
        /// Maximal lenght for Title value
        /// </summary>
        public const int TITLE_MAX_LENGTH = 50;

        /// <summary>
        /// Text message for exception for null, empty or only white spaces Title values
        /// </summary>
        public const string TITLE_NULL_OR_WHITE_SPACES_EXCEPTION = "Received Title value is null, empty or only white spaces";

        /// <summary>
        /// Text message for exception for Title values that longer then TITLE_MAX_LENGTH
        /// </summary>
        public const string TITLE_MAX_LENGHT_EXCEPTION = "Received Title value length ({0}) is longer than the maximum value ({1}).";
    }
}