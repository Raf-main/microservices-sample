using ProjectManagement.Utils.Id;

namespace ProjectManagement.Auth.JWT.TokenGenerators;

internal class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly IIdGenerator _idGenerator;

    public RefreshTokenGenerator(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public string GenerateUniqueToken()
    {
        return _idGenerator.GenerateUniqueId();
    }
}