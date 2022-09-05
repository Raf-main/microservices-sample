using ProjectManagement.Infrastructure.Shared.Repositories;

namespace ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

internal interface IAsyncProjectReadRepository : IAsyncReadRepository<Domain.Entities.Project, Guid> { }