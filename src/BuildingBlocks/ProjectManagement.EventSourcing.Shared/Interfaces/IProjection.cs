using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.EventSourcing.Shared.Interfaces;

public interface IProjection
{
    void Apply(IDomainEvent domainEvent);
}