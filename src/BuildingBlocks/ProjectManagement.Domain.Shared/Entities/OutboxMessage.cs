namespace ProjectManagement.Domain.Shared.Entities;

public class OutboxMessage
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public string Message { get; set; } = null!;
    public string AggregateType { get; set; } = null!;
    public string Payload { get; set; } = null!;
    public bool IsProcessed = false;
    public bool IsFailed = true;
}