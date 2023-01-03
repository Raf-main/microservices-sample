namespace ProjectManagement.IdentityServer.API.Models.Inputs;

public class LoginInputModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}