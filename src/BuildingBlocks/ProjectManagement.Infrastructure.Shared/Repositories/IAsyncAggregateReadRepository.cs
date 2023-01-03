using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncAggregateReadRepository<TAggregate, in TKey> : IAsyncReadRepository<TAggregate, TKey>
    where TAggregate : IAggregateRoot<TKey> { }