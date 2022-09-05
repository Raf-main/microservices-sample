namespace ProjectManagement.Project.Application.DTOs;

public class ProjectDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<TodoDto> TodoItems { get; set; } = new HashSet<TodoDto>();
}