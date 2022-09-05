namespace ProjectManagement.Project.Application.Commands;

public class CreateProjectCommand
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}