using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Domain.Shared.Abstractions;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; }
    public DateTimeOffset EventDateTimeOffset { get; }
    public string EventType { get; }

    protected IntegrationEvent(DateTimeOffset eventDateTimeOffset)
    {
        EventDateTimeOffset = eventDateTimeOffset;
        Id = Guid.NewGuid();
        EventType = GetType().Name;
    }
}