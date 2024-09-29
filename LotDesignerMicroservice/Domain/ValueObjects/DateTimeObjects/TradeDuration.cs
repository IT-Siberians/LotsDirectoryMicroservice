using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects
{
    public sealed class TradeDuration(TimeSpan value) : ValueObject<TimeSpan>(value, Validate)
    {
        public static TimeSpan MIN_DURATION { get; } = new TimeSpan(3, 0, 0);
        public static TimeSpan MAX_DURATION { get; } = new TimeSpan(90, 0, 0, 0);

        private static void Validate(TimeSpan value)
        {
            if (value < MIN_DURATION)
                throw new TradeDurationMinValueException(typeof(TradeDuration), value, MIN_DURATION);
            if (value > MAX_DURATION)
                throw new TradeDurationMaxValueException(typeof(TradeDuration), value, MAX_DURATION);
        }
    }
}
