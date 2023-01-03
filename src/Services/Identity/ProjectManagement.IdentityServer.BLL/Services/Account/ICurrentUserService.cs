using System.Security.Claims;

namespace ProjectManagement.IdentityServer.BLL.Services.Account;

public interface ICurrentUserService
{
    ClaimsPrincipal GetUser();
    string GetId();
    string GetUserClaim(string claimKey);
}