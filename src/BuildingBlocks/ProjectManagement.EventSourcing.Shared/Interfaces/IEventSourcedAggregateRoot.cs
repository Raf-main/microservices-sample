using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.EventSourcing.Shared.Interfaces;

public interface IEventSourcedAggregateRoot<TKey, out TVersion> : IAggregateRoot<TKey>, IHasVersion<TVersion>,
    IProjection where TVersion : IEquatable<TVersion> { }