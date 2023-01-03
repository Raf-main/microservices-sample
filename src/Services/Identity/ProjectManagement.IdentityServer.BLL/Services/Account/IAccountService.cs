using ProjectManagement.IdentityServer.BLL.Models;
using ProjectManagement.IdentityServer.BLL.Models.Request;
using ProjectManagement.IdentityServer.BLL.Models.Response;

namespace ProjectManagement.IdentityServer.BLL.Services.Account;

public interface IAccountService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task RegisterAsync(RegistrationRequest registrationRequest);
    Task<Tokens> RefreshTokenAsync(RefreshTokenRequest refreshRequest);
}