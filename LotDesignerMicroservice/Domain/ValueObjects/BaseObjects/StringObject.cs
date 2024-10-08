using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents string object that always has not null, not empty and not only white spaces string value
    /// </summary>
    public abstract class StringObject : ValueObject<string>
    {
        /// <summary>
        /// Min value's lenght
        /// </summary>
        public abstract int MIN_LENGHT { get; }

        /// <summary>
        /// Max value's lenght
        /// </summary>
        public abstract int MAX_LENGHT { get; }

        /// <summary>
        /// Represents string object that always has not null, not empty and not only white spaces string value
        /// </summary>
        /// <param name="value"> Stored not null, not empty and not only white spaces string value </param>
        /// <param name="validate"> Additional validation method </param>
        /// <exception cref="StringObjectEmptyOrWhiteSpacesException"></exception>
        public StringObject(string value, Action<string>? validate = null) : base(value, validate)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new StringObjectEmptyOrWhiteSpacesException(GetType(), value);

            if (value.Length < MIN_LENGHT)
                throw new StringObjectMinLenghtException(GetType(), value.Length, MIN_LENGHT);

            if (value.Length > MAX_LENGHT)
                throw new StringObjectMaxLenghtException(GetType(), value.Length, MAX_LENGHT);
        }
    }
}