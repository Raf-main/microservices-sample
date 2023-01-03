using AutoMapper;
using ProjectManagement.IdentityServer.BLL.Models;
using ProjectManagement.IdentityServer.DAL.DbEntries;

namespace ProjectManagement.IdentityServer.BLL.Profiles;

public class RefreshTokenProfile : Profile
{
    public RefreshTokenProfile()
    {
        CreateMap<RefreshTokenDbEntry, RefreshToken>();
        CreateMap<RefreshToken, RefreshTokenDbEntry>();
    }
}