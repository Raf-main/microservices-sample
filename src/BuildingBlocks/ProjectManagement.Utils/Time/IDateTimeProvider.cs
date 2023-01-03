namespace ProjectManagement.Utils.Time;

public interface IDateTimeProvider
{
    DateTimeOffset OffsetNow();
    DateTimeOffset OffsetUtcNow();
    DateTime Now();
    DateTime UtcNow();
}