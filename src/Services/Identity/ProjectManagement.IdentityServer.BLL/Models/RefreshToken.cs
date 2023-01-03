namespace ProjectManagement.IdentityServer.BLL.Models;

public class RefreshToken
{
    public int Id { get; set; }
    public bool IsUsed { get; set; }
    public string Token { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public DateTimeOffset ExpirationTime { get; set; }
    public bool IsExpired => ExpirationTime > DateTimeOffset.UtcNow;
}