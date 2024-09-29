namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    internal class TradeDurationMaxValueException(Type type, TimeSpan value, TimeSpan maxValue)
        : ArgumentOutOfRangeException("Value",
            $"Received {type.Name} value({value:HH:mm:ss}) is greater than the maximum value({maxValue:HH:mm:ss}).");
}
