using AutoMapper;
using MediatR;
using ProjectManagement.Project.Application.DTOs;
using ProjectManagement.Project.Application.Exceptions;
using ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

namespace ProjectManagement.Project.Application.Queries;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
{
    private readonly IAsyncProjectReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetProjectByIdQueryHandler(IAsyncProjectReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _readRepository.GetByKeyAsync(request.Id);

        if (project == null)
        {
            throw new NotFoundException($"Project with id {request.Id} was not found");
        }

        var projectDto = _mapper.Map<ProjectDto>(project);

        return projectDto;
    }
}