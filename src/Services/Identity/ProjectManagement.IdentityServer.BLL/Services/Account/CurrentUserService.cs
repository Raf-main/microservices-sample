using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ProjectManagement.IdentityServer.BLL.Services.Account;

public class CurrentUserService : ICurrentUserService
{
    private readonly HttpContext _httpContext;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(contextAccessor));
    }

    public ClaimsPrincipal GetUser()
    {
        return _httpContext.User;
    }

    public string GetId()
    {
        return GetUserClaim(ClaimTypes.NameIdentifier);
    }

    public string GetUserClaim(string claimKey)
    {
        return _httpContext.User.Claims.First(claim => claim.Type == claimKey).ToString();
    }
}