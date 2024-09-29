namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null, empty or only white spaces string object's value
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    internal class StringObjectEmptyOrWhiteSpacesException(Type type, string value)
        : ArgumentNullException("Value", $"Received {type.Name} string value \"{value}\" is empty or white spaces");
}
