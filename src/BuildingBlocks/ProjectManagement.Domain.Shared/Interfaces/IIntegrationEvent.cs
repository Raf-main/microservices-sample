namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IIntegrationEvent : IEvent
{
    Guid Id { get; }
}