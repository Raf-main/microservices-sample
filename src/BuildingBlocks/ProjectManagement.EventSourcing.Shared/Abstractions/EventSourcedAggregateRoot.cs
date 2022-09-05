using ProjectManagement.Domain.Shared.Interfaces;
using ProjectManagement.EventSourcing.Shared.Exceptions;
using ProjectManagement.EventSourcing.Shared.Interfaces;

namespace ProjectManagement.EventSourcing.Shared.Abstractions;

public class EventSourcedAggregateRoot : IEventSourcedAggregateRoot<Guid, long>
{
    public Guid Id { get; protected set; }
    public long OriginalVersion { get; protected set; }
    public long CurrentVersion { get; protected set; }
    public ICollection<IDomainEvent> DomainEvents { get; protected set; } = new List<IDomainEvent>();

    protected IDictionary<Type, Action<object>> EventHandlers { get; set; } =
        new Dictionary<Type, Action<object>>();

    protected EventSourcedAggregateRoot()
    {
        Id = Guid.NewGuid();
        OriginalVersion = 0;
    }

    protected EventSourcedAggregateRoot(Guid id,
        long originalVersion,
        long currentVersion)
    {
        Id = id;
        OriginalVersion = originalVersion;
        CurrentVersion = currentVersion;
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }

    public void Apply(IDomainEvent domainEvent)
    {
        var eventType = domainEvent.GetType();

        if (!EventHandlers.ContainsKey(eventType))
        {
            throw new EventApplierIsNotRegisteredException(domainEvent);
        }

        EventHandlers[eventType](domainEvent);
    }

    public void ApplyChanges(IDomainEvent domainEvent)
    {
        Apply(domainEvent);
        AddDomainEvent(domainEvent);
    }

    protected void RegisterApplier<TEvent>(Action<TEvent> applier) where TEvent : IDomainEvent
    {
        EventHandlers.Add(typeof(TEvent), x => Apply((TEvent)x));
    }
}