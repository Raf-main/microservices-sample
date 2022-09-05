namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IHasUpdateTime
{
    DateTimeOffset UpdatedOn { get; }
}