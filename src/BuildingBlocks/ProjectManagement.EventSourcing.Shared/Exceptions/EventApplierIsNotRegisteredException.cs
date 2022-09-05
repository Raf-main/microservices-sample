using System.Runtime.Serialization;
using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.EventSourcing.Shared.Exceptions;

[Serializable]
public class EventApplierIsNotRegisteredException : Exception
{
    public EventApplierIsNotRegisteredException() { }

    public EventApplierIsNotRegisteredException(IDomainEvent domainEvent) : base(
        $"No event applier registered for event {domainEvent}") { }

    public EventApplierIsNotRegisteredException(string message) : base(message) { }

    public EventApplierIsNotRegisteredException(string message, Exception innerException) : base(message,
        innerException) { }

    protected EventApplierIsNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info,
        context) { }
}