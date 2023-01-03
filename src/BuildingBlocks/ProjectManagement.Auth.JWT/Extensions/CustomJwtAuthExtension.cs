using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Auth.JWT.Options;

namespace ProjectManagement.Auth.JWT.Extensions;

public static class CustomJwtAuthExtension
{
    public const string JwtSectionName = "JwtOptions";

    public static void AddCustomJwtAuth(this IServiceCollection services, IConfiguration config)
    {
        // Много минусов
        // Сейчас настройки для jwt придется дублировать во все API(
        // Нужно придумать сторонний сервис для хранения ключей
        // Мб в этом проекте (ProjectManagement.Auth.JWT) сделать файл и хранить его здесь
        // Мб в бд какой-то хранить и здесь будет подключение к этой бд для того чтобы взять ключ
        // Хотя по сети ключи перекидывать...такое себе наверное
        // Также пока что без Issuer и Audience
        // TODO: погуглить про хранение ключей для JWTшки
        var options = config.GetValue<JwtOptions>(JwtSectionName);
        
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;

            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = options.GetSymmetricSecurityKey(),
            };
        });
    }
}