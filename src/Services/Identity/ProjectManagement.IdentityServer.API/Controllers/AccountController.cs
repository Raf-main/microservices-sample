using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.IdentityServer.API.Models.Inputs;
using ProjectManagement.IdentityServer.API.Models.Views;
using ProjectManagement.IdentityServer.BLL.Exceptions;
using ProjectManagement.IdentityServer.BLL.Models.Request;
using ProjectManagement.IdentityServer.BLL.Services.Account;

namespace ProjectManagement.IdentityServer.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private const string RefreshTokenCookieKey = "RefreshToken";
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<AccountController> _logger;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService,
        IMapper mapper,
        ILogger<AccountController> logger,
        ICurrentUserService currentUserService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _logger = logger;
        _currentUserService = currentUserService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginInputModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginInputModel loginInput)
    {
        try
        {
            var loginResponse = await _accountService.LoginAsync(_mapper.Map<LoginRequest>(loginInput));
            var loginViewModel = _mapper.Map<LoginViewModel>(loginResponse);

            SetResponseCookie(RefreshTokenCookieKey, loginResponse.RefreshToken.Token,
                loginResponse.RefreshToken.ExpirationTime.Date, true);

            return Ok(loginViewModel);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationInputModel registrationInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Root.Errors.Select(e => e.ErrorMessage));
        }

        try
        {
            await _accountService.RegisterAsync(_mapper.Map<RegistrationRequest>(registrationInput));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ValidationErrors);
        }

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshAccessToken()
    {
        if (TryGetRequestCookie(RefreshTokenCookieKey, out var refreshToken) ||
            string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Request doesn't contain refresh token");
        }

        AccessTokenViewModel accessTokenViewModel;

        try
        {
            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = refreshToken
            };

            var tokens = await _accountService.RefreshTokenAsync(refreshTokenRequest);

            SetResponseCookie(RefreshTokenCookieKey, tokens.RefreshToken.Token, tokens.RefreshToken.ExpirationTime.Date,
                true);

            accessTokenViewModel = _mapper.Map<AccessTokenViewModel>(tokens);
        }
        catch (SecurityTokenExpiredException ex)
        {
            _logger.LogError(ex, $"Refresh token {refreshToken} is expired");

            return Unauthorized(ex.Message);
        }
        catch (SecurityTokenException ex)
        {
            _logger.LogError(ex, ex.Message);

            return BadRequest(ex.Message);
        }

        return Ok(accessTokenViewModel);
    }

    [NonAction]
    private void SetResponseCookie(string key, string value, DateTime expirationDate, bool httpOnly = false)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = httpOnly,
            Expires = expirationDate
        };

        HttpContext.Response.Cookies.Append(key, value, cookieOptions);
    }

    [NonAction]
    private bool TryGetRequestCookie(string key, out string? value)
    {
        return HttpContext.Request.Cookies.TryGetValue(key, out value);
    }
}