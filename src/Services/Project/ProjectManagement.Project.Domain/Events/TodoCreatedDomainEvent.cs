using ProjectManagement.Domain.Shared.Abstractions;
using ProjectManagement.Project.Domain.Entities;

namespace ProjectManagement.Project.Domain.Events;

public class TodoCreatedDomainEvent : DomainEvent
{
    public Todo CreatedTodo { get; set; }
    public override string EventType => nameof(TodoCreatedDomainEvent);

    public TodoCreatedDomainEvent(Todo todo, DateTimeOffset evenDateTimeOffset) : base(evenDateTimeOffset)
    {
        CreatedTodo = todo;
    }
}