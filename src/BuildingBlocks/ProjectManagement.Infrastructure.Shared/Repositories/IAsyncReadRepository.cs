namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncReadRepository<TEntity, in TKey>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize);
    Task<TEntity?> GetByKeyAsync(TKey key);
}