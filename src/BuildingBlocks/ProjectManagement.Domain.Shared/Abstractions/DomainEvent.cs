using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Domain.Shared.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; }
    public DateTimeOffset EventDateTimeOffset { get; }
    public abstract string EventType { get; }

    protected DomainEvent(DateTimeOffset eventDateTimeOffset)
    {
        EventDateTimeOffset = eventDateTimeOffset;
        Id = Guid.NewGuid();
    }
}