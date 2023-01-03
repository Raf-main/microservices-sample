namespace ProjectManagement.IdentityServer.BLL.Models;

public class Tokens
{
    public RefreshToken RefreshToken { get; set; } = null!;
    public AccessToken AccessToken { get; set; } = null!;
}