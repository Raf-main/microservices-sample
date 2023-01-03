using MediatR;
using ProjectManagement.Project.Application.DTOs;

namespace ProjectManagement.Project.Application.Queries;

public class GetProjectsQuery : IRequest<IEnumerable<ProjectDto>> { }