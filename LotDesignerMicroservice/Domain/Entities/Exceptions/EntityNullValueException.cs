namespace LotDesignerMicroservice.Domain.Entities.Exceptions
{
    /// <summary>
    /// Exception for null entity property
    /// </summary>
    internal class EntityNullValueException(Type type, string paramName)
        : ArgumentNullException("paramName", $"Received {type.Name} {paramName} value is null");
}
