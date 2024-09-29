namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    internal class TradeDurationMinValueException(Type type, TimeSpan value, TimeSpan minValue)
        : ArgumentOutOfRangeException("Value",
            $"Received {type.Name} value({value:HH:mm:ss}) is lesser than the minimum value({minValue:HH:mm:ss}).");
}
