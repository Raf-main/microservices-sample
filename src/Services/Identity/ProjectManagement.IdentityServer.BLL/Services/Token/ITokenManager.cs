using System.Security.Claims;
using ProjectManagement.IdentityServer.BLL.Models;

namespace ProjectManagement.IdentityServer.BLL.Services.Token;

public interface ITokenManager
{
    AccessToken GenerateAccessToken(IEnumerable<Claim> claims);
    RefreshToken GenerateRefreshToken(string userId);
}