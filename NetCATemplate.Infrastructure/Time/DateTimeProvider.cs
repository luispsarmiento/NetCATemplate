using NetCATemplate.SharedKernel;

namespace NetCATemplate.Infrastructure.Time;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
