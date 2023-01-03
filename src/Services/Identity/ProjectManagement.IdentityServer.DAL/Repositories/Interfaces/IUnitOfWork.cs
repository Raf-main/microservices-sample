namespace ProjectManagement.IdentityServer.DAL.Repositories.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    IRefreshTokenRepository RefreshTokens { get; }
}