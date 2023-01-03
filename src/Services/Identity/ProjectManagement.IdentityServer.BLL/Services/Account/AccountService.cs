using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.IdentityServer.BLL.Exceptions;
using ProjectManagement.IdentityServer.BLL.Models;
using ProjectManagement.IdentityServer.BLL.Models.Request;
using ProjectManagement.IdentityServer.BLL.Models.Response;
using ProjectManagement.IdentityServer.BLL.Services.Token;
using ProjectManagement.IdentityServer.DAL.DbEntries;
using ProjectManagement.IdentityServer.DAL.Repositories.Interfaces;
using ValidationException = ProjectManagement.IdentityServer.BLL.Exceptions.ValidationException;

namespace ProjectManagement.IdentityServer.BLL.Services.Account;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<UserDbEntry> _userManager;
    private readonly ITokenManager _tokenManager;

    public AccountService(IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<UserDbEntry> userManager,
        ITokenManager tokenManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _tokenManager = tokenManager;
        _mapper = mapper;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with email {loginRequest.Email} was not found");
        }

        var authClaims = await GetClaimsAsync(user);
        
        var accessToken = _tokenManager.GenerateAccessToken(authClaims);
        var refreshToken = _tokenManager.GenerateRefreshToken(user.Id);

        var refreshTokenDbEntry = _mapper.Map<RefreshTokenDbEntry>(refreshToken);
        await _unitOfWork.RefreshTokens.AddAsync(refreshTokenDbEntry);
        await _unitOfWork.SaveChangesAsync();

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task RegisterAsync(RegistrationRequest registrationRequest)
    {
        var userDbEntry = _mapper.Map<UserDbEntry>(registrationRequest);

        var result = await _userManager.CreateAsync(userDbEntry);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);

            throw new ValidationException(
                $"Something went wrong while creating user with email {registrationRequest.Email}",
                errors);
        }
    }

    public async Task<Tokens> RefreshTokenAsync(RefreshTokenRequest refreshRequest)
    {
        var refreshTokenDbEntry = await _unitOfWork.RefreshTokens.GetByTokenAsync(refreshRequest.RefreshToken);
        
        if (refreshTokenDbEntry == null || refreshTokenDbEntry.IsUsed)
        {
            throw new NotFoundException($"Refresh token was not found");
        }

        if (refreshTokenDbEntry.IsExpired)
        {
            throw new SecurityTokenExpiredException("Refresh token was expired");
        }

        var user = await _userManager.FindByIdAsync(refreshTokenDbEntry.UserId);

        if (user == null)
        {
            throw new NotFoundException($"User was not found");
        }

        var authClaims = await GetClaimsAsync(user);
        var accessToken = _tokenManager.GenerateAccessToken(authClaims);
        var refreshToken = _tokenManager.GenerateRefreshToken(user.Id);

        refreshTokenDbEntry.IsUsed = true;
        await _unitOfWork.RefreshTokens.UpdateAsync(refreshTokenDbEntry);
        await _unitOfWork.RefreshTokens.AddAsync(_mapper.Map<RefreshTokenDbEntry>(refreshToken));
        await _unitOfWork.SaveChangesAsync();

        return new Tokens
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    private async Task<IEnumerable<Claim>> GetClaimsAsync(UserDbEntry user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id)
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        if (userRoles != null && userRoles.Count > 0)
        {
            authClaims.AddRange(userRoles.Where(role => !string.IsNullOrEmpty(role))
                .Select(role => new Claim(ClaimTypes.Role, role)));
        }

        return authClaims;
    }
}