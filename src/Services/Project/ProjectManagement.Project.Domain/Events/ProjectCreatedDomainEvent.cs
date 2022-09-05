using ProjectManagement.Domain.Shared.Abstractions;

namespace ProjectManagement.Project.Domain.Events;

public class ProjectCreatedDomainEvent : DomainEvent
{
    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public override string EventType => nameof(ProjectCreatedDomainEvent);

    public ProjectCreatedDomainEvent(Guid projectId,
        DateTimeOffset eventDateTimeOffset,
        string projectName,
        string projectDescription) :
        base(eventDateTimeOffset)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        ProjectDescription = projectDescription;
    }
}