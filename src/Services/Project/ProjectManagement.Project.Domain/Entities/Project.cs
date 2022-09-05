using ProjectManagement.Domain.Shared.Interfaces;
using ProjectManagement.EventSourcing.Shared.Abstractions;
using ProjectManagement.Project.Domain.Events;

namespace ProjectManagement.Project.Domain.Entities;

public class Project : EventSourcedAggregateRoot
{
    public string Name { get; private set; } = "Default name";
    public string Description { get; private set; } = "Default description";
    public ICollection<Todo> TodoItems { get; private set; } = new HashSet<Todo>();

    protected Project()
    {
        Id = Guid.NewGuid();
        OriginalVersion = 0;
    }

    public Project(Guid id, IEnumerable<IDomainEvent> appliedEvents) : this()
    {
        Id = id;

        foreach (var @event in appliedEvents)
        {
            Apply(@event);
        }
    }

    public Project(Guid id, ICollection<Todo> todoItems, string name, string description, long version)
    {
        Id = id;
        TodoItems = todoItems;
        Name = name;
        Description = description;
        OriginalVersion = version;
        CurrentVersion = version;
    }

    public static Project Create(string name, string description)
    {
        var project = new Project
        {
            Name = name,
            Description = description
        };

        var @event =
            new ProjectCreatedDomainEvent(project.Id, DateTimeOffset.UtcNow, project.Name, project.Description);

        project.Apply(@event);

        return project;
    }

    public void AddTodoItem(Todo todo)
    {
        if (todo == null)
        {
            throw new ArgumentNullException(nameof(todo));
        }

        var @event = new TodoCreatedDomainEvent(todo, DateTimeOffset.UtcNow);
        Apply(@event);
    }

    protected void Apply(ProjectCreatedDomainEvent projectCreatedDomainEvent)
    {
        Id = projectCreatedDomainEvent.ProjectId;
    }

    protected void Apply(TodoCreatedDomainEvent todoCreatedDomainEvent)
    {
        TodoItems.Add(todoCreatedDomainEvent.CreatedTodo);
    }
}