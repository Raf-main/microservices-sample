using MediatR;

namespace ProjectManagement.Project.Application.Commands;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}