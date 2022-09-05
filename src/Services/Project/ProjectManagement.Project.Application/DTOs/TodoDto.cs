using ProjectManagement.Project.Domain.Enums;

namespace ProjectManagement.Project.Application.DTOs;

public class TodoDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TodoStatus Status { get; set; }
}