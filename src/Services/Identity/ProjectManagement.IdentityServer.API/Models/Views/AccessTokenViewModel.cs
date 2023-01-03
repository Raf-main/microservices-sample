namespace ProjectManagement.IdentityServer.API.Models.Views;

public class AccessTokenViewModel
{
    public string Token { get; set; } = null!;
    public DateTimeOffset ExpirationTime { get; set; }
}