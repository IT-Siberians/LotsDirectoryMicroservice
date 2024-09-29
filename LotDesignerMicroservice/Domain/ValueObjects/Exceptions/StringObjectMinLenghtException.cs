namespace LotDesignerMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Exception for string value object's value than shorter than minimum lenght value
    /// </summary>
    /// <param name="type"> String object's type </param>
    /// <param name="valueLenght"> Received value's lenght </param>
    /// <param name="maxLenght"> Minimum value's lenght </param>
    internal class StringObjectMinLenghtException(Type type, int valueLenght, int minLenght)
        : ArgumentOutOfRangeException("Value", $"Received {type.Name} string value length({valueLenght}) is shorter than the minimum value({minLenght}).");
}