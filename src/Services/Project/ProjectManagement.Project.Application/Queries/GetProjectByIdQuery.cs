using MediatR;
using ProjectManagement.Project.Application.DTOs;

namespace ProjectManagement.Project.Application.Queries;

public class GetProjectByIdQuery : IRequest<ProjectDto>
{
    public Guid Id { get; set; }
}