using ProjectManagement.Domain.Shared.Interfaces;
using ProjectManagement.Project.Domain.Enums;

namespace ProjectManagement.Project.Domain.Entities;

public class Todo : IEntity<Guid>, ITrackable
{
    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset UpdatedOn { get; private set; }
    public string Name { get; private set; } = "Default name";
    public string Description { get; private set; } = "Default description";
    public TodoStatus Status { get; private set; } = TodoStatus.New;

    protected Todo()
    {
        Id = Guid.NewGuid();
    }

    public Todo(Guid id,
        Guid projectId,
        string name,
        string description,
        DateTimeOffset createdOn,
        DateTimeOffset updatedOn,
        TodoStatus status)
    {
        Id = id;
        ProjectId = projectId;
        Name = name;
        Description = description;
        CreatedOn = createdOn;
        UpdatedOn = updatedOn;
        Status = status;
    }
}