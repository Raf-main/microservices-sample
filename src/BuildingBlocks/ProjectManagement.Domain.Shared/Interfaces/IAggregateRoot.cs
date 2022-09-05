namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IAggregateRoot<TKey> : IEntity<TKey>, IHasDomainEvent { }