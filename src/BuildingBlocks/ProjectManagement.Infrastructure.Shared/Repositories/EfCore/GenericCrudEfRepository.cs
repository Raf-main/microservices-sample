using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.Infrastructure.Shared.Repositories.EfCore;

public abstract class GenericCrudEfRepository<TEntity, TKey> : IAsyncCrudRepository<TEntity, TKey>
    where TEntity : class, IHasKey<TKey>
    where TKey : IEquatable<TKey>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> Table;

    protected GenericCrudEfRepository(DbContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        Table.Update(entity);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        Table.Remove(entity);

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Table.AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return Task.FromResult(Table.Skip((pageNumber - 1) * pageSize)
            .Take(50)
            .AsNoTracking()
            .AsEnumerable());
    }

    public async Task<TEntity?> GetByKeyAsync(TKey key)
    {
        return await Table.FirstOrDefaultAsync(e => e.Id.Equals(key));
    }
}