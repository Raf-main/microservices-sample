using MediatR;

namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IEventHandler : INotificationHandler<IEvent> { }