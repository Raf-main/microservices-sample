using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Auth.JWT.Options;
using ProjectManagement.IdentityServer.DAL.DbEntries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtOptionsSection = builder.Configuration.GetSection("JwtOptions");
builder.Services.Configure<JwtOptions>(jwtOptionsSection);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var jwtOptions = jwtOptionsSection.Get<JwtOptions>();

        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtOptions.ValidateIssuer,
            ValidateAudience = jwtOptions.ValidateAudience,
            RequireExpirationTime = jwtOptions.RequireExpirationTime,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            ValidIssuers = jwtOptions.ValidIssuers,
            ValidAudiences = jwtOptions.ValidAudiences,
            IssuerSigningKey = jwtOptions.GetSymmetricSecurityKey()
        };
    });

builder.Services.AddIdentity<UserDbEntry, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = false;
}).AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();