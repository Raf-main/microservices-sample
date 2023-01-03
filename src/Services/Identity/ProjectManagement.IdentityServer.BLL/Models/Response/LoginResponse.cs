namespace ProjectManagement.IdentityServer.BLL.Models.Response;

public class LoginResponse
{
    public RefreshToken RefreshToken { get; set; } = null!;
    public AccessToken AccessToken { get; set; } = null!;
}