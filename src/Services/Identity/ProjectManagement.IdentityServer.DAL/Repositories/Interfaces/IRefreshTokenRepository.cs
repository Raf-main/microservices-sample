using ProjectManagement.IdentityServer.DAL.DbEntries;
using ProjectManagement.Infrastructure.Shared.Repositories;

namespace ProjectManagement.IdentityServer.DAL.Repositories.Interfaces;

public interface IRefreshTokenRepository : IAsyncCrudRepository<RefreshTokenDbEntry, int>
{
    Task<RefreshTokenDbEntry?> GetByTokenAsync(string token);
}