using MediatR;
using ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

namespace ProjectManagement.Project.Application.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IAsyncProjectWriteRepository _writeRepository;

    public CreateProjectCommandHandler(IAsyncProjectWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = Domain.Entities.Project.Create(request.Name, request.Description);
        await _writeRepository.AddAsync(project);

        return project.Id;
    }
}