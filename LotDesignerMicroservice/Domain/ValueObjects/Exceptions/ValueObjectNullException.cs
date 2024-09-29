namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null value object's value method
    /// </summary>
    internal class ValueObjectNullException(Type type)
        : ArgumentNullException("Value", $"Received {type.Name} value is null");
}
