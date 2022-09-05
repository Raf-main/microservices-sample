using ProjectManagement.Infrastructure.Shared.Repositories;

namespace ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

internal interface IAsyncProjectWriteRepository : IAsyncWriteRepository<Domain.Entities.Project, Guid> { }