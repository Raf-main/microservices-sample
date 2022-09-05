namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IHasDomainEvent
{
    ICollection<IDomainEvent> DomainEvents { get; }
    void AddDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}