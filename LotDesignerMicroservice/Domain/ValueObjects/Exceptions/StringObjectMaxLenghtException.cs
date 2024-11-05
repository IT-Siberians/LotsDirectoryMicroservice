namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for string value object's value than longer than maximum lenght value
    /// </summary>
    /// <param name="type"> String object's type </param>
    /// <param name="valueLenght"> Received value's lenght </param>
    /// <param name="maxLenght"> Maximum value's lenght </param>
    internal class StringObjectMaxLenghtException(Type type, int valueLenght, int maxLenght)
        : ArgumentOutOfRangeException("Value", $"Received {type.Name} string value length({valueLenght}) is longer than the maximum value({maxLenght}).");
}