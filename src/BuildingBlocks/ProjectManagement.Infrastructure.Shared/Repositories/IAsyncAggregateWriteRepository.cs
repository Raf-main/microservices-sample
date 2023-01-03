using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncAggregateWriteRepository<in TAggregate, TKey> : IAsyncWriteRepository<TAggregate>
    where TAggregate : IAggregateRoot<TKey> { }