namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for numeric object's values that greater than maximum value
    /// </summary>
    /// <typeparam name="T"> Numeric object's value's type </typeparam>
    /// <param name="type"> Numeric object's type </param>
    /// <param name="value"> Received value </param>
    /// <param name="maxValue"> Maximum value </param>
    internal class NumericObjectMaxValueException<T>(Type type, T value, T maxValue)
        : ArgumentOutOfRangeException("Value", $"Received {type.Name} value({value}) is greater than maximum value({maxValue})");
}