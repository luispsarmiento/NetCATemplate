namespace NetCATemplate.SharedKernel;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
