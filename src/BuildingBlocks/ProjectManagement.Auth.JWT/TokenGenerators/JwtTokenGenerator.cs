using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Auth.JWT.Options;
using ProjectManagement.Utils.Time;

namespace ProjectManagement.Auth.JWT.TokenGenerators;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions, IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateToken(IEnumerable<Claim> claims, DateTime? expirationTime = null)
    {
        var secretKey = _jwtOptions.GetSymmetricSecurityKey();
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var expires = expirationTime ?? _dateTimeProvider.UtcNow().AddMinutes(_jwtOptions.TokenExpirationTimeInMinutes);

        var tokenOptions = new JwtSecurityToken(
            null,
            null,
            claims,
            expires,
            signingCredentials: signinCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }
}