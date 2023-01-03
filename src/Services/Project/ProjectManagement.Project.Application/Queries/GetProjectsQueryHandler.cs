using AutoMapper;
using ProjectManagement.Project.Application.DTOs;
using ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

namespace ProjectManagement.Project.Application.Queries;

public class GetProjectsQueryHandler
{
    private readonly IAsyncProjectReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetProjectsQueryHandler(IAsyncProjectReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(GetPagedProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _readRepository.GetAllAsync();

        var projectsDto = _mapper.Map<IEnumerable<ProjectDto>>(projects);

        return projectsDto;
    }
}