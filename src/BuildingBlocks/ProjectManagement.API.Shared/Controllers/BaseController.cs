using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.API.Shared.Controllers;

public abstract class BaseController : ControllerBase
{
    protected readonly IMapper Mapper;
    protected readonly IMediator Mediator;

    protected BaseController(IMapper mapper, IMediator mediator)
    {
        Mapper = mapper;
        Mediator = mediator;
    }
}