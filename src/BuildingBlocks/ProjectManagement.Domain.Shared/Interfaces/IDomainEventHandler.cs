namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IDomainEventHandler : IEventHandler
{
    public void Handle(IDomainEvent domainEvent);
}