namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IHasCreateTime
{
    DateTimeOffset CreatedOn { get; }
}