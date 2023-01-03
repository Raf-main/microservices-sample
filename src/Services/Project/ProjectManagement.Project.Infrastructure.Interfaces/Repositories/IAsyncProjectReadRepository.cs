using ProjectManagement.Infrastructure.Shared.Repositories;

namespace ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

public interface IAsyncProjectReadRepository : IAsyncAggregateReadRepository<Domain.Entities.Project, Guid> { }