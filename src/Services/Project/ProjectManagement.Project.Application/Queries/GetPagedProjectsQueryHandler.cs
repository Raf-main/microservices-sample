using AutoMapper;
using MediatR;
using ProjectManagement.Project.Application.DTOs;
using ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

namespace ProjectManagement.Project.Application.Queries;

public class GetPagedProjectsQueryHandler : IRequestHandler<GetPagedProjectsQuery, IEnumerable<ProjectDto>>
{
    private readonly IAsyncProjectReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetPagedProjectsQueryHandler(IAsyncProjectReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(GetPagedProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _readRepository.GetPagedAsync(request.PageNumber, request.PageSize);

        var projectsDto = _mapper.Map<IEnumerable<ProjectDto>>(projects);

        return projectsDto;
    }
}