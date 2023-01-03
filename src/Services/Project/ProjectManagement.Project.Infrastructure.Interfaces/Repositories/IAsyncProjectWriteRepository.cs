using ProjectManagement.Infrastructure.Shared.Repositories;

namespace ProjectManagement.Project.Infrastructure.Interfaces.Repositories;

public interface IAsyncProjectWriteRepository : IAsyncAggregateWriteRepository<Domain.Entities.Project, Guid> { }