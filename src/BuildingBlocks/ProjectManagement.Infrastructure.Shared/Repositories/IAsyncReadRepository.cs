using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncReadRepository<TAggregate, in TKey> where TAggregate : IAggregateRoot<TKey>
{
    Task<IEnumerable<TAggregate>> GetAllAsync();
    Task<IEnumerable<TAggregate>> GetPagedAsync(int pageNumber, int pageSize);
    Task<TAggregate> GetByKeyAsync(TKey key);
}