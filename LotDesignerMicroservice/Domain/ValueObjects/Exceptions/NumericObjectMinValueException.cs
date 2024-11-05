namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for numeric object's values that lesser than minimum value
    /// </summary>
    /// <typeparam name="T"> Numeric object's value's type </typeparam>
    /// <param name="type"> Numeric object's type </param>
    /// <param name="value"> Received value </param>
    /// <param name="maxValue"> Minimum value </param>
    internal class NumericObjectMinValueException<T>(Type type, T value, T minValue)
        : ArgumentOutOfRangeException("Value", $"Received {type.Name} value({value}) is lesser than minimum value({minValue})");
}