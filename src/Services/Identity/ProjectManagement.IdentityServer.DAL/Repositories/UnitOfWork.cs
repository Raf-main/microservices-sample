using Microsoft.Extensions.Logging;
using ProjectManagement.IdentityServer.DAL.Contexts;
using ProjectManagement.IdentityServer.DAL.Repositories.Interfaces;

namespace ProjectManagement.IdentityServer.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdentityServerDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(IdentityServerDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IRefreshTokenRepository RefreshTokens =>
        _refreshTokenRepository ?? new RefreshTokenRepository(_context);

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();

            _logger.LogInformation("Changes were successfully saved to the database");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Saving changes to the database passed with error");

            throw;
        }
    }

#pragma warning disable CS0649
    private readonly IRefreshTokenRepository? _refreshTokenRepository;
#pragma warning restore CS0649
}