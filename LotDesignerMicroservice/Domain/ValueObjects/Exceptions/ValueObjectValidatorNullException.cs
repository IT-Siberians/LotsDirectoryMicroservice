namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for null value object's validate method
    /// </summary>
    internal class ValueObjectValidatorNullException(Type type)
        : ArgumentNullException("Validate", $"Type {nameof(type)} has no Validate method");
}