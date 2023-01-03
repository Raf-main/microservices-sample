using MediatR;
using ProjectManagement.Project.Application.DTOs;

namespace ProjectManagement.Project.Application.Queries;

public class GetPagedProjectsQuery : IRequest<IEnumerable<ProjectDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}