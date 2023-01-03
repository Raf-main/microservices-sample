using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.IdentityServer.DAL.DbEntries;

namespace ProjectManagement.IdentityServer.DAL.Contexts;

public class IdentityServerDbContext : IdentityDbContext
{
    public DbSet<RefreshTokenDbEntry> RefreshTokens => Set<RefreshTokenDbEntry>();

    public IdentityServerDbContext(DbContextOptions opts) : base(opts) { }
}