namespace ProjectManagement.IdentityServer.BLL.Models;

public class AccessToken
{
    public string Token { get; set; } = null!;
    public DateTimeOffset ExpirationTime { get; set; }
}