using MediatR;

namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IEvent : INotification
{
    public DateTimeOffset EventDateTimeOffset { get; }
    public string EventType { get; }
}