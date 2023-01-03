using System.Security.Claims;

namespace ProjectManagement.Auth.JWT.TokenGenerators;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims, DateTime? expirationTime = null);
}