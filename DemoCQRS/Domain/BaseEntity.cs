namespace DemoCQRS.Domain;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
}
