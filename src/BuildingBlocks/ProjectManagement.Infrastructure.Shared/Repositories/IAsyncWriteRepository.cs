namespace ProjectManagement.Infrastructure.Shared.Repositories;

public interface IAsyncWriteRepository<in TEntity>
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}