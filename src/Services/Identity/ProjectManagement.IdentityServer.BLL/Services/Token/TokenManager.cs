using System.Security.Claims;
using Microsoft.Extensions.Options;
using ProjectManagement.Auth.JWT.Options;
using ProjectManagement.Auth.JWT.TokenGenerators;
using ProjectManagement.IdentityServer.BLL.Models;
using ProjectManagement.Utils.Time;

namespace ProjectManagement.IdentityServer.BLL.Services.Token;

internal class TokenManager : ITokenManager
{
    private readonly IJwtTokenGenerator _accessTokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtOptions _options;

    public TokenManager(IJwtTokenGenerator accessTokenGenerator,
        IRefreshTokenGenerator refreshTokenGenerator,
        IOptions<JwtOptions> options,
        IDateTimeProvider dateTimeProvider)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _refreshTokenGenerator = refreshTokenGenerator;
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }

    public AccessToken GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var expires = _dateTimeProvider.UtcNow().AddMinutes(_options.TokenExpirationTimeInMinutes);

        return new AccessToken
        {
            Token = _accessTokenGenerator.GenerateToken(claims, expires),
            ExpirationTime = expires
        };
    }

    public RefreshToken GenerateRefreshToken(string userId)
    {
        var expirationTime = _dateTimeProvider.OffsetUtcNow().AddHours(_options.RefreshTokenExpirationTimeInHours);

        return new RefreshToken
        {
            ExpirationTime = expirationTime,
            Token = _refreshTokenGenerator.GenerateUniqueToken(),
            UserId = userId
        };
    }
}