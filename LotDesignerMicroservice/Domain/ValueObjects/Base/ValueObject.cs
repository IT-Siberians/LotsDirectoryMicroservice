namespace Domain.ValueObjects.Base
{
    /// <summary>
    /// Base value object class
    /// </summary>
    /// <typeparam name="T"> Stored value type </typeparam>
    public abstract class ValueObject<T>
    {
        /// <summary>
        /// General constructor for all value objects
        /// </summary>
        /// <param name="value"></param>
        public ValueObject(T value)
        {
            Validate(value);
            Value = value;
        }

        /// <summary>
        /// Value object`s stored value
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Validate object`s value, throws exception if invalid
        /// </summary>
        /// <param name="value"></param>
        protected abstract void Validate(T value);
    }
}
