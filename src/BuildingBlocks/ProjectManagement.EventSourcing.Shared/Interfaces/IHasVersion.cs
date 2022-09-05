namespace ProjectManagement.EventSourcing.Shared.Interfaces;

public interface IHasVersion<out TVersion> where TVersion : IEquatable<TVersion>
{
    public TVersion OriginalVersion { get; }
    public TVersion CurrentVersion { get; }
}