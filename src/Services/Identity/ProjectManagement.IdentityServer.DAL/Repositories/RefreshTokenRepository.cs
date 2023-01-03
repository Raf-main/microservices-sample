using Microsoft.EntityFrameworkCore;
using ProjectManagement.IdentityServer.DAL.DbEntries;
using ProjectManagement.IdentityServer.DAL.Repositories.Interfaces;
using ProjectManagement.Infrastructure.Shared.Repositories.EfCore;

namespace ProjectManagement.IdentityServer.DAL.Repositories;

public class RefreshTokenRepository : GenericCrudEfRepository<RefreshTokenDbEntry, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(DbContext context) : base(context) { }

    public async Task<RefreshTokenDbEntry?> GetByTokenAsync(string token)
    {
        return await Table.FirstOrDefaultAsync(t => t.Token == token);
    }
}