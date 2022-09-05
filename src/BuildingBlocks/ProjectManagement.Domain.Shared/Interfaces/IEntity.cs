namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IEntity { }

public interface IEntity<TKey> : IHasKey<TKey> { }