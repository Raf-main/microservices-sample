namespace ProjectManagement.Domain.Shared.Interfaces;

public interface IHasKey<T>
{
    T Id { get; }
}