namespace ProjectManagement.Auth.JWT.TokenGenerators;

public interface IRefreshTokenGenerator
{
    string GenerateUniqueToken();
}