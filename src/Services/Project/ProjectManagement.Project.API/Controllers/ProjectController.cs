using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Shared.Controllers;

namespace ProjectManagement.Project.API.Controllers;

[ApiController]
[Route("[controller]s")]
public class ProjectController : BaseController
{
    public ProjectController(IMapper mapper, IMediator mediator) : base(mapper, mediator) { }
}