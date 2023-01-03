using AutoMapper;
using ProjectManagement.IdentityServer.API.Models.Inputs;
using ProjectManagement.IdentityServer.BLL.Models.Request;

namespace ProjectManagement.IdentityServer.API.Mappers;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<LoginInputModel, LoginRequest>();
    }
}