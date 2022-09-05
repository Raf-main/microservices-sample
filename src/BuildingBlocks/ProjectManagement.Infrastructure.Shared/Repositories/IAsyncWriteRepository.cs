using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncWriteRepository<in TAggregate, TKey> where TAggregate : IAggregateRoot<TKey>
{
    Task AddAsync(TAggregate aggregate);
    Task UpdateAsync(TAggregate aggregate);
    Task DeleteAsync(TAggregate aggregate);
}